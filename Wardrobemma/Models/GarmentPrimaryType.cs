using System.ComponentModel.DataAnnotations;

namespace Wardrobemma.Models
{
    public class GarmentPrimaryType
    {
        public int GarmentPrimaryTypeID { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50), MinLength(2)]
        [DisplayFormat(NullDisplayText = "No Primary Type set")]
        public string Name { get; set; }

        public ICollection<Garment> Garments{get;set;}


    }
}