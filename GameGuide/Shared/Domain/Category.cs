using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuide.Shared.Domain
{
    public class Category : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Category Name does not meet length requirements")]
        public string? Name { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 25, ErrorMessage = "Category Description does not meet length requirements")]
        public string? Description { get; set; }
        [Required]
        public int? GameId { get; set; }
        public virtual Game? Game { get; set; }

        public virtual List<Post>? Posts { get; set; }
    }
}
