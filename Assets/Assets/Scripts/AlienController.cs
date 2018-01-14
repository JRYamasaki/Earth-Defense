using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour 
{
    //public GameObject tank;
    public int horizontalMovementMax, verticalMovementMax;
    public float increaseInMovementSpeed, increaseInMovementSpeedAfterBeatingWave, delayBetweenMovementInSeconds, movementDelayFloor;

    private int horizontalMovementCounter, verticalMovementCounter;
    private float horizontalDirection;
    private GameOverController GameController;
    private bool aliensCanMove;
    private AlienSoundController movementSoundController;
    private PauseController pauseController;

    void Start()
    {

        movementSoundController = GameObject.FindWithTag("AlienSoundController").GetComponent<AlienSoundController>();
        pauseController = GameObject.FindWithTag("GameController").GetComponent<PauseController>();
        aliensCanMove = true;
        SetAlienPosition();
        StartCoroutine(AlienMovement());
    }

    void Update()
    {
        if(verticalMovementCounter == verticalMovementMax)
        {
            verticalMovementCounter++;
            aliensCanMove = false;
            pauseController.PauseGame();
            GameObject gameController = GameObject.FindWithTag("GameOverText");
            GameController = gameController.GetComponent<GameOverController>();
            StartCoroutine(GameController.ShowText());
        }
    }

    IEnumerator AlienMovement()
    {
        yield return new WaitForSeconds(delayBetweenMovementInSeconds);
        while (aliensCanMove)
        {
            if (horizontalMovementCounter == horizontalMovementMax)
            {
                horizontalDirection *= -1;
                horizontalMovementCounter = 0;
                verticalMovementCounter++;
                movementSoundController.PlayAlienMovementSound();
                GameObject.FindWithTag("AlienArea").transform.Translate(0, -1, 0);
                IncreaseAlienMovementSpeed();
            }
            else
            {
                movementSoundController.PlayAlienMovementSound();
                GameObject.FindWithTag("AlienArea").transform.Translate(horizontalDirection, 0, 0);
                horizontalMovementCounter++;
            }
            yield return new WaitForSeconds(delayBetweenMovementInSeconds);
        }
    }

    void IncreaseAlienMovementSpeed()
    {
        if(delayBetweenMovementInSeconds - increaseInMovementSpeed > movementDelayFloor)
        {
            delayBetweenMovementInSeconds -= increaseInMovementSpeed;
        }
    }

    public void largeIncreaseAlienMovementSpeed()
    {
        if (delayBetweenMovementInSeconds - increaseInMovementSpeedAfterBeatingWave > movementDelayFloor)
        {
            delayBetweenMovementInSeconds -= increaseInMovementSpeedAfterBeatingWave;
        }
    }

    public void StopAlienMovement()
    {
        aliensCanMove = false;
    }

    public void StartAlienMovement()
    {
        aliensCanMove = true;
        StartCoroutine("AlienMovement");
    }

    public void SetAlienPosition()
    {
        horizontalMovementCounter = horizontalMovementMax / 2;
        verticalMovementCounter = 0;
        horizontalDirection = 1f;
    }
}
