using System.ComponentModel.DataAnnotations;

namespace DesingPatterns_AspNet.Models.ViewsModels
{
    public class FormViewModel
    {
        [Required]
        [Display(Name="Nombre")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Estilo")]
        public string Style { get; set; }
        [Display(Name = "Marca")]
        public Guid? BrandId { get; set; }
        [Display(Name = "Otra Marca")]
        public string OtherBrand { get; set; }
    }
}
