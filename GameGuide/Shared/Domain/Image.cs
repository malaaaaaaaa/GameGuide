using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuide.Shared.Domain
{
    public class Image : BaseDomainModel
    {
        public string? ImageName { get; set; }

        public int? PostId { get; set; }
    }
}
