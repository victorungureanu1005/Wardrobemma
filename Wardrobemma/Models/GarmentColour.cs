using System.ComponentModel.DataAnnotations;

namespace Wardrobemma.Models
{
    public class GarmentColour
    {
        public GarmentColour()
        {
            this.Garments = new HashSet<Garment>();
        }
        public int GarmentColourID { get; set; }

        [Required(AllowEmptyStrings =false)]
        [StringLength(20), MinLength(2)]
        [DisplayFormat(NullDisplayText = "No Colour Name set")]
        public string? Name { get; set; }

        public ICollection<Garment> Garments { get; set; }
    }
}
