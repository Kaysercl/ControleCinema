using ControleCinema.ConsoleApp.Compartilhado;
using ControleCinema.ConsoleApp.ModuloGenero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCinema.ConsoleApp
{
    public class TelaCadastroFilme : TelaBase, ITelaCadastravel
    {

        private readonly IRepositorio<Filme> _repositorioFilme;
        private readonly Notificador _notificador;
        

        public TelaCadastroFilme(IRepositorio<Filme> repositorioFilme, Notificador notificador)
            : base("Cadastro de Funcionários")
        {
            _repositorioFilme = repositorioFilme;
            _notificador = notificador;
        }       

        public void Inserir()
        {
            MostrarTitulo("Cadastro de Filme");

            Filme novoFilme = ObterFilme();

            _repositorioFilme.Inserir(novoFilme);

            _notificador.ApresentarMensagem("Filme cadastrado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Editar()
        {
            MostrarTitulo("Editando Filme");

            bool temFilmesCadastrados = VisualizarRegistros("Pesquisando");

            if (temFilmesCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum filme cadastrado para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroFilme = ObterNumeroRegistro();

            Filme funcionarioAtualizado = ObterFilme();

            bool conseguiuEditar = _repositorioFilme.Editar(numeroFilme, funcionarioAtualizado);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Filme editado com sucesso!", TipoMensagem.Sucesso);
        }


        public void Excluir()
        {
            MostrarTitulo("Excluindo Filme");

            bool temFilmesRegistrados = VisualizarRegistros("Pesquisando");

            if (temFilmesRegistrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum funcionário cadastrado para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroFilme = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioFilme.Excluir(numeroFilme);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Funcionário excluído com sucesso1", TipoMensagem.Sucesso);
        }


        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Filmes");

            List<Filme> filmes = _repositorioFilme.SelecionarTodos();

            if (filmes.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum filme disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Filme filme in filmes)
                Console.WriteLine(filme.ToString());
                

            Console.ReadLine();

            return true;
        }

        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID do Funcionário que deseja editar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioFilme.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID do Funcionário não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }

        private Filme ObterFilme()
        {
            Console.Write("Digite o titulo do filme: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a duração do filme: ");
            string duracao = Console.ReadLine();

            Console.Write("Digite o gênero do filme: ");
            string genero = Console.ReadLine();

            return new Filme(titulo, genero, duracao);
        }

    }
}
