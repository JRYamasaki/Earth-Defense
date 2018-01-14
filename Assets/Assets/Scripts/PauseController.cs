using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour 
{
    private ChooseAliensThatWillShoot alienShotController;
    private AlienController alienMovementController;
    private PlayerController tankMovementController;
    private GameObject areaToCheck;

    void Start()
    {
        GameObject controller = GameObject.FindWithTag("GameController");
        areaToCheck = GameObject.FindWithTag("AlienArea");
        if (controller != null)
        {
            alienShotController = areaToCheck.GetComponent<ChooseAliensThatWillShoot>();
            alienMovementController = controller.GetComponent<AlienController>();
        }
        else
        {
            Debug.Log("Cannot find game controller in reset Controller");
        }
    }

    public void PauseGame()
    {
        PauseTank();
        PauseAliens();
    }

    public void ResumeGame()
    {
        StartCoroutine("ResumeTank");
        ResumeAliens();
    }

    public void PauseAliens()
    {
        alienMovementController.StopAlienMovement();
        alienShotController.StopAlienShooting();
    }

    public void ResumeAliens()
    {
        alienMovementController.StartAlienMovement();
        alienShotController.StartAlienShooting();
    }

    IEnumerator ResumeTank()
    {
        while(GameObject.FindWithTag("Tank") == null)
        {
            yield return new WaitForSeconds(0.01f);
        }
        tankMovementController = GameObject.FindWithTag("Tank").GetComponent<PlayerController>();
        tankMovementController.StartPlayerMovement(); //threw exception when player died after wave was restarting
        tankMovementController.EnablePlayerShooting();
    }

    void PauseTank()
    {
        if (GameObject.FindWithTag("Tank") != null)
        {
            tankMovementController = GameObject.FindWithTag("Tank").GetComponent<PlayerController>();
            tankMovementController.StopPlayerMovement();
            tankMovementController.BlockPlayerShooting();
        }
    }
}
