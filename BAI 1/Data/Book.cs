using System.ComponentModel.DataAnnotations;

namespace BAI_1.Data
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Quantity { get; set; }
        public double Price { get; set; }

    }
}
