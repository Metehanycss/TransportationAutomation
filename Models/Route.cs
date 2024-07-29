using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaşımacılıkOtomasyonu.Models
{
    public class Route
    {
        public int ID { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public double Distance { get; set; }
        public TimeSpan EstimatedTime { get; set; }
    }
}
