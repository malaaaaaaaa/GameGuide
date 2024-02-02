﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuide.Shared.Domain
{
    public class Post : BaseDomainModel
    {
        public string? Title { get; set; }

        public string? Description { get; set; }
        public string? Content { get; set; }
        public int? SuggestionId { get; set; }
        public virtual Suggestion? Suggestion { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}
