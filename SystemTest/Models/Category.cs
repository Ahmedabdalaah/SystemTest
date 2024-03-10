using System.ComponentModel.DataAnnotations;

namespace SystemTest.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
