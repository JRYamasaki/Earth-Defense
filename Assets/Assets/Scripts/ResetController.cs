using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetController : MonoBehaviour 
{
    public float lengthOfPauseAfterDeath;
    private bool playerHasDied, waveIsBeingReset;

    private LifeController lifeController;
    private ResetController resetController;
    private TankSpawn tankSpawner;
    private ChooseAliensThatWillShoot alienShooter;
    private AlienController alienController;
    private GameOverController gameOverText;
    private InitializeAlienPosition alienSpawnController;
    private GameObject areaToCheck;
    private PauseController pauseController;

    void Start () 
    {
        pauseController = gameObject.GetComponent<PauseController>();

        StartCoroutine("ResetAfterDeath");
        playerHasDied = false;
        GameObject gameController = GameObject.FindWithTag("GameController");
        GameObject gameOverObject = GameObject.FindWithTag("GameOverText");
        areaToCheck = GameObject.FindWithTag("AlienArea");
        if (gameController != null && gameOverObject != null && areaToCheck !=null)
        {
            alienShooter = areaToCheck.GetComponent<ChooseAliensThatWillShoot>();
            alienController = gameController.GetComponent<AlienController>();
            tankSpawner = gameController.GetComponent<TankSpawn>();
            lifeController = gameController.GetComponent<LifeController>();
            gameOverText = gameOverObject.GetComponent<GameOverController>();
            alienSpawnController = gameController.GetComponent<InitializeAlienPosition>();
            StartCoroutine("CheckIfWaveShouldBeReset");
        }
        else
        {
            Debug.Log("Cannot find game controller in reset Controller");
        }
    }

    //Only one reset can occur, mutex like situation
    public IEnumerator ResetAfterDeath()
    {
        yield return new WaitForSeconds(2f);
        while(!playerHasDied)
        {
            if(GameObject.FindWithTag("Tank") == null)
            {
                pauseController.PauseAliens();
                CheckForGameOver();
                yield return new WaitForSeconds(lengthOfPauseAfterDeath);
                tankSpawner.SpawnTank();
                if(!waveIsBeingReset)
                {
                    pauseController.ResumeAliens();
                }
            }
            yield return new WaitForSeconds(1.0f);
        }
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator CheckIfWaveShouldBeReset()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            if (areaToCheck.transform.childCount == 0)
            {
                waveIsBeingReset = true;
                pauseController.PauseGame();
                yield return new WaitForSeconds(2);
                PrepareNextWave();
                yield return new WaitForSeconds(2);
                pauseController.ResumeGame();
                waveIsBeingReset = false;
            }
            yield return new WaitForSeconds(1);
        }
    }

    void CheckForGameOver()
    {
        if(lifeController.numOfLives == 0)
        {
            StartCoroutine(gameOverText.ShowText());
            StopCoroutine("ResetAfterDeath");
        }
    }

    void PrepareNextWave()
    {
        alienController.SetAlienPosition();
        alienController.largeIncreaseAlienMovementSpeed();
        alienSpawnController.CreateNewWaveOfAliens();
        alienShooter.DoubleShootingRate();
    }
}
