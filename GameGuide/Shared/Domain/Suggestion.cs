using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuide.Shared.Domain
{
    public class Suggestion : BaseDomainModel
    {
        public string? Content { get; set; }
        public bool SendEmail { get; set; }
        public string? Email { get; set; }
        public bool? CreatedPost { get; set; }
    }
}
