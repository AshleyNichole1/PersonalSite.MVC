using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//Added to use "Required" and other actions
using System.Linq;
using System.Web;

namespace PersonalsiteConverted.Models
{
    public class ContactAction
    {
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "*")]
        [UIHint("MultilineText")] //Larger Text Box
        public string Message { get; set; }

    }
}