using PortfolioCategorization.Models;
using PortfolioCategorization.Services;
using System.Globalization;


namespace PortfolioCategorization
{

    class Program
    {
        /// <summary>
        /// Método principal da aplicação. Lê a entrada, processa e categoriza as operações.
        /// </summary>
        static void Main()
        {
            try
            {
                var culture = CultureInfo.InvariantCulture;
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Categorização das Operações do Portifólio");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Digite a data de referência (MM/dd/yyyy):");
                DateTime referenceDate = DateTime.ParseExact(Console.ReadLine(), "MM/dd/yyyy", culture);

                Console.WriteLine("Digite o número de operações:");
                if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
                {
                    Console.WriteLine("Número de operações inválido.");
                    return;
                }

                List<ITrade> trades = new();

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Digite os detalhes da operação {i + 1} (Exemplo: 2000000 Private 12/29/2025):");
                    string[] input = Console.ReadLine().Split(' ');

                    if (input.Length != 3 ||
                        !double.TryParse(input[0], NumberStyles.Any, culture, out double value) ||
                        !DateTime.TryParseExact(input[2], "MM/dd/yyyy", culture, DateTimeStyles.None, out DateTime nextPaymentDate))
                    {
                        Console.WriteLine("Entrada inválida. Certifique-se de seguir o formato correto.");
                        return;
                    }

                    string sector = input[1];

                    trades.Add(new Trade(value, sector, nextPaymentDate));
                }

                PortfolioCategorizer categorizer = new();
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Categorias das operações:");
                Console.WriteLine("---------------------------------------------");
                foreach (var trade in trades)
                {
                    Console.WriteLine(categorizer.CategorizeTrade(trade, referenceDate));
                }
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
        }
    }
}
