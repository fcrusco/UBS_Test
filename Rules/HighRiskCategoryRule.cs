using PortfolioCategorization.Models;

namespace PortfolioCategorization.Rules
{
    /// <summary>
    /// Regra para categorizar operações de alto risco. 
    /// Classifica operações com valor maior que 1.000.000 setor privado como ALTO risco.
    /// </summary>
    public class HighRiskCategoryRule : ICategoryRule
    {
        public string Category => "HIGHRISK";

        public bool IsMatch(ITrade trade, DateTime referenceDate)
        {
            return trade.Value > 1000000 && trade.ClientSector == "Private";
        }
    }

}
