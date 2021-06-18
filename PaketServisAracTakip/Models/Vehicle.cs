using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PaketServisAracTakip.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        [Key]
        [Display(Name = "Araç No")]
        public int Id { get; set; }
        [Display(Name = "İsim")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [MaxLength(50, ErrorMessage = "İsim 50 karakteri geçemez.")]
        public String Name { get; set; }
        [Display(Name = "Ürünler")]
        public String Items { get; set; }
        [Display(Name = "Adres")]
        public String Address { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
