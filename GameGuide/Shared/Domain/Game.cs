using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuide.Shared.Domain
{
    public class Game : BaseDomainModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual List<Category>? Categories { get; set; }
    }
}
