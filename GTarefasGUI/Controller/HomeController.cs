using System;
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
    public class HomeController
    {
        private UsuarioDAO usuarioDAO;
        private TarefaDAO tarefaDAO;
        private LoginDAO loginDAO;
        private ConnectionFactory conn;
        HomeForm HomeTLForm;
        private InserirTarefaForm inserirTarefaForm;
        private CadastroForm cadastroForm;


        public HomeController(HomeForm homeTLForm)
        {
            this.conn = new ConnectionFactory();
            this.loginDAO = new LoginDAO(conn);
            this.tarefaDAO = new TarefaDAO(conn);
            this.usuarioDAO = new UsuarioDAO(conn);
            this.HomeTLForm = homeTLForm;
            HomeTLForm.setAlterarTarefaMenuVisible(false);
            HomeTLForm.dataGridViewTarefas.Hide();
            InitController();
        }

        private void InitController()
        {
            this.HomeTLForm.SetController(this);
            this.ConfigurarComboBox();
           
        }

        public void ListarTarefas()
        {
            try
            {
                if (HomeTLForm.usuarioAutenticado.TipoUsuario.Equals(TipoUsuario.TechLeader))
                {
                    List<Tarefa> listaTarefas = this.tarefaDAO.ListarTodasTarefas();
                    HomeTLForm.mostrarListaTarefa(listaTarefas);
                }
                else
                {
                    List<Tarefa> listaTarefas = this.tarefaDAO.ObterTarefasPorUserId(HomeTLForm.usuarioAutenticado.UserId);
                    HomeTLForm.mostrarListaTarefa(listaTarefas);
                }
            }
            catch (Exception ex)
            {
                this.HomeTLForm.ApresentarMensagem("Algo deu errado" + ex.Message);
                Console.WriteLine(ex.Message);
            }
        }
        public void AlterarTarefa()
        {
            try
            {
                if (HomeTLForm.usuarioAutenticado.TipoUsuario.Equals(TipoUsuario.TechLeader))
                {
                    List<Usuario> usuarios = usuarioDAO.Listar();
                    HomeTLForm.CarregarComboBoxUsuario(usuarios);
                    HomeTLForm.mostrarAlterarMenu();
                }
                else
                {
                    HomeTLForm.mostrarAlterarMenu();
                }
            }
            catch (Exception ex)
            {
                HomeTLForm.ApresentarMensagemErro("Ocorreu algo errado" + ex.Message);
            }


          
        }
        public void AtualizarTarefa()
        {
            try
            {
                  AlteraTarefaViewModel altTarefa = HomeTLForm.getAlterarForm();
                  tarefaDAO.AtualizarTarefa((int)altTarefa.tarefaId, altTarefa.Descricao, altTarefa.ResponsavelId, altTarefa.SituacaoTarefa);
                  HomeTLForm.ApresentarMensagem("Atualizado com sucesso!");
                  LimparControles();
                  ListarTarefas();
            }
            catch (Exception ex)
            {
                HomeTLForm.ApresentarMensagemErro($"Erro ao atualizar tarefa: {ex.Message}");
                
            }
        }

        public void ConcluirTarefa()
        {
            try
            {
                TarefaViewModel tarefaSelecionadaAtual = (TarefaViewModel)HomeTLForm.dataGridViewTarefas.SelectedRows[0].DataBoundItem;
                tarefaDAO.ConcluirTarefa((int)tarefaSelecionadaAtual.Id);
                ListarTarefas();
            }
            catch (Exception ex)
            {
                HomeTLForm.ApresentarMensagemErro($"Erro ao concluir tarefa: {ex.Message}");
                
            }

        }

        public void FiltrarTarefasTechLeader(string situacao)
        {
            try
            {
                List<Tarefa> listaTarefasFiltrada = new List<Tarefa>();

                
                switch (situacao.ToLower())
                {
                    case "em andamento":
                        listaTarefasFiltrada = tarefaDAO.ListarTodasTarefas().Where(t => t.Status.Equals("Em Andamento", StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                    case "concluida":
                        listaTarefasFiltrada = tarefaDAO.ListarTodasTarefas().Where(t => t.Status.Equals("Concluida", StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                    case "abandonada":
                        listaTarefasFiltrada = tarefaDAO.ListarTodasTarefas().Where(t => t.Status.Equals("Abandonada", StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                    case "com impedimento":
                        listaTarefasFiltrada = tarefaDAO.ListarTodasTarefas().Where(t => t.Status.Equals("Com Impedimento", StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                    case "em analise":
                        listaTarefasFiltrada = tarefaDAO.ListarTodasTarefas().Where(t => t.Status.Equals("Em Analise", StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                    default:
                        listaTarefasFiltrada = tarefaDAO.ListarTodasTarefas();
                        break;
                }

                List<TarefaViewModel> listaTarefasViewModel = listaTarefasFiltrada.Select(t => new TarefaViewModel(t)).ToList();
                HomeTLForm.dataGridViewTarefas.DataSource = listaTarefasViewModel;
                HomeTLForm.setDataGridActionsVisible(true);
            }
            catch (Exception ex)
            {
                HomeTLForm.ApresentarMensagemErro($"Erro ao filtrar tarefas: {ex.Message}");
                Console.WriteLine(ex.Message);
            }
        }
        public void FiltrarTarefasDev(string situacao)
        {
            try
            {
                List<Tarefa> listaTarefasFiltrada = new List<Tarefa>();


                switch (situacao.ToLower())
                {
                    case "em andamento":
                        listaTarefasFiltrada = tarefaDAO.ObterTarefasPorUserId(HomeTLForm.usuarioAutenticado.UserId).Where(t => t.Status.Equals("Em Andamento", StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                    case "concluida":
                        listaTarefasFiltrada = tarefaDAO.ObterTarefasPorUserId(HomeTLForm.usuarioAutenticado.UserId).Where(t => t.Status.Equals("Concluida", StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                    case "abandonada":
                        listaTarefasFiltrada = tarefaDAO.ObterTarefasPorUserId(HomeTLForm.usuarioAutenticado.UserId).Where(t => t.Status.Equals("Abandonada", StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                    case "com impedimento":
                        listaTarefasFiltrada = tarefaDAO.ObterTarefasPorUserId(HomeTLForm.usuarioAutenticado.UserId).Where(t => t.Status.Equals("Com Impedimento", StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                    case "em analise":
                        listaTarefasFiltrada = tarefaDAO.ObterTarefasPorUserId(HomeTLForm.usuarioAutenticado.UserId).Where(t => t.Status.Equals("Em Analise", StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                    default:
                        listaTarefasFiltrada = tarefaDAO.ObterTarefasPorUserId(HomeTLForm.usuarioAutenticado.UserId);
                        break;
                }

                List<TarefaViewModel> listaTarefasViewModel = listaTarefasFiltrada.Select(t => new TarefaViewModel(t)).ToList();
                HomeTLForm.dataGridViewTarefas.DataSource = listaTarefasViewModel;
                HomeTLForm.setDataGridActionsVisible(true);
            }
            catch (Exception ex)
            {
                HomeTLForm.ApresentarMensagemErro($"Erro ao filtrar tarefas: {ex.Message}");
                Console.WriteLine(ex.Message);
            }
        }

        public void ConfigurarComboBox()
        {
            List<string> opcoesSituacao = new List<string>
            {
                "Em Andamento",
                "Concluida",
                "Abandonada",
                "Com Impedimento",
                "Em Analise"
            };

            HomeTLForm.comboBox2.DataSource = opcoesSituacao;
            

        }
        public void ConfigurarComboBoxAlt()
        {
            List<string> opcoesSituacao = new List<string>
            {
                "Em Andamento",
                "Abandonada",
                "Com Impedimento",
                "Em Analise"
            };

            HomeTLForm.comboBoxAltSituacao.DataSource = opcoesSituacao;

        }

        public void AplicarFiltrosTechLeader()
        {
            string situacao = HomeTLForm.comboBox2.Text;
            FiltrarTarefasTechLeader(situacao);
        }

        public void AplicarFiltrosDev()
        {
            string situacao = HomeTLForm.comboBox2.Text;
            FiltrarTarefasDev(situacao);
        }

        public void CadastroUsuario(Login usuarioAutenticado)
        {
            if (cadastroForm == null || cadastroForm.IsDisposed)
            {
                cadastroForm = new CadastroForm(usuarioAutenticado);
                cadastroForm.Show();
            }
            else
            {
                cadastroForm.BringToFront();
            }

            this.HomeTLForm.Hide();

        }

        public void NovaTarefa(Login usuarioAutenticado)
        {
          
            if (inserirTarefaForm == null || inserirTarefaForm.IsDisposed)
            {
                inserirTarefaForm = new InserirTarefaForm(usuarioAutenticado, this);
                inserirTarefaForm.Show();
            }
            else
            {
                
                inserirTarefaForm.BringToFront();
            }

            this.HomeTLForm.Hide();
        }
    

        private void LimparControles()
        {
            HomeTLForm.textBox1.Text = string.Empty;
            HomeTLForm.comboBoxResponsavel.SelectedIndex = -1;
            
        }

        public void Logout()
        {
            this.HomeTLForm.Close();
            LoginForm form2 = new LoginForm();
            form2.Show();
        }

    }
}
