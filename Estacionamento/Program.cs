// See https://aka.ms/new-console-template for more information



using AppEstacionamento;

internal class Program
{
    private static void Main(string[] args)
    {
        Veiculo veiculoRetirar = null;
        Moto moto = null;
        Carro carro = null;

        string opcaoMenu;

        Estacionamento estacionamento = new Estacionamento();

        do
        {
            // Exibe opções do menu
            ExibirMenu();

            opcaoMenu = Console.ReadLine();

            switch (opcaoMenu)
            {
                case "1":

                    // Método para entradada de veículos
                    string[] dadosVeiculo = new string[3];

                    Console.Clear();
                    Console.WriteLine("Entrada de veículo!");
                    Console.WriteLine("Digite 1 para Moto e 2 para Carro");
                    string veiculoEscolhido = Console.ReadLine();

                    RegistrarEntradaVeiculos(dadosVeiculo, veiculoEscolhido);

                    break;

                case "2":

                    // Método para saída de veículos
                    RegistrarSaidaVeiculos();

                    break;

                case "3":

                    // Finaliza o programa
                    Console.WriteLine("Finaliza programa");
                    break;

                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }

            //Console.Clear();
        } while (opcaoMenu != "3");
        Console.WriteLine("Programa Finalizado!");

        /*
         * Métodos do sistema de estacionamento
         */

        void ExibirMenu()
        {
            Console.WriteLine("Bem vindo ao estacionamento Guardado Manco");
            Console.WriteLine("Digite uma opção a seguir: ");
            Console.WriteLine("");
            Console.WriteLine("1 - Entrada de veículo");
            Console.WriteLine("2 - Saída de veículo");
            Console.WriteLine("3 - Finalizar programa");
        }

        void RegistrarEntradaVeiculos(string[] dadosVeiculo, string veiculoEscolhido)
        {
            if (veiculoEscolhido.Equals("1"))
            {
                RegistrarEntradaMoto(dadosVeiculo);
            }

            else if (veiculoEscolhido.Equals("2"))
            {
                RegistrarEntradaCarro(dadosVeiculo);
            }
            else
            {
                Console.WriteLine("Opção inválida!");
                LimparConsole();
            }
        }

        void RegistrarEntradaMoto(string[] dadosVeiculo)
        {
            const int tipoVeiculo = 1;
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    Console.Write("Digite a placa da moto: ");
                    dadosVeiculo[0] = Console.ReadLine();
                }
                else if (i == 1)
                {
                    Console.Write("Digite a marca da moto: ");
                    dadosVeiculo[1] = Console.ReadLine();
                }
                else
                {
                    Console.Write("Digite o modelo da moto: ");
                    dadosVeiculo[2] = Console.ReadLine();
                }
            }

            moto = new Moto(dadosVeiculo[0], dadosVeiculo[1], dadosVeiculo[2], tipoVeiculo);

            estacionamento.EstacionarVeiculo(moto);

            Console.WriteLine("Veículo Estacionado!");
            LimparConsole();
        }

        void RegistrarEntradaCarro(string[] dadosVeiculo)
        {
            const int tipoVeiculo = 2;

            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    Console.Write("Digite a placa do carro: ");
                    dadosVeiculo[0] = Console.ReadLine();
                }
                else if (i == 1)
                {
                    Console.Write("Digite o marca do carro: ");
                    dadosVeiculo[1] = Console.ReadLine();
                }
                else
                {
                    Console.Write("Digite o modelo do carro: ");
                    dadosVeiculo[2] = Console.ReadLine();
                }
            }

            carro = new Carro(dadosVeiculo[0], dadosVeiculo[1], dadosVeiculo[2], tipoVeiculo);

            estacionamento.EstacionarVeiculo(carro);

            Console.WriteLine("Veículo Estacionado!");
            LimparConsole();
        }

        void RegistrarSaidaVeiculos()
        {
            Console.Clear();

            int tipoVeiculo = 0;
            double valorTotal = 0;
            string qtdHoras = null;

            if (moto == null && carro == null)
            {
                Console.WriteLine("Nenhum veículo registrado. Registre a entrada de um veículo primeiro.");
            }
            else
            {
                Console.WriteLine("Saída de veículo");
                Console.WriteLine("Informe a placa do veículo, em seguida, a quantidade de horas estacionado. ");

                Console.Write("Informe a placa do veículo: ");
                string placaVeiculo = Console.ReadLine();
                Console.WriteLine("");

                if (moto != null || carro != null)
                {
                    // Encontra veículo a partir da placa
                    int veiculoLocalido = LocalizarVeiculo(placaVeiculo);

                    if (veiculoLocalido != 0)
                    {
                        Console.Write("Informe a quantidade de horas estacionado: ");
                        qtdHoras = Console.ReadLine();

                        if (veiculoLocalido == 1)
                        {
                            valorTotal = estacionamento.CalcularEstadia(moto, int.Parse(qtdHoras), tipoVeiculo);
                        }
                        else
                        {
                            valorTotal = estacionamento.CalcularEstadia(carro, int.Parse(qtdHoras), tipoVeiculo);
                        }

                        Console.WriteLine("Total a ser pago R$: " + valorTotal);
                        Console.Write("Digite o valor a ser debitado da conta:");

                        double valorPago = int.Parse(Console.ReadLine());

                        if (valorPago >= valorTotal)
                        {
                            Console.WriteLine("Pagamento realizado. Volte sempre!");
                            Console.WriteLine("");
                        }

                        Console.WriteLine("Saída de veículo efetuada com sucesso!");
                        estacionamento.RemoverVeiculo(veiculoRetirar);
                         LimparConsole();

                    }
                    else
                    {
                        Console.WriteLine("VEÍCULO NÃO LOCALIZADO!");
                        LimparConsole();
                    }
                }
                else
                {
                    Console.WriteLine("O estacionamento está vazio!");
                    LimparConsole();
                }
            }

            int LocalizarVeiculo(string placaVeiculo)
            {
                List<Veiculo> listaVeiculos = estacionamento.ListaVeiculos();

                foreach (var veiculo in listaVeiculos)
                {
                    if (placaVeiculo.Equals(veiculo.GetPlaca()))
                    {
                        tipoVeiculo = veiculo.GetTipoVeiculo();
                        veiculoRetirar = veiculo;
                    }
                }
                return tipoVeiculo;
            }

        }
        void LimparConsole()
        {
            Console.WriteLine("Aperte ENTER para continuar...");
            string continuar = Console.ReadLine();
            Console.Clear();
        }

    }
}