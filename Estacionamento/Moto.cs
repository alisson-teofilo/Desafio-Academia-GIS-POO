using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstacionamento
{
    internal class Moto : Veiculo
    {
        public Moto(string placa, string marca, string modelo, int tipoVeiculo)
            : base(placa, marca, modelo, tipoVeiculo) { }
    }
}