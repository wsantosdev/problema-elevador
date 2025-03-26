using System.Diagnostics;

namespace ProblemaDoElevador
{
    internal partial class Program
    {
        public static int ObterNumeroDeViagens(int[] pesos)
        {
            const int pesoMaximo = 100;
            var viagens = 0;

            int CalcularNumeroDeViagens(int[] pesos)
            {
                if (pesos.Length == 0) return viagens;

                int embarques = 0;
                int pesoAtual = 0;

                List<int> restantes = new(pesos.Length);

                for (int i = 0; i < pesos.Length; i++)
                {
                    if (pesos[i] > pesoMaximo)
                        continue;

                    if (pesoAtual + pesos[i] <= pesoMaximo && embarques < 2)
                    {
                        embarques++;
                        pesoAtual += pesos[i];
                    }
                    else
                    {
                        restantes.Add(pesos[i]);
                    }
                }

                if (embarques > 0)
                    viagens++;

                return CalcularNumeroDeViagens([.. restantes]);
            }
            
            return CalcularNumeroDeViagens([.. pesos]);
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ObterNumeroDeViagens([100]));
            Console.WriteLine(ObterNumeroDeViagens([120]));
            Console.WriteLine(ObterNumeroDeViagens([1, 120]));
            Console.WriteLine(ObterNumeroDeViagens([12, 60, 77, 57, 45, 1]));
            Console.WriteLine(ObterNumeroDeViagens([12, 60, 77, 57, 45, 45, 50]));
        }
    }
}
