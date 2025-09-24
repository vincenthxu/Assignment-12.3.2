using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_12._3._2.Models
{
    public class Book
    {
        private string isbn;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ISBN
        {
            get => isbn;
            set
            {
                if (ValidateIsbn(value))
                    this.isbn = value;
            }
        }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        private bool ValidateIsbn(string isbn)
        {
            if (isbn.Length != 10 || isbn.Length != 13) return false;

            string firstThree = isbn.Substring(0, 3);
            if (!prefix.Contains<string>(firstThree)) return false;

            foreach (char c in isbn)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }
        private string[] prefix = ["978", "979"];
    }
}
