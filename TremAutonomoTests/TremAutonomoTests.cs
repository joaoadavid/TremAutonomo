using System;
using System.Collections.Generic;
using Xunit;
using TremAutonomoApp;

namespace TremAutonomoTests
{
    public class TremAutonomoTests
    {
        [Fact]
        public void TesteMovimentoDireita()
        {
            // Arrange
            var trem = new TremAutonomo();
            var comandos = new List<string> { "DIREITA", "DIREITA" };

            // Act
            int posicaoFinal = trem.ExecutarComandos(comandos);

            // Assert
            Assert.Equal(2, posicaoFinal);
        }

        [Fact]
        public void TesteMovimentoEsquerda()
        {
            // Arrange
            var trem = new TremAutonomo();
            var comandos = new List<string> { "ESQUERDA" };

            // Act
            int posicaoFinal = trem.ExecutarComandos(comandos);

            // Assert
            Assert.Equal(-1, posicaoFinal);
        }

        [Fact]
        public void TesteLimiteDeMovimentosAleatorios()
        {
            // Arrange
            var trem = new TremAutonomo();

            // Act
            List<string> comandos = trem.GerarMovimentosAleatorios();
            int posicaoFinal = trem.ExecutarComandos(comandos);

            // Assert
            Assert.True(comandos.Count <= 50, "A lista de comandos não deve exceder 50 movimentos.");
            Assert.True(Math.Abs(posicaoFinal) <= 50, "A posição final não deve exceder 50 posições absolutas.");
        }

        [Fact]
        public void TesteLimiteDeMovimentosConsecutivosAleatorios()
        {
            // Arrange
            var trem = new TremAutonomo();

            // Act
            List<string> comandos = trem.GerarMovimentosAleatorios();
            int movimentosConsecutivos = 1;

            for (int i = 1; i < comandos.Count; i++)
            {
                if (comandos[i] == comandos[i - 1])
                {
                    movimentosConsecutivos++;
                }
                else
                {
                    movimentosConsecutivos = 1;
                }

                // Assert
                Assert.True(movimentosConsecutivos <= 20, "O trem não deve fazer mais de 20 movimentos consecutivos na mesma direção.");
            }
        }

        [Fact]
        public void TesteGerarMovimentosAleatorios()
        {
            // Arrange
            var trem = new TremAutonomo();

            // Act
            List<string> comandos = trem.GerarMovimentosAleatorios();

            // Assert
            Assert.True(comandos.Count <= 50, "O trem não deve gerar mais de 50 movimentos.");

            int movimentosConsecutivos = 1;
            for (int i = 1; i < comandos.Count; i++)
            {
                if (comandos[i] == comandos[i - 1])
                {
                    movimentosConsecutivos++;
                }
                else
                {
                    movimentosConsecutivos = 1;
                }

                Assert.True(movimentosConsecutivos <= 20, "O trem não deve fazer mais de 20 movimentos consecutivos na mesma direção.");
            }
        }
    }
}
