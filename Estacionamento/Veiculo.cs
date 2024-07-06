using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstacionamento
{
    internal abstract class Veiculo
    {
        private string Placa { get; set; }
        private string Marca { get; set; }
        private string Modelo { get; set; }
        private int TipoVeiculo { get; set; }

        public Veiculo(string placa, string marca, string modelo, int tipoVeiculo)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            TipoVeiculo = tipoVeiculo;
        }
        public string GetPlaca()
        {
            return Placa;
        }

        public int GetTipoVeiculo()
        {
            return TipoVeiculo;
        }

 
    }
}

 
