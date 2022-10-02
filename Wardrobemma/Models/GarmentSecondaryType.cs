using System.ComponentModel.DataAnnotations;

namespace Wardrobemma.Models
{
    public class GarmentSecondaryType
    {
        public GarmentSecondaryType()
        {
            this.Garments = new HashSet<Garment>();
        }
        public int GarmentSecondaryTypeID{get;set;}
        [Required(AllowEmptyStrings=false)]
        [StringLength(30),MinLength(2)]
        [DisplayFormat(NullDisplayText = "No Secondary Type Name set")]
        public string? Name{get;set;}

        public ICollection<Garment> Garments{get;set;}
        
    }
}