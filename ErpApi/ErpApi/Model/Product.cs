using System.ComponentModel.DataAnnotations.Schema;

namespace ErpApi.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal quntaity { get; set; }

        public decimal price { get; set; }
        public decimal Total { get; set;}

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

    }
}
