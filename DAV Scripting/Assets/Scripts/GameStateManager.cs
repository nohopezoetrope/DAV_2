using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    private GamePlayUIManager uiManager;

    private bool canInteractWithSomething;
    private DoorBehaviour doorWeAreCurrentlyAt;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(obj: this);
        }
        else
        {
            Instance = this;
        }
     }

    private void Start()
    {
        uiManager = this.GetComponent<GamePlayUIManager>();
    }

    private void Update()
    {
        ContextSensitiveButtonPress();
    }

    public GamePlayUIManager GetUiManager()
    {
        return uiManager;
    }

    public void SetCurrentContextInteractable(bool caninteract, DoorBehaviour doorToInteractWith)
    {
        canInteractWithSomething = caninteract;
        doorWeAreCurrentlyAt = doorToInteractWith;
    }

    private void ContextSensitiveButtonPress()
    {
        if(Input.GetButtonDown("Interact"))
        {

            if(canInteractWithSomething == true)
            {
                if (doorWeAreCurrentlyAt != null)
                {
                    doorWeAreCurrentlyAt.OpenDoor();
                }
                else if (doorWeAreCurrentlyAt == null)
                {
                    Debug.Log(message: "We never attached the door to this trigger");
                }
            }
            else if(canInteractWithSomething == false)
            {
                Debug.Log(message: "We cannot interact yet");
            }
        }
    }

}