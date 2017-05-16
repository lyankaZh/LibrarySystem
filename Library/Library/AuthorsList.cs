using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Library
{
    public class AuthorsList
    {
        public List<Author> Authors { get; set; }

        public AuthorsList(List<Author> authors)
        {
            Authors = authors;
        }
        public override string ToString()
        {
            if (Authors != null)
            {
                StringBuilder stringToReturn = new StringBuilder();
                foreach (var author in Authors)
                {
                    stringToReturn.Append($"{author},");
                }
                stringToReturn = stringToReturn.Remove(stringToReturn.Length - 1, 1);
                return stringToReturn.ToString();
            }
            return "";
        }

        
    }
}
