using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TieTheKnot.Models
{
    public partial class UserInfo
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "User Name is required.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Invalid User Name. Only alphabetic characters and spaces are allowed.")]
        public string? UserName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Invalid Catering Services. Alphanumeric characters and spaces are allowed.")]
        public string? CateringServices { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Invalid Decoration. Alphanumeric characters and spaces are allowed.")]
        public string? Decoration { get; set; }

        [Required(ErrorMessage = "City is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Invalid City. Only alphabetic characters and spaces are allowed.")]
        public string City { get; set; } = null!;

        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Invalid Photography Services. Alphanumeric characters and spaces are allowed.")]
        public string? PhotographyServices { get; set; }

        [Required(ErrorMessage = "WeddingDate is required")]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "Invalid Wedding Date. Please use the format YYYY-MM-DD.")]
        public string WeddingDate { get; set; } = null!;
        [Required(ErrorMessage = "WeddingVenue is required.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Invalid WeddingVenue. Only alphabetic characters and spaces are allowed.")]
        public string WeddingVenue { get; set; } = null!;
    }
}