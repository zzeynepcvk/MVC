using System.ComponentModel.DataAnnotations;

namespace BtkAkademi.Models
{
    public class Candidate
    {

        [Required(ErrorMessage = "doldurulması zorunlu alan")]
        public String? Email { get; set; } = String.Empty;

        [Required(ErrorMessage = "doldurulması zorunlu alan")]
        public String? FirstName { get; set; } = String.Empty;

        [Required(ErrorMessage = "doldurulması zorunlu alan")]

        public String? LastName { get; set; } = String.Empty;


        public String? FullName => $"{FirstName} {LastName?.ToUpper()}";

        public int? Age { get; set; }

        public String? SelectedCourse { get; set; } = String.Empty;
        public DateTime ApplyAt { get; set; }

        public Candidate()
        {
            ApplyAt = DateTime.Now;
           
        }
    }
}

/* ? burada kontrol etme işlevi taşır 
Eğer içerisinde değer varsa işlem yap yoksa yapma demek.*/    