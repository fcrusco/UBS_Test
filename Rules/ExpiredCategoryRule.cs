using PortfolioCategorization.Models;

namespace PortfolioCategorization.Rules
{
    /// <summary>
    /// Regra para categorizar operações expiradas. Cada classe implementa ICategoryRule e define sua própria lógica. 
    /// Essa regra classifica operações que a próxima data de pagamento já está vencida com mais de 30 dias
    /// </summary>
    public class ExpiredCategoryRule : ICategoryRule
    {
        public string Category => "EXPIRED";

        public bool IsMatch(ITrade trade, DateTime referenceDate)
        {
            return (referenceDate - trade.NextPaymentDate).Days > 30;
        }
    }

}
