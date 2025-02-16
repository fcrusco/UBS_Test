namespace PortfolioCategorization.Models
{

    /// <summary>
    /// Implementação da interface ITrade. Implementa ITrade, armazenando os valores necessários.
    /// </summary>
    public class Trade : ITrade
    {
        public double Value { get; }
        public string ClientSector { get; }
        public DateTime NextPaymentDate { get; }

        public Trade(double value, string clientSector, DateTime nextPaymentDate)
        {
            Value = value;
            ClientSector = clientSector;
            NextPaymentDate = nextPaymentDate;
        }
    }
}
