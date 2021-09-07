using Assets.Scripts.Entities;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Offerings;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BProfileBehaviour : MonoBehaviour
{
    BProfile Business;
    bool CheckingAvail;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitialiseBProfile(BProfile profile)
    {
        Business = profile;
    }

    public float GetAvailabilityValue()
    {
        float thegiven= new float();
        void Checking()
        {
            while (CheckingAvail==true)
            {
                thegiven = Business.availabilityValue;
            }
        }

        ThreadStart CheckingStart = new ThreadStart(Checking); //this is a declaration of what happens at commencement
        Thread AvaliabilityThread = new Thread(CheckingStart);//this is the actual thread
        AvaliabilityThread.Start();
        AvaliabilityThread.Abort(); //i have abort call immeditaly after cause it want to remove the thread so we dont have the mutliple threads at the same time

        return thegiven;
    }

    public List<ServiceObject> GetServices()
    {
        return Business.services;
    }
    public void ShowService(ServiceObject service)
    {
        Debug.Log($"{service.ServiceName}, well you didn't write the logic to actually show it");
    }

    public List<ProductObject> GetProducts()
    {
        return Business.products;
    }
    public void ShowProducts(ProductObject product)
    {

        Debug.Log($"{product.ProductName}, well you didn't write the logic to actually show it");
    }

    public List<ActivitiesObject> GetActivities()
    {
        return Business.activities;
    }
    public void ShowActivities(ActivitiesObject activities)
    {
        Debug.Log($"{activities.ActivityName}, well you didn't write the logic to actually show it");
    }

    public void CapacityCounter(List<Users> occupyingUsers, double capacitypercentage) //set the availability of a business given the percentage of capacity
    {
        int numbers = occupyingUsers.Count;
        int cureentPercent = (int)(numbers / Business.CovidCapacity);
        if (cureentPercent > capacitypercentage)
        {
            Debug.Log("This place currently can't accept more people, try again in 30 minutes");
        }
        else
        {
            Debug.Log("Feel free to ome over!");
        }
        Business.availabilityValue = cureentPercent;
    }
}
