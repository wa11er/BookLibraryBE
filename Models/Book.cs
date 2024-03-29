﻿using System.ComponentModel.DataAnnotations;

namespace BookLibraryBE.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public int PublishYear { get; set; }
    }
}