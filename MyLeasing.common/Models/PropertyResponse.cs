using System.Collections.Generic;
using System.Linq;

namespace MyLeasing.Common.Models
{
    public class PropertyResponse
    {
        public int Id { get; set; }

        public string Neighborhood { get; set; }

        public string Address { get; set; }

        public decimal Price { get; set; }

        public int SquareMeters { get; set; }

        public int Rooms { get; set; }

        public int Stratum { get; set; }

        public bool HasParkingLot { get; set; }

        public bool IsAvailable { get; set; }

        public string Remarks { get; set; }

        public string PropertyType { get; set; }

        public ICollection<PropertyImageResponse> PropertyImages { get; set; }

        public ICollection<ContractResponse> Contracts { get; set; }

        public string FirstImage => PropertyImages == null || PropertyImages.Count == 0
                ? "https://www.google.com/url?sa=i&source=images&cd=&ved=&url=https%3A%2F%2Fwww.shutterstock.com%2Fes%2Fsearch%2Fno%2Bimage&psig=AOvVaw3U8fsinKGUowV5w7z-vqBU&ust=1568925776074943"
                : PropertyImages.FirstOrDefault().ImageUrl;
            
        
    }

}
