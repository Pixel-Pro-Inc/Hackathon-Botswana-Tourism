using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace Assets.Scripts.Models.Offerings
{
    class MenuObject
    {

        public Dictionary<string, (string edibleName, string edibleDescription, double edibleCost, Image edibleImage)> EdibleItem = new Dictionary<string, (string edibleName, string edibleDescription, double edibleCost, Image edibleImage)>();

        public void AddItemtoMenu(string name, string description, double cost, Image image)
        {
            EdibleItem.Add(name, (name, description, cost, image));
        }
    }
}
