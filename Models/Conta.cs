namespace ContasAPI.Models {
    public class Conta {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required decimal ValorOriginal { get; set; }
        public required DateTime DataVencimento { get; set; }
        public required DateTime DataPagamento { get; set; }
        public decimal ValorCorrigido { get; set; }
        public int DiasAtraso { get; set; }
    }
}
