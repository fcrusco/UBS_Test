namespace PortfolioCategorization.Models
{
    /// <summary>
    /// Interface que define uma operação de trade. Define os atributos necessários para representar uma operação financeira
    /// </summary>
    public interface ITrade
    {
        double Value { get; }
        string ClientSector { get; }
        DateTime NextPaymentDate { get; }
    }
}
