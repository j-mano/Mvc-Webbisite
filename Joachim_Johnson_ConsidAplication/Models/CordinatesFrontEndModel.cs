using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joachim_Johnson_ConsidAplication.Models
{
    public class CordinatesFrontEndModel
    {
        /* 
             * This is a model to handle the information from the company veiwports. Those under the Folder Company in the the Views folder
             * some vaildation is done here with the help of DataAnnotations.
             * For frontend only
        */

        public string lat { get; set; }
        public string lng { get; set; }
    }
}