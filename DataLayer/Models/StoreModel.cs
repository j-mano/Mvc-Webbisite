using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    public class StoreModel : IValidatableObject
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Id must be present")]
        public Guid id { get; set; }

        [Display(Name = "Company Id")]
        [Required(ErrorMessage = "Comopany Id must be present")]
        public Guid CompanyId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name must be present")]
        [DataType(DataType.Text, ErrorMessage = "Name not valid.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "No adress or is so to small, please put in an valid adress.")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "The characters ':', '.' ';', '*', '/' and '\' are not allowed")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Display(Name = "Adress")]
        [Required(ErrorMessage = "Adress must be present")]
        [DataType(DataType.Text, ErrorMessage = "Adress not valid.")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "The characters ':', '.' ';', '*', '/' and '\' are not allowed")]
        [MaxLength(512)]
        public string Adress { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City must be present")]
        [DataType(DataType.Text, ErrorMessage = "City not valid.")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "The characters ':', '.' ';', '*', '/' and '\' are not allowed")]
        [MaxLength(512)]
        public string City { get; set; }

        [Display(Name = "Zip")]
        [Required(ErrorMessage = "Zip must be present")]
        [DataType(DataType.PostalCode, ErrorMessage = "Zip not valid.")]
        [MaxLength(16)]
        public string Zip { get; set; }

        [Display(Name = "Cuntry")]
        [Required(ErrorMessage = "Cuntry must be present")]
        [DataType(DataType.Text, ErrorMessage = "Cuntry not valid.")]
        [RegularExpression(@"^[^\\/:*;\.\)\(]+$", ErrorMessage = "The characters ':', '.' ';', '*', '/' and '\' are not allowed")]
        [MaxLength(50)]
        public string Country { get; set; }

        [Display(Name = "Longitude")]
        [RegularExpression(@"[^a-zA-Z:,]+", ErrorMessage = "Letters are not allowed")]
        [MaxLength(15)]
        public string Longitude { get; set; }

        [Display(Name = "Latitude")]
        [RegularExpression(@"[^a-zA-Z:,]+", ErrorMessage = "Letters are not allowed")]
        [MaxLength(15)]
        public string Latitude { get; set; }

        //Collection of prefomated information.

        public string StoreName()
        {
            return Name + " " + City + " " + Country;
        }

        public string FullAdress()
        {
            return Adress + City;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Sql injection validation on text strings. just matching to keywords in sql to block unwanted injections.

            if (Country.Contains("Delete") || Country.Contains("Alter") || Name.Contains("Delete") || Name.Contains("Alter") || Adress.Contains("Delete") || Adress.Contains("Alter"))
            {
                yield return new ValidationResult(
                    $"Any sql keywords are banned.",
                    new[] { nameof(Country) });
            }
        }
    }
}
