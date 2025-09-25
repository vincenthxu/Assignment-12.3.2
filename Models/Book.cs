using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_12._3._2.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Book
    {
        public List<string>? author_key { get; set; }
        public List<string>? author_name { get; set; }
        public string? cover_edition_key { get; set; }
        public int cover_i { get; set; }
        public string? ebook_access { get; set; }
        public int edition_count { get; set; }
        public int first_publish_year { get; set; }
        public bool has_fulltext { get; set; }
        public List<string>? ia { get; set; }
        public string? ia_collection_s { get; set; }
        [Key]
        public string key { get; set; }
        public List<string>? language { get; set; }
        public string? lending_edition_s { get; set; }
        public string? lending_identifier_s { get; set; }
        public bool public_scan_b { get; set; }
        public string? title { get; set; }
        public override string ToString()
        {
            var authors = string.Empty;
            if (author_name != null)
                authors = $"\nby {string.Join(", ", author_name)}";
            return $"[{key}]\n{title}{authors}";
        }
    }
}
