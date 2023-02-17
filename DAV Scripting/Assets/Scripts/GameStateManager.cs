using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    private GamePlayUIManager uiManager;

    private bool isGameOver;

    private bool canInteractWithSomething;
    private DoorBehaviour doorWeAreCurrentlyAt;

    private float gameTimer;
    [SerializeField] private int maxGameTime = 30;

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

        //Delta Time = time it takes to render a single frame
        gameTimer = gameTimer + Time.deltaTime * 5;

        //This check if our time limit was hit.
        if (gameTimer >= maxGameTime)
        {
            //We need to tell the player they lost!
            uiManager.GameOverUI();
            isGameOver = true;
        }

        uiManager.SetGamePlayTimerUI(timeToDisplay:FormatTimer());
        
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

    public bool GetIsGameOver()
    {
        return isGameOver;
    }

    private string FormatTimer()
    {
        //TODO: Fix the seconds so they don't go above 60
        int minutes = (int)gameTimer / 60;
        int seconds = (int)gameTimer;

        
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
