using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuide.Shared.Domain
{
    public class Suggestion : BaseDomainModel
    {
        [Required]
        [StringLength(300, MinimumLength = 5, ErrorMessage = "Title does not meet length requirements")]
        public string? Content { get; set; }
        public bool SendEmail { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Email Address is not a valid email")]
        public string? Email { get; set; }
        public bool? CreatedPost { get; set; }
    }
}
