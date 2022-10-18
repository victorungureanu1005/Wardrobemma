using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Wardrobemma.Models
{
    public class Garment
    {
        public Garment()
        {
            //Avoiding exceptions, instantiating collections
            this.GarmentStyles = new HashSet<GarmentStyle>();
            this.GarmentColours = new HashSet<GarmentColour>();
            this.GarmentMaterials = new HashSet<GarmentMaterial>();
        }
        public int GarmentID { get; set; }
        public string? GarmentName { get; set; }
        public string? ImageURL { get; set; }

        [Display(Name="Acquire Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy}", ApplyFormatInEditMode =true)]
        public DateTime Date { get; set; }
        public bool Preferred { get; set; }
        public bool DryCleaning { get; set; }
        public int PurchaseYear { get; set; }
        
        [Column(TypeName= "nvarchar(24)")]
        public WeatherNames Weather{get;set;}

        #region NavigationTypes
        //Many to One
        public int? GarmentPrimaryTypeID { get; set; }
        public GarmentPrimaryType? GarmentPrimaryType { get; set; }
        public int? GarmentSecondaryTypeID { get; set; }
        public GarmentSecondaryType? GarmentSecondaryType { get; set; }

        //Many to Many 
        public ICollection<GarmentStyle> GarmentStyles { get; set; }
        public ICollection<GarmentColour> GarmentColours { get; set; }
        public ICollection<GarmentMaterial> GarmentMaterials { get; set; }


        #endregion
    }
}