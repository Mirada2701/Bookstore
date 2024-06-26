﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<WriteOffBooks> WriteOffBooks { get; set; }
        public Credential Credential { get; set; }
        public override string ToString()
        {
            return $"{FullName} {Address} {City}";
        }

    }
}
