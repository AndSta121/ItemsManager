using System.ComponentModel.DataAnnotations;

namespace ItemsManager.Models.Domain
{
    public class ItemModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public double Price { get; set; }
    }

}
