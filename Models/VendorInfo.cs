using System.ComponentModel.DataAnnotations;

namespace TieTheKnot.Models
{
    public partial class VendorInfo
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Vendor Name is required.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Invalid Vendor Name. Only alphabetic characters and spaces are allowed.")]
        public string VendorName { get; set; } = null!;

        [Required(ErrorMessage = "GST Number is required.")]
        [RegularExpression(@"^\d{2}[A-Za-z]{5}\d{4}[A-Za-z]\d[Zz][A-Za-z\d]$", ErrorMessage = "Invalid GST number")]
        public string GstNumber { get; set; } = null!;

        [Required(ErrorMessage = "City is required.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Invalid City. Only alphabetic characters and spaces are allowed.")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Facility is required.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Invalid Facility. Alphanumeric characters and spaces are allowed.")]
        public string Facility { get; set; } = null!;

        [Required(ErrorMessage = "Charges is required.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Invalid Charges. Must be a non-negative number with up to two decimal places.")]
        [Range(1000, 1000000, ErrorMessage = "Charges must be between 1,000 and 1,000,000")]
        public double Charges { get; set; }

        [Required(ErrorMessage = "Picture Links are required.")]
        [RegularExpression(@"^https?:\/\/.*\.(png|jpg|jpeg)$", ErrorMessage = "Invalid Picture Links. Only links to PNG, JPG, or JPEG images are allowed.")]
        public string PictureLinks { get; set; } = null!;
    }
}