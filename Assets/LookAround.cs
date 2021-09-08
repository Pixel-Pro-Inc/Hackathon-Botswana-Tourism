using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public float speed = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
          if (Input.GetMouseButtonDown(0))
        {
            transform.RotateAround(transform.position, Vector3.up, speed*Input.GetAxis("Mouse X"));
            transform.RotateAround(transform.position, transform.right, speed * Input.GetAxis("Mouse Y"));
            Debug.Log("So it does get called");
        }
         */


        
         if (Input.GetMouseButton(0))
         {
             Vector2 rotation = new Vector2
             {
                 y = transform.rotation.y,
                 x = transform.rotation.x
             };

             rotation.y += Input.GetAxis("Mouse X") * speed;
             rotation.x += -Input.GetAxis("Mouse Y") * speed;
             transform.eulerAngles += new Vector3(rotation.x, rotation.y, 0);
        Debug.Log("Tis works too");
         }
         

    }
}
