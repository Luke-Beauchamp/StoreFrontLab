using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunitySpaceShipData
{
    [MetadataType(typeof(NeighborMetadata))]
    public partial class Neighbor
    {
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }

    public class NeighborMetadata //Consider making some use out of the this.ShareEvents and this.SharePackages
    {
        [Display(Name = "Neighbor ID")]
        public int NeighborID { get; set; }

        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "[-First Name must be 50 characters or less-]")]
        [Required(ErrorMessage = "[-First Name is required-]")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "[-Last Name must be 50 characters or less-]")]
        [Required(ErrorMessage = "[-Last Name is required-]")]
        public string LastName { get; set; }

        [StringLength(50, ErrorMessage = "[-Email must be 100 characters or less-]")]
        public string Email { get; set; }

        [Display(Name = "Region ID")]
        [Required(ErrorMessage = "[-Region ID is required-]")]
        public int RegionID { get; set; }

        [Display(Name = "Produce Available")]
        [Required(ErrorMessage = "[-Produce Available is required-]")]
        public bool ProduceAvailable { get; set; }

        [Display(Name = "Dairy Available")]
        [Required(ErrorMessage = "[-Dairy Available is required-]")]
        public bool DairyAvailable { get; set; }

        [Display(Name = "Eggs Available")]
        [Required(ErrorMessage = "[-Eggs Available is required-]")]
        public bool EggsAvailable { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }
    }

    [MetadataType(typeof(RegionMetadata))]
    public partial class Region
    {

    }

    public class RegionMetadata
    {
        [Display(Name = "Region ID")]
        [Required(ErrorMessage = "[-Region ID is required-]")]
        public int RegionID { get; set; }

        [Display(Name = "Region Name")]
        [StringLength(50, ErrorMessage = "[-Region Name must be 50 characters or less-]")]
        [Required(ErrorMessage = "[-Region Name is required-]")]
        public string RegionName { get; set; }

        [Display(Name = "Region Description")]
        [StringLength(250, ErrorMessage = "[-Region Description must be 250 characters or less-]")]
        [Required(ErrorMessage = "[-Region Description is required-]")]
        public string RegionDescription { get; set; }
    }

    [MetadataType(typeof(ParkMetadata))]
    public partial class Park
    {

    }

    public class ParkMetadata
    {

        [Display(Name = "Park ID")]
        [Required(ErrorMessage = "[-Park ID is required-]")]
        public int ParkID { get; set; }


        [Display(Name = "Region ID")]
        [Required(ErrorMessage = "[-Region ID is required-]")]
        public int RegionID { get; set; }
        
        [StringLength(50, ErrorMessage = "[-City must be 50 characters or less-]")]
        [Required(ErrorMessage = "[-City is required-]")]
        public string City { get; set; }

        [StringLength(50, ErrorMessage = "[-Address must be 50 characters or less-]")]
        [Required(ErrorMessage = "[-Address is required-]")]
        public string Address { get; set; }

        [StringLength(2, ErrorMessage = "[-State must be abbreviated-]")]
        [Required(ErrorMessage = "[-State is required-]")]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        [StringLength(13, ErrorMessage = "[-Zip Code must be between 5 and 13 characters long-]", MinimumLength = 5)]
        [Required(ErrorMessage = "[-Zip Code is required-]")]
        public string ZipCode { get; set; }

        [Display(Name = "Park Name")]
        [StringLength(50, ErrorMessage = "[-Park Name must be 50 characters or less-]")]
        [Required(ErrorMessage = "[-Park Name is required-]")]
        public string ParkName { get; set; }
    }

    [MetadataType(typeof(ShareEventMetadata))]
    public partial class ShareEvent
    {
        public string CoordinatorName
        {
            get { return $"{Neighbor.FirstName} {Neighbor.LastName}"; }
        }
    }

    public class ShareEventMetadata
    {
        [Display(Name = "Share Event ID")]
        [Required(ErrorMessage = "[-Share Event ID is required-]")]
        public int ShareEventID { get; set; }

        [Display(Name = "Park ID")]
        [Required(ErrorMessage = "[-Park ID is required-]")]
        public int ParkID { get; set; }
        
        [Required(ErrorMessage = "[-Coordinator is required-]")]
        public int Coordinator { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "[-Region ID is required-]")]
        public System.DateTime Date { get; set; }

        [Display(Name = "Start Time")]
        [Required(ErrorMessage = "[-Start Time is required-]")]
        public byte StartTime { get; set; }

        [Display(Name = "End Time")]
        [Required(ErrorMessage = "[-End Time is required-]")]
        public byte EndTime { get; set; }

        [Display(Name = "Coordinator Name")]
        public string CoordinatorName { get; }
    }

    [MetadataType(typeof(SharePackageMetadata))]
    public partial class SharePackage
    {

    }

    public class SharePackageMetadata
    {
        [Display(Name = "Share Package ID")]
        [Required(ErrorMessage = "[-Share Package ID is required-]")]
        public int SharePackageID { get; set; }

        [Display(Name = "Shareable ID")]
        [Required(ErrorMessage = "[-Shareable ID is required-]")]
        public int ShareableID { get; set; }

        [Required(ErrorMessage = "[-Quantity is required-]")]
        public int Quantity { get; set; }

        [Display(Name = "Share Event ID")]
        [Required(ErrorMessage = "[-Share Event ID is required-]")]
        public int ShareEventID { get; set; }

        [Display(Name = "Neighbor ID")]
        [Required(ErrorMessage = "[-Neighbor ID is required-]")]
        public int NeighborID { get; set; }

        [Display(Name = "Is Active")]
        [Required(ErrorMessage = "[-Is Active is required-]")]
        public bool IsActive { get; set; }
    }

    [MetadataType(typeof(ShareableMetadata))]
    public partial class Shareable
    {

    }

    public class ShareableMetadata
    {
        [Display(Name = "Shareable ID")]
        [Required(ErrorMessage = "[-Shareable ID is required-]")]
        public int ShareableID { get; set; }

        [Display(Name = "Shareable Name")]
        [StringLength(50, ErrorMessage = "[-Shareable Name must be 50 characters or less-]")]
        [Required(ErrorMessage = "[-Shareable Name is required-]")]
        public string ShareableName { get; set; }

        [Display(Name = "Category ID")]
        [Required(ErrorMessage = "[-Category ID is required-]")]
        public int CategoryID { get; set; }
    }

    [MetadataType(typeof(CategoryMetadata))]
    public partial class Category
    {

    }

    public class CategoryMetadata
    {
        [Display(Name = "Category ID")]
        [Required(ErrorMessage = "[-Category ID is required-]")]
        public int CategoryID { get; set; }

        [Display(Name = "Category Name")]
        [StringLength(50, ErrorMessage = "[-Category Name must be 50 characters or less-]")]
        [Required(ErrorMessage = "[-Category Name is required-]")]
        public string CategoryName { get; set; }
    }
}
