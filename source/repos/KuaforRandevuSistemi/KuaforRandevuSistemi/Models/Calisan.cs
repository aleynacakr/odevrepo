using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KuaforRandevuSistemi.Models
{
    public class Calisan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string AdSoyad { get; set; }

        [StringLength(100)]
        public string UzmanlikAlani { get; set; }

        [Required]
        public string UygunlukSaatleri { get; set; }

        [ForeignKey("Salon")]
        public int SalonId { get; set; }
        public Salon Salon { get; set; }
    }
}
