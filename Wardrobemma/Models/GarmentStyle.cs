using System.ComponentModel.DataAnnotations;

namespace Wardrobemma.Models
{
    public class GarmentStyle
    {
        public GarmentStyle()
        {
            this.Garments = new HashSet<Garment>();
        }
        public int GarmentStyleID{get;set;}

        [Required(AllowEmptyStrings =false)]
        [StringLength(30, MinimumLength =2)]
        [DisplayFormat(NullDisplayText = "No Garment Style Name set")]
        public string? Name{get;set;}
        
        public ICollection<Garment> Garments{get;set;}
    }
}