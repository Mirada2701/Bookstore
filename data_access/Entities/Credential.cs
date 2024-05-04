using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Credential
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
