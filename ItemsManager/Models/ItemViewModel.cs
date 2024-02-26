using System.ComponentModel.DataAnnotations;

namespace ItemsManager.Models
{
    public class ItemViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
