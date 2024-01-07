﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTarefasGUI;
using GTarefasGUI.ViewModel;
using GTarefasMe.DAO;
using GTarefasMe.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GTarefasMe.Controller
{
    public class TechLeaderController
    {
        private UsuarioDAO usuarioDAO;
        private TarefaDAO tarefaDAO;
        private LoginDAO loginDAO;
        private ConnectionFactory conn;
        HomeTechLeaderForm HomeTLForm;
       

        public TechLeaderController(HomeTechLeaderForm homeTLForm)
        {
            this.conn = new ConnectionFactory();
            this.loginDAO = new LoginDAO(conn);
            this.tarefaDAO = new TarefaDAO(conn);
            this.usuarioDAO = new UsuarioDAO(conn);
            this.HomeTLForm = homeTLForm;
            HomeTLForm.setVisible(false);
            HomeTLForm.dataGridViewTarefas.Hide();
            InitController();
        }

        private void InitController()
        {
            this.HomeTLForm.SetController(this);
           
        }

        public void ListarTarefas()
        {
            try
            {
            HomeTLForm.setVisible(false);
            HomeTLForm.dataGridViewTarefas.Show();
            List<Tarefa> listaTarefas = this.tarefaDAO.ListarTodasTarefas();
            List<TarefaViewModel> listaTarefasViewModel = listaTarefas.Select(t => new TarefaViewModel(t)).ToList();
            HomeTLForm.dataGridViewTarefas.DataSource = listaTarefasViewModel;
            HomeTLForm.dataGridViewTarefas.Columns["ResponsavelId"].Visible = false;
            HomeTLForm.dataGridViewTarefas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            HomeTLForm.dataGridViewTarefas.CellBeginEdit += HomeTLForm.dataGridViewTarefas_CellBeginEdit;
            }
            catch (Exception ex)
            {
                this.HomeTLForm.ApresentarMensagem(ex.Message);
                Console.WriteLine(ex.Message);
            }
        }
        public void AlterarTarefa()
        {
            // Verificar se há pelo menos uma linha selecionada
            if (HomeTLForm.dataGridViewTarefas.SelectedRows.Count > 0)
            {
                // Obter a tarefa da linha selecionada
                TarefaViewModel tarefaSelecionada = (TarefaViewModel)HomeTLForm.dataGridViewTarefas.SelectedRows[0].DataBoundItem;

                // Exibir detalhes da tarefa nos controles de edição no formulário
                HomeTLForm.textBox1.Text = tarefaSelecionada.Descricao;

                // Preencher o ComboBox com opções de responsáveis da DAO
                List<Usuario> usuarios = usuarioDAO.Listar();
                HomeTLForm.setVisible(true);
                HomeTLForm.comboBox1.DisplayMember = "Nome"; // Exibe o nome do usuário no ComboBox
                HomeTLForm.comboBox1.ValueMember = "Id"; // Valor associado a cada item (pode ser o Id ou outra propriedade)
                HomeTLForm.comboBox1.DataSource = usuarios;


                // Outras lógicas de edição conforme necessário
            }
            else
            {
                HomeTLForm.ApresentarMensagem("Nenhuma tarefa selecionada.");
            }
        }
        public void AtualizarTarefa(object sender, EventArgs e)
        {
            try
            {
                TarefaViewModel tarefaSelecionadaAtual = (TarefaViewModel)HomeTLForm.dataGridViewTarefas.SelectedRows[0].DataBoundItem;
                // Verificar se há uma tarefa selecionada para atualização
                if (tarefaSelecionadaAtual != null)
                {
                    // Preparar os dados para atualização
                    string novaDescricao = HomeTLForm.textBox1.Text;
                    int novoResponsavelId = Convert.ToInt32(HomeTLForm.comboBox1.SelectedValue);

                    // Atualizar a tarefa usando sua DAO
                    tarefaDAO.AtualizarTarefa(tarefaSelecionadaAtual.Id, novaDescricao, novoResponsavelId);

                    // Limpar controles e atualizar a lista de tarefas
                    LimparControles();
                    ListarTarefas();
                }
                else
                {
                    HomeTLForm.ApresentarMensagem("Nenhuma tarefa selecionada para atualização.");
                }
            }
            catch (Exception ex)
            {
                HomeTLForm.ApresentarMensagem($"Erro ao atualizar tarefa: {ex.Message}");
                Console.WriteLine(ex.Message);
            }
        }

        private void LimparControles()
        {
            // Limpar os controles conforme necessário
            HomeTLForm.textBox1.Text = string.Empty;
            HomeTLForm.comboBox1.SelectedIndex = -1;
            // Outros controles, se houver
        }

    }
}
