using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PaketServisAracTakip.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        [Display(Name = "Ürün No")]
        public int Id { get; set; }

        [Display(Name = "İsim")]
        [Required(AllowEmptyStrings=false, ErrorMessage ="{0} alanı boş bırakılamaz.")]
        [MaxLength(50, ErrorMessage ="İsim 50 karakteri geçemez.")]
        public String Name { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Fiyat")]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Minimum 0 girmelisin.")]
        public double Price { get; set; }

        [Display(Name = "Açıklama")]
        public String Description { get; set; }

        public int? Amount { get; set; }
    }
}
