using System.ComponentModel.DataAnnotations.Schema;

namespace Wardrobemma.Models
{
    public class Garment
    {
        public int GarmentID { get; set; }
        public string GarmentName { get; set; }
        public string ImageURL { get; set; }
        public DateOnly Date { get; set; }
        public bool Preferred { get; set; }
        public bool DryCleaning { get; set; }
        
        [Column(TypeName="nvchar(24)")]
        public WeatherNames Weather{get;set;}

        #region NavigationTypes
        //One to Many
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