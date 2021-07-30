using CursoEFCore.ValueObject;

namespace CursoEFCore.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string CodigoDeBarras { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public bool Ativo { get; set; }
    }
}