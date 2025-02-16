using PortfolioCategorization.Models;

namespace PortfolioCategorization.Rules
{
    /// <summary>
    /// Interface para definir regras de categorização de operações. Define um contrato para as regras de categorização
    /// </summary>
    public interface ICategoryRule
    {
        string Category { get; }
        bool IsMatch(ITrade trade, DateTime referenceDate);
    }

}
