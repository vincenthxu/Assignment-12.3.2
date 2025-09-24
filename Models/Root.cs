using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_12._3._2.Models
{
    public class Root
    {
        public int numFound { get; set; }
        public int start { get; set; }
        public bool numFoundExact { get; set; }
        public int num_found { get; set; }
        public string documentation_url { get; set; }
        public string q { get; set; }
        public object offset { get; set; }
        public List<Book> docs { get; set; }
    }
}
