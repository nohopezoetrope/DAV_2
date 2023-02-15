using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    [SerializeField] private DoorBehaviour walkwayDoor;


    private void Start()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnTriggerEnter(Collider thingInsideTrigger)
    {
        Debug.Log(message: "We have something inside the trigger");
        Debug.Log(message: "The thing is " + thingInsideTrigger.name);

        walkwayDoor.OpenDoor();

    }

    private void OnTriggerStay(Collider thingInsideTrigger)
    {
        //This will constantly fire while something is in the trigger
    }

    private void OnTriggerExit(Collider thingInsideTrigger)
    {
        Debug.Log(message: "Something left the trigger");
    }
}

