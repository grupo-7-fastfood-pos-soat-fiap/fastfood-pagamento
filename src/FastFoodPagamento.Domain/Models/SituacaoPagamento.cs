using GenericPack.Domain;

namespace FastFoodPagamento.Domain.Models
{
    public partial class SituacaoPagamento:IAggregateRoot
    {
        public int Id { get; private set; }
        public string Nome { get; private set; } = "";

        private SituacaoPagamento() { }

        public SituacaoPagamento(int id, string nome){
            Id = id;
            Nome = nome;         
        }        
    }
}
