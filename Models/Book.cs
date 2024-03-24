﻿namespace TestOdata.Models
{
    // Book
    public class Book
    {
        public decimal Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; } = 0;
    }
}
