using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImageuploadApi.Models.Domain
{
    public class Productsimg
    {
        public int Id { get; set; }
        [Required]
        public string? ProductName { get; set; }
        public string? ProductImage { get; set; }
        [NotMapped]
        public IFormFile? Imagefile { get; set; }
    }
}
