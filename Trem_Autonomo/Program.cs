// Arquivo: Program.cs

using System;
using System.Collections.Generic;
using TremAutonomoApp;

namespace TremAutonomoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TremAutonomo trem = new TremAutonomo();

            // Gerar movimentos aleatórios que respeitam as restrições
            List<string> movimentosAleatorios = trem.GerarMovimentosAleatorios();

            Console.WriteLine("Comandos Gerados:");
            Console.WriteLine(string.Join(", ", movimentosAleatorios));

            // Executar os comandos gerados
            int posicaoFinal = trem.ExecutarComandos(movimentosAleatorios);
            Console.WriteLine($"Posição Final do Trem: {posicaoFinal}");
        }
    }

}
