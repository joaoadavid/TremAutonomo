using System;
using System.Collections.Generic;

namespace TremAutonomoApp
{
    public class TremAutonomo
    {
        private int posicaoAtual;
        private int movimentosConsecutivos;
        private string ultimaDirecao;
        private const int LimiteMovimentos = 50;
        private const int LimiteConsecutivos = 20;
        private int movimentosTotais;

        public TremAutonomo()
        {
            posicaoAtual = 0;
            movimentosConsecutivos = 0;
            ultimaDirecao = string.Empty;
            movimentosTotais = 0;
        }

        public List<string> GerarMovimentosAleatorios()
        {
            var comandos = new List<string>();
            var random = new Random();

            while (movimentosTotais < LimiteMovimentos)
            {
                string comando;
               
                if (movimentosConsecutivos >= LimiteConsecutivos)
                {
                    comando = ultimaDirecao == "DIREITA" ? "ESQUERDA" : "DIREITA";
                    movimentosConsecutivos = 1;
                }
                else
                {
                    
                    comando = random.Next(0, 2) == 0 ? "DIREITA" : "ESQUERDA";
                  
                    if (comando == ultimaDirecao)
                    {
                        movimentosConsecutivos++;
                    }
                    else
                    {
                        movimentosConsecutivos = 1;
                    }
                }

                ultimaDirecao = comando;
                comandos.Add(comando);
                movimentosTotais++;
            }

            return comandos;
        }

        public int ExecutarComandos(List<string> comandos)
        {
            posicaoAtual = 0;
            movimentosTotais = 0;

            foreach (var comando in comandos)
            {
                if (movimentosTotais >= LimiteMovimentos)
                {
                    Console.WriteLine("O trem atingiu o limite de movimentos e parou.");
                    break;
                }

                if (comando == "DIREITA")
                {
                    posicaoAtual++;
                }
                else if (comando == "ESQUERDA")
                {
                    posicaoAtual--;
                }

                movimentosTotais++;
            }

            return posicaoAtual;
        }
    }
}
