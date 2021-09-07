using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace Assets.Scripts.Models.Offerings
{
    public class ProductObject
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductCost { get; set; }
        public Image ProductImage { get; set; }
    }
}
