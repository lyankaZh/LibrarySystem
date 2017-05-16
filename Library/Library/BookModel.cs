using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Library
{
    class BookModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }
        public int Pages { get; set; }
        public string Language { get; set; }
        public string Genre { get; set; }
        public string Location { get; set; }
        public string Authors { get; set; }
        public string IsInLibrary { get; set; }
    }
}
