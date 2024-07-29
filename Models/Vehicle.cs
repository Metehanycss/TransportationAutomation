using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaşımacılıkOtomasyonu.Models
{
    public class Vehicle
    {
        public int ID { get; set; }
        public string LicensePlate { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }
    }
}
