﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public int Count_Pages { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public DateTime Publication_Year { get; set; }
        public decimal Price { get; set; }
        public decimal Sale_Price { get; set; }
        public bool IsContinuation { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public override string ToString()
        {
            return $"\t\t{Name}\nAuthor : {Author?.Name} {Author?.Last_Name} {Author?.Surname}\nPublisher : {Publisher?.Name}\nCount pages : {Count_Pages}\nGenre : {Genre?.Name}\nPublication Year : " +
                $"{Publication_Year.ToShortDateString()}\nPrice : {Sale_Price}\nIs Continuation : {IsContinuation}\n\n\n";
        }

    }
}
