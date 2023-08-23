using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Store.MetaData;

namespace Store.Models
{
    [ModelMetadataType(typeof(CustomerMetaData))]
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfPassword { get; set; }

        public virtual ICollection<Cart> Cart { get; set; } = new HashSet<Cart>();
        public virtual ICollection<ConfermCart> ConfermCart { get; set; } = new HashSet<ConfermCart>();
    }
}
