using Assets.Scripts.Models;
using Assets.Scripts.Models.Offerings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using static Enums;

namespace Assets.Scripts.Entities
{
    public class BProfile
    {
        public string BusinessName { get; set; }
       
        public TourismSector toursector { get; set; }
        public string ProfileDescription { get; set; }
        public Image ProfileImage { get; set; }

        public string BusinessEmail { get; set; }
        public Uri Businesslink { get; set; }

        public List<ProductObject> products = new List<ProductObject>();
        public List<ServiceObject> services = new List<ServiceObject>();
        public List<ActivitiesObject> activities = new List<ActivitiesObject>();
        public List<string> promoCode = new List<string>();

        public float availabilityValue { get; set; }
        public double CovidCapacity { get; set; } //The total number of people allowed in
        public List<Users> OccupyingUsers = new List<Users>();

       
    }
}
