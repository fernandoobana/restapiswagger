namespace WebApi_Swagger
{
    /// <summary>
    /// Entidade produto.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// ID do produto.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Valor do custo de venda do produto.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Descrição do produto.
        /// </summary>
        public string Description { get; set; }
    }
}
