using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Last_Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
