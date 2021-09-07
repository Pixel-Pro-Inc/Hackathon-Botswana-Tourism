using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace Assets.Scripts.Models.Offerings
{
    public class ActivitiesObject
    {
        public string ActivityName { get; set; }
        public string ActivityDescription { get; set; }
        public double ActivityCost { get; set; }
        public System.DateTime scheduledTime { get; set; }
        public Image ActivityImage { get; set; }
    }
}
