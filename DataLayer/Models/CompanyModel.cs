using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models
{
    public class CompanyModel : IValidatableObject
    {
        [Display(Name = "Company ID")]
        public Guid Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name must be present")]
        [DataType(DataType.Text, ErrorMessage = "Name not valid.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "No adress or is so to small, please put in an valid adress.")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "The characters ':', '.' ';', '*', '/' and '\' are not allowed")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name = "Orginatation Number")]
        [Required(ErrorMessage = "Orginatation Number must be present")]
        public int OrganizationNumber { get; set; }

        [Display(Name = "Notes")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "The characters ':', '.' ';', '*', '/' and '\' are not allowed")]
        [MaxLength(255)]
        public string Notes { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            // Sql injection validation on text strings. just matching to keywords in sql to block unwanted injections.
            if ( Name.Contains("Delete") || Name.Contains("Alter") || Notes.Contains("Delete") || Notes.Contains("Alter"))
            {
                yield return new ValidationResult(
                    $"Any sql keywords are banned.",
                    new[] { nameof(Notes) });
            }
        }
    }
}
