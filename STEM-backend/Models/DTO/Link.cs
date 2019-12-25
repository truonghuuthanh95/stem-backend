using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace STEM_backend.Models.DTO
{
    public class Link
    {
        public string link { get; set; }
        public string type { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public Link(string link, string type, int width, int height)
        {
            this.link = link;
            this.type = type;
            this.width = width;
            this.height = height;
        }
    }
}