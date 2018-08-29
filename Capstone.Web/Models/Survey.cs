using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }
        
        [Required(ErrorMessage = " *Park selection is required.")]
        [DataType(DataType.Text)]
        public string ParkCode { get; set; }

        [Required(ErrorMessage = " *State is required.")]
        [DataType(DataType.Text)]
        public string State { get; set; }

        [Required(ErrorMessage = " *The Email field is required.")]
        [EmailAddress(ErrorMessage = " *Enter a valid email address.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = " *Activity level is required.")]
        [DataType(DataType.Text)]
        public string ActivityLevel { get; set; }
    }
}