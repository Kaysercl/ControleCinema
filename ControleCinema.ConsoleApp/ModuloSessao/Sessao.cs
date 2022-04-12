using ControleCinema.ConsoleApp.Compartilhado;
using ControleCinema.ConsoleApp.ModuloSala;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCinema.ConsoleApp.ModuloSessao
{
    public class Sessao : EntidadeBase
    {
        private readonly string _iddasessao;
        private readonly Filme _filmedasessao;
        private readonly DateTime _horariodasessao;
        private readonly Sala _saladasessao;
       

        public string Nome { get => _iddasessao; }

        public Sessao(string iddasessao, Filme filmedasessao, DateTime horariodasessao, Sala saladasessao)
        {
            _iddasessao = iddasessao;
            _filmedasessao = filmedasessao;
            _horariodasessao = horariodasessao;
            _saladasessao = saladasessao;
        }

        public Sessao(string iddasessao)
        {
            this._iddasessao = iddasessao;
        }

        public override string ToString()
        {
            return "Id: " + _iddasessao + Environment.NewLine +
                "Filme: " + _filmedasessao + Environment.NewLine +
                "Horário " + _horariodasessao + Environment.NewLine +
                "Sala " + _saladasessao + Environment.NewLine;
        }
    }
}
