using System.ComponentModel.DataAnnotations;

namespace Wardrobemma.Models
{
    public class GarmentPrimaryType
    {
        public GarmentPrimaryType()
        {
            this.Garments = new HashSet<Garment>();
        }
        public int GarmentPrimaryTypeID { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(30), MinLength(2)]
        [DisplayFormat(NullDisplayText = "No Primary Type Name set")]
        public string? Name { get; set; }

        public ICollection<Garment> Garments{get;set;}


    }
}