using System.ComponentModel.DataAnnotations;

namespace KuaforRandevuSistemi.Models
{
    public class Salon
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Ad { get; set; }

        [StringLength(255)]
        public string Adres { get; set; }

        [Required]
        public string CalismaSaatleri { get; set; } // Örn: "09:00 - 19:00"

        public ICollection<Calisan> Calisanlar { get; set; } // İlişki: Bir salonun çalışanları
    }
}
