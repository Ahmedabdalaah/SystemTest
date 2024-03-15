using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemTest.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("اسم الطلب")]
        public string Name { get; set; }
        [Required]
        [DisplayName("وصف الطلب")]
        public string Description { get; set; }
        [ForeignKey("employee")]
        [DisplayName("كود الموظف المسئول")]
        public int EmployeeId { get; set; }
        public Employee? employee { get; set; }
    }
}
