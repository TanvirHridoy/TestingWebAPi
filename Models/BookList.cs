using System;
using System.Collections.Generic;

#nullable disable

namespace TestingWebAPi.Models
{
    public partial class BookList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string BookId { get; set; }
        public string Author { get; set; }
        public string Price { get; set; }
    }
}
