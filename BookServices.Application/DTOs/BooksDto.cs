﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookServices.Application.DTOs
{
    public class BooksDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
    }
}
