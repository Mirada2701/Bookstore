using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<WriteOffBooks> WriteOffBooks { get; set; }
        public override string ToString()
        {
            return $"Id : {Id} Name : {Name} Description : {Description}";
        }
    }
}
