using PortfolioCategorization.Models;
using PortfolioCategorization.Rules;

namespace PortfolioCategorization.Services
{

    /// <summary>
    /// Classe responsável por categorizar operações com base em regras definidas.
    /// </summary>
    public class PortfolioCategorizer
    {
        private readonly List<ICategoryRule> _rules;

        public PortfolioCategorizer()
        {
            _rules = new List<ICategoryRule>
            {
                new ExpiredCategoryRule(),
                new HighRiskCategoryRule(),
                new MediumRiskCategoryRule()
            };
        }

        /// <summary>
        /// Classifica uma operação com base nas regras de categorização.
        /// </summary>
        /// <param name="trade">Operação a ser categorizada.</param>
        /// <param name="referenceDate">Data de referência para classificação.</param>
        /// <returns>Categoria correspondente à operação.</returns>
        public string CategorizeTrade(ITrade trade, DateTime referenceDate)
        {
            return _rules.FirstOrDefault(rule => rule.IsMatch(trade, referenceDate))?.Category ?? "UNCATEGORIZED";
        }
    }
}
