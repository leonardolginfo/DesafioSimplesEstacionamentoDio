using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstacionamento.Models
{
    internal class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<string> veiculos = new List<string>();
        bool estaVazio = false;

        public Estacionamento( decimal precoInicial, decimal precoPorHora )
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo( )
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            var placa = Console.ReadLine();
            if (!string.IsNullOrEmpty(placa))
            {
                veiculos.Add(placa.ToUpper());
            }
            else
            {
                Console.WriteLine("Placa não pode ser vazio");
            }
        }

        public void RemoverVeiculo( )
        {
            VerificaSeVazio();

            if (!estaVazio)
            {

                Console.WriteLine("Digite a placa do veículo para remover:");
                var placa = Console.ReadLine();

                if (!string.IsNullOrEmpty(placa))
                {
                    //   Console.WriteLine("Digite a placa do veículo para remover:");
                    bool contemPlaca = veiculos.Any(x => x.ToUpper() == placa.ToUpper()); 
                    if (contemPlaca)
                    {
                        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                        int horas = Convert.ToInt32(Console.ReadLine());
                        var valorTotal = (precoInicial) + (precoPorHora * horas);
                        veiculos.Remove(placa.ToUpper());
                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                    }
                    else
                    {
                        Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                    }
                }
            }
        }
        public void VerificaSeVazio( )
        {
            if (!veiculos.Any())
            {
                Console.WriteLine("Não há veículos estacionados.");
                estaVazio = true;
            }
            else { estaVazio = false; }
        }
        public void ListarVeiculos( )
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string placa in veiculos)
                {
                    Console.WriteLine(placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}

