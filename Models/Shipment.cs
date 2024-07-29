using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaşımacılıkOtomasyonu.Models
{
    public class Shipment
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public int DriverID { get; set; }
        public int RouteID { get; set; }
        public DateTime ShipmentDate { get; set; }
    }
}
