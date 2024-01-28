namespace FastFoodPagamento.Infra.MercadoPago.Models
{
    public class Requisicao
    {
        public string external_reference { get; set; } = "";
        public string title { get; set; } = "";
        public string notification_url { get; set; } = "";
        public decimal total_amount { get; set; }
        public string description { get; set; } = "";
        public CashOut cash_out { get; set; }= new CashOut();
    }
}
