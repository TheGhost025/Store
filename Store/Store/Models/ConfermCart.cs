using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models
{
    public class ConfermCart
    {
        public int Id { get; set; }
        [ForeignKey("Customer")]
        public int cust_id { get; set; }
        [ForeignKey("Product")]
        public int prod_id { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
