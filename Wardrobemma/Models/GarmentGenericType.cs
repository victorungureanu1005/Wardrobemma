using System.ComponentModel.DataAnnotations;

namespace Wardrobemma.Models
{
    public class GarmentGenericType
    {
        public GarmentGenericType()
        {
            this.GarmentTypes = new HashSet<GarmentType>();
        }
        public int GarmentGenericTypeID { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(30), MinLength(2)]
        [DisplayFormat(NullDisplayText = "No Generic Type Name set")]
        public string? Name { get; set; }

        //Collection navigation property
        public ICollection<GarmentType> GarmentTypes{get;set;}


    }
}