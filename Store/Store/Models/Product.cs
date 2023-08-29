using Microsoft.AspNetCore.Mvc;
using Store.MetaData;
using System.ComponentModel.DataAnnotations.Schema;


namespace Store.Models
{
    using System.ComponentModel;
    using System.Web;

    [ModelMetadataType(typeof(ProductMetaData))]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string? Image { get; set; }
        [DisplayName("Upload Image File")]
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [ForeignKey("Seller")]
        public int sell_id { get; set; }

        public virtual Seller? Seller { get; set; }

        public virtual ICollection<Cart> Cart { get; set; } = new HashSet<Cart>();
        public virtual ICollection<ConfermCart> ConfermCart { get; set; } = new HashSet<ConfermCart>();
    }
}
