﻿namespace LibraryApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Isbn { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Summary { get; set; }
    }
}
