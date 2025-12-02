using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslaExemple.DalEfNetStandard
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        [Timestamp]
        public byte[] LastChanged { get; set; }
    }
}
