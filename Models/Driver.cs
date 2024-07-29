using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaşımacılıkOtomasyonu.Models
{
    public class Driver
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
    }
}
