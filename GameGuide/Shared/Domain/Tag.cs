using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuide.Shared.Domain
{
    public class Tag : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Tag Name does not meet length requirements")]
        public string Name { get; set; }
        [Required]
        [StringLength(300, MinimumLength = 25, ErrorMessage = "Tag Description does not meet length requirements")]
        public string Description { get; set; }

        public virtual List<PostTag>? PostTags { get; set; }
    }
}
