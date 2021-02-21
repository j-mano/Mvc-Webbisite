
using System.ComponentModel.DataAnnotations;

namespace Joachim_Johnson_ConsidAplication.Models
{
    public class CordinatesModells : ICordinatesModells
    {
        [Display(Name = "Latitude")]
        public string lat { get; set; }

        [Display(Name = "Longitude")]
        public string lng { get; set; }
    }
}