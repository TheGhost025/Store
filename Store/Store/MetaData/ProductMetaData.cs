using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.MetaData
{
    public class ProductMetaData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Remote("CheckIntNegative", "Product", ErrorMessage = "Don't Enter Zero or Negative")]
        public int Quantity { get; set; }
        [Remote("CheckDoubleNegative", "Product", ErrorMessage = "Don't Enter Zero or Negative")]
        public double Price { get; set; }
        public string? Image { get; set; }
        public int sell_id { get; set; }
    }
}
