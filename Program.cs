namespace ProblemaDoElevador
{
    internal partial class Program
    {
        private static int _viagens = 0;

        public static int ObterNumeroDeViagens(int[] pesos)
        {
            if (pesos.Length == 0) return _viagens;

            const int pesoMaximo = 100;

            int embarques = 0;
            int pesoAtual = 0;
            List<int> restantes = new(pesos.Length);

            for (int i = 0; i < pesos.Length; i++)
            {
                if (pesoAtual + pesos[i] <= pesoMaximo && embarques < 2)
                {
                    embarques++;
                    pesoAtual += pesos[i];
                }
                else
                {
                    restantes.Add(pesos[i]);
                }

                if (pesos[i] > pesoMaximo)
                    return 0;
            }

            if (embarques > 0)
                _viagens++;

            return ObterNumeroDeViagens([.. restantes]);
        }

        public static void Teste()
        {
            _viagens = 0;
            Console.WriteLine(ObterNumeroDeViagens([12, 60, 77, 57, 45, 1]));
            _viagens = 0;
            Console.WriteLine(ObterNumeroDeViagens([100]));
            _viagens = 0;
            Console.WriteLine(ObterNumeroDeViagens([120]));
            _viagens = 0;
            Console.WriteLine(ObterNumeroDeViagens([1, 100]));
            _viagens = 0;
            Console.WriteLine(ObterNumeroDeViagens([12, 60, 77, 57, 45, 45]));
        }

        static void Main(string[] args)
        {
            Teste();
        }
    }
}
