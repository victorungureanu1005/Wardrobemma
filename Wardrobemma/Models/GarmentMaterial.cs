using System.ComponentModel.DataAnnotations;

namespace Wardrobemma.Models
{
    public class GarmentMaterial
    {

        public GarmentMaterial()
        {
            this.Garments = new HashSet<Garment>();
        }
        public int GarmentMaterialID { get; set; }

        [Required(AllowEmptyStrings =false)]
        [StringLength(30, MinimumLength =2)]
        [DisplayFormat(NullDisplayText ="No Garment Material Name set")]
        public string? Name { get; set; }
        public bool? Natural { get; set; }

        public ICollection<Garment> Garments { get; set; }
    }

}
