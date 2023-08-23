using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Store.MetaData
{
    public class CustomerMetaData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [RegularExpression("^01[0125][0-9]{8}$", ErrorMessage = "Invaild Phone Number")]
        public string Phone { get; set; }
        [Remote("UnqiueCustomerEmail", "User", ErrorMessage = "Choose anther Email")]
        [RegularExpression("^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,})$", ErrorMessage = "Invaild Email")]
        public string Email { get; set; }
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\\]*+\\\\/|!\\\"£$%^&*()#[@~'?><,.=_-]).{8,}$", ErrorMessage = "Password must be between 8 and 20 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        public string Password { get; set; }
        [Remote("ConfermPassword", "User", ErrorMessage = "Password is not the same", AdditionalFields = "Password")]
        [DisplayName("Conferm Password")]
        public string ConfPassword { get; set; }
    }
}
