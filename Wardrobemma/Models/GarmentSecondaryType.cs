using System.ComponentModel.DataAnnotations;

namespace Wardrobemma.Models
{
    public class GarmentSecondaryType
    {
        public int GarmentSecondaryTypeID{get;set;}
        [Required(AllowEmptyStrings=false)]
        [StringLength(50, MinimumLength =3)]
        [DisplayFormat(NullDisplayText = "No Secondary Type set")]
        public string Name{get;set;}

        public ICollection<Garment> Garments{get;set;}
        
    }
}