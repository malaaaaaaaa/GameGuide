using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuide.Shared.Domain
{
    public class Image : BaseDomainModel
    {
        [Required]
        public string? ImageName { get; set; }

        [Required]
        public int? PostId { get; set; }
    }
}
