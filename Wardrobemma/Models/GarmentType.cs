using System.ComponentModel.DataAnnotations;

namespace Wardrobemma.Models
{
    public class GarmentType
    {
        public GarmentType()
        {
            this.Garments = new HashSet<Garment>();
        }
        public int GarmentTypeID { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(30), MinLength(2)]
        [DisplayFormat(NullDisplayText = "No Type Name set")]
        public string? Name { get; set; }

        #region Navigation Types
        //Many to One
        public int? GarmentGenericTypeID { get; set; }
        public GarmentGenericType? GarmentGenericType { get; set; }

        //Collection navigation property
        public ICollection<Garment> Garments { get; set; }
        #endregion

    }
}