using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuide.Shared.Domain
{
    public class Post : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Title does not meet length requirements")]
        public string? Title { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Description does not meet length requirements")]
        public string? Description { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 20, ErrorMessage = "Content does not meet length requirements")]
        public string? Content { get; set; }
        public int? SuggestionId { get; set; }
        public virtual Suggestion? Suggestion { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
