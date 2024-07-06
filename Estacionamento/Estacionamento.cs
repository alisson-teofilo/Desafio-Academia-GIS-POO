using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstacionamento
{
    internal class Estacionamento
    {
        const int ValorHoraCarro = 7;

        const double ValorHoraMoto = 5;

        List<Veiculo> veiculos;

        public Estacionamento() {

            this.veiculos = new List<Veiculo>();
        }

        public void EstacionarVeiculo(Veiculo veiculo)
        {
            veiculos.Add(veiculo);
        }

        public void RemoverVeiculo(Veiculo veiculo)
        {
            veiculos.Remove(veiculo);
        }

        public double CalcularEstadia(Carro carro, int qtdHorasEstacionado, int tipoVeiculo)
        {
            return ValorHoraCarro * qtdHorasEstacionado;
        }

        public double CalcularEstadia(Moto moto, int qtdHorasEstacionado, int tipoVeiculo)
        {
            return ValorHoraMoto * qtdHorasEstacionado;
        }

        public List<Veiculo> ListaVeiculos()
        {
            return veiculos;
        }


    }
}
