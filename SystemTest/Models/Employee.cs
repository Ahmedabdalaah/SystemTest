using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SystemTest.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("اسم الموظف")]
        public string Name { get; set; }
        [Required]
        [DisplayName("الايميل")]
        public string Email { get; set; }
        [Required]
        [DisplayName("رقم الهاتف")]
        public string Phone { get; set; }
        public ICollection<Order>? Order { get; set; }
        [ForeignKey("Category")]
        [DisplayName("  القسم التابع له")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
