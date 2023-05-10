using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{   public Transform destination;
    public float minTime = 100f;
    public float maxTime = 200f;
    public bool isGreen;
    public float distance =0.2f;

    public GameObject portalPurple;
    public GameObject portalGreen;

    // Start is called before the first frame update
    void Start()
    {InvokeRepeating("ToggleActive", 0f, Random.Range(minTime, maxTime));
        if (isGreen==false)
        {
            destination=GameObject.FindGameObjectWithTag("portalGreen").GetComponent<Transform>();
        }
        else
        {
            destination=GameObject.FindGameObjectWithTag("portalPurple").GetComponent<Transform>();
        }
    }


void OnTriggerEnter2D(Collider2D other)//The OnTriggerEnter2D function checks if the object that enters the trigger has the tag “Puck” and if it is at a certain distance from the teleporter
{
    // Check if the object has the desired tag
    if (other.CompareTag("Puck"))
    {
        if(Vector2.Distance(transform.position,other.transform.position)> distance )
        {
            other.transform.position=new Vector2(destination.position.x,destination.position.y);
        }
    }
}
 


  void ToggleActive()//The ToggleActive function toggles the active state of two game objects, portalPurple and portalGreen
{
    // Toggle the active state of both game objects
    portalPurple.SetActive(!portalPurple.activeSelf);
    portalGreen.SetActive(!portalGreen.activeSelf);

    // Change the repeat rate to a new random value
    CancelInvoke("ToggleActive");
    float repeatRate = Random.Range(minTime, maxTime);
    
    InvokeRepeating("ToggleActive", repeatRate, repeatRate);
}
} 












 /*Draft 
 
 
 void OnTriggerEnter2D(Collider2D other) previous method where paddle also went through portal, modified version above
   {
    if(Vector2.Distance(transform.position,other.transform.position)> distance )
    {
        other.transform.position=new Vector2(destination.position.x,destination.position.y);
    } 
    
    
    void ToggleActive()
{
    // Toggle the active state of both game objects
    portalPurple.SetActive(!portalPurple.activeSelf);
    portalGreen.SetActive(!portalGreen.activeSelf);
    
    // Change the repeat rate to a new random value
    CancelInvoke("ToggleActive");
    InvokeRepeating("ToggleActive", Random.Range(minTime, maxTime), Random.Range(minTime, maxTime));
}
   }*/
