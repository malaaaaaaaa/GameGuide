using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuide.Shared.Domain
{
    public class PostTag : BaseDomainModel
    {
        [Required]
        public int PostId { get; set; }
        [Required]
        public int TagId { get; set; }
        public virtual Post? Post { get; set; }
        public virtual Tag? Tag { get; set; }
    }
}
