using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuide.Shared.Domain
{
    public class Category : BaseDomainModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? GameId { get; set; }
        public virtual Game? Game { get; set; }

        public virtual List<Post>? Posts { get; set; }
    }
}
