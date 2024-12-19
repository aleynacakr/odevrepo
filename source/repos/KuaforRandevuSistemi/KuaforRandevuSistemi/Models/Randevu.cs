using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KuaforRandevuSistemi.Models
{
    public class Randevu
    {
        [Key]
        public int Id { get; set; } // Benzersiz ID

        [Required(ErrorMessage = "Çalışan seçimi zorunludur.")]
        [ForeignKey("Calisan")]
        public int CalisanId { get; set; }
        public Calisan Calisan { get; set; } // Randevunun bağlı olduğu çalışan

        [Required(ErrorMessage = "İşlem bilgisi zorunludur.")]
        [StringLength(100, ErrorMessage = "İşlem adı en fazla 100 karakter olabilir.")]
        [Display(Name = "İşlem Adı")]
        public string Islem { get; set; } // Örn: "Saç Kesimi"

        [Required(ErrorMessage = "Tarih ve saat seçimi zorunludur.")]
        [Display(Name = "Randevu Tarihi ve Saati")]
        public DateTime Tarih { get; set; } // Randevu tarihi ve saati

        [Required(ErrorMessage = "Ücret bilgisi zorunludur.")]
        [Range(0, 10000, ErrorMessage = "Ücret 0 ile 10.000 arasında olmalıdır.")]
        [Display(Name = "Ücret (₺)")]
        public double Ucret { get; set; } // İşlemin ücreti

        [Required(ErrorMessage = "Müşteri adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Müşteri adı en fazla 100 karakter olabilir.")]
        [Display(Name = "Müşteri Adı")]
        public string MusteriAdi { get; set; } // Randevuyu alan kişinin adı
    }
}
