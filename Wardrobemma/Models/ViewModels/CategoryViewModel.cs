namespace Wardrobemma.Models.ViewModels
{
    public class CategoryViewModel
    {
        public IEnumerable<GarmentType> Types { get; set; }
        public IEnumerable<GarmentColour> Colours { get; set; }

        public IEnumerable<GarmentMaterial> Materials { get; set; }

        public IEnumerable<GarmentStyle> Styles { get; set; }

        public bool IsPopulated { get; set; }
    }
}
