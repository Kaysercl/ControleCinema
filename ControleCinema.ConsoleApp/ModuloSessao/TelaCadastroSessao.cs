using ControleCinema.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCinema.ConsoleApp.ModuloSessao
{
    public class TelaCadastroSessao : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Sessao> _repositorioSessao;
        private readonly Notificador _notificador;
        private readonly TelaCadastroFilme telaCadastroFilme;
        private readonly IRepositorio<Filme> _repositorioFilme;

        public TelaCadastroSessao(IRepositorio<Sessao> repositorioSessao, Notificador notificador, IRepositorio<Filme> repositorioFilme)
            : base("Cadastro de Sessões")
        {
            _repositorioSessao = repositorioSessao;
            _notificador = notificador;
            _repositorioFilme = repositorioFilme;
        }


        public void Inserir()
        {
            MostrarTitulo("Cadastro de Sessões");

            Sessao novaSessao = ObterSessao();

            _repositorioSessao.Inserir(novaSessao);

            _notificador.ApresentarMensagem("Sessão cadastrada com sucesso!", TipoMensagem.Sucesso);
        }

        public void Editar()
        {
            MostrarTitulo("Editando Sessão");

            bool temSessoesCadastradas = VisualizarRegistros("Pesquisando");

            if (temSessoesCadastradas == false)
            {
                _notificador.ApresentarMensagem("Nenhuma sessão cadastrada para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroSessao = ObterNumeroRegistro();

            Sessao sessaoAtualizada = ObterSessao();

            bool conseguiuEditar = _repositorioSessao.Editar(numeroSessao, sessaoAtualizada);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Sessão editada com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Sessão");

            bool temSessõesRegistradas = VisualizarRegistros("Pesquisando");

            if (temSessõesRegistradas == false)
            {
                _notificador.ApresentarMensagem("Nenhuma sessão cadastrada para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroSessao = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioSessao.Excluir(numeroSessao);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Sessão excluída com sucesso1", TipoMensagem.Sucesso);
        }


        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Funcionários");

            List<Sessao> sessoes = _repositorioSessao.SelecionarTodos();

            if (sessoes.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhuma sessão disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Sessao sessao in sessoes)
                Console.WriteLine(sessao.ToString());

            Console.ReadLine();

            return true;
        }


        private Sessao ObterSessao()
        {
            Console.WriteLine("Digite o ID da sessão: ");
            string iddasessao = Console.ReadLine();

            Filme filmedasessao = ObterFilme();

            Console.WriteLine("Digite o horário da sessão: ");
            

            return new Sessao(iddasessao);
        }

        private Filme ObterFilme()
        {
            bool temFilmesDisponiveis = telaCadastroFilme.VisualizarRegistros("Pesquisando");

            if (!temFilmesDisponiveis)
            {
                _notificador.ApresentarMensagem("Não há nenhum filme disponível para cadastrar. ", TipoMensagem.Atencao);
                return null;
            }

            Console.Write("Digite o titulo do filme que será exibido nesta sessão ");
            int idFilme = Convert.ToInt32(Console.ReadLine());

            

            Console.WriteLine();

            Filme filmeSelecionado = _repositorioFilme.SelecionarRegistro(idFilme);

            return filmeSelecionado;
        }



            public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID da sessão que deseja editar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioSessao.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID da sessão não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }


    }

}
