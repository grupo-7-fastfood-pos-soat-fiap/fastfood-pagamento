namespace FastFoodFIAP.Application.InputModels
{
    public class PedidoInputModel
    {
        public Guid? ClienteId { get; private set; }
        public List<PedidoComboInputModel>? Combos { get; set; }

        public void SetCliente(Guid cliente_id)
        {
            ClienteId = cliente_id;
        }
    }
}
