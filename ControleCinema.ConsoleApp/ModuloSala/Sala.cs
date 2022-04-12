using ControleCinema.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleCinema.ConsoleApp.ModuloSala
{
    public class Sala : EntidadeBase
    {

        private readonly string _numerosala;
        private readonly string _numerodepoltronas;
        

        public string Nome { get => _numerosala; }

        public Sala (string numerosala, string numerodepoltronas)
        {
            _numerosala = numerosala;
            _numerodepoltronas = numerodepoltronas;            
        }

        public override string ToString()
        {
            return "Id: " + _numerosala + Environment.NewLine +
                "Nome: " + _numerodepoltronas + Environment.NewLine;
        }

    }
}
