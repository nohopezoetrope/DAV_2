using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{

    private Vector3 doorStartingPosition;

    [SerializeField] private float distanceToOpen;

    private void Start()
    {
        doorStartingPosition = this.transform.position;
    }

    public void OpenDoor()
    {
        Debug.Log(message: "Door is Open! Promise");

        this.transform.position = new Vector3(doorStartingPosition.x + distanceToOpen, doorStartingPosition.y, doorStartingPosition.z);
    }
}
