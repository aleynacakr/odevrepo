using System.ComponentModel.DataAnnotations;

namespace KuaforRandevuSistemi.Models
{
    public class Kullanici
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string AdSoyad { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Sifre { get; set; } // Kullanıcı şifresi

        public bool IsAdmin { get; set; } // Admin yetkisi olup olmadığını belirtir
    }
}
