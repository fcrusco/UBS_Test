using PortfolioCategorization.Models;

namespace PortfolioCategorization.Rules
{
    /// <summary>
    /// Regra para categorizar operações de médio risco.
    /// Classifica operações com valor maior que 1.000.000 setor público como MEDIO risco
    /// </summary>
    public class MediumRiskCategoryRule : ICategoryRule
    {
        public string Category => "MEDIUMRISK";

        public bool IsMatch(ITrade trade, DateTime referenceDate)
        {
            return trade.Value > 1000000 && trade.ClientSector == "Public";
        }
    }
}
