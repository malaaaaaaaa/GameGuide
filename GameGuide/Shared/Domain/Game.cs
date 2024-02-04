using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuide.Shared.Domain
{
    public class Game : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Game Name does not meet length requirements")]
        public string? Name { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 25, ErrorMessage = "Game Description does not meet length requirements")]
        public string? Description { get; set; }

        public virtual List<Category>? Categories { get; set; }
    }
}
