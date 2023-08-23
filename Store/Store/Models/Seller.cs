using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Store.MetaData;

namespace Store.Models
{
    [ModelMetadataType(typeof(SellerMetaData))]
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfPassword { get; set; }

        public virtual ICollection<Product> Product { get; set; } = new HashSet<Product>();
    }
}
