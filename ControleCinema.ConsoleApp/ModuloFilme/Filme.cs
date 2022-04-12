using ControleCinema.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCinema.ConsoleApp
{
    public class Filme : EntidadeBase
    {
        private readonly string _titulo;
        private readonly string _duracao;
        private readonly string _genero;
        

        public string Titulo { get => _titulo; }

        public Filme(string titulo, string duracao, string genero)
        {
            _titulo = titulo;
            _duracao = duracao;
            _genero = genero;
        }

        public override string ToString()
        {
            return "Titulo: " + _titulo + Environment.NewLine +
                "Duração: " + _duracao + Environment.NewLine+
                "Genero: " + _genero + Environment.NewLine;
        }
    }
}
