﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class BlogListesiVM
    {
        public bool blogStatus;

        public int blogId { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string Category { get; set; }
    }
}