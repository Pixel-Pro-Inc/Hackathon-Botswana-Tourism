using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace Assets.Scripts.Models
{
    public class ServiceObject
    {
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public double ServiceCost { get; set; }
        public Image ServiceImage { get; set; }
    }
}
