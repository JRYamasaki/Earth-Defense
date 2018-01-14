using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyAlien : MonoBehaviour 
{
    public int alien1Value, alien2Value, alien3Value;
    public float explosionDuration;
    public GameObject explosion;
    private int scoreToAdd;
    private ScoreController scoreController;
    private ConsecutiveHitController consecutiveHitController;

    void Start()
    {
        GameObject controller = GameObject.FindWithTag("GameController");
        if(controller != null)
        {
            scoreController = controller.GetComponent<ScoreController>();
            consecutiveHitController = controller.GetComponent<ConsecutiveHitController>();
        }
        else
        {
            Debug.Log("Cannot find game controller");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name.StartsWith("Alien") && other.tag != "AlienArea")
        {
            Vector3 alienTransform = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
            Destroy(other.gameObject);
            InstantiateExplosion(alienTransform);
            Destroy(gameObject);
            switch (other.tag)
            {
                case "Alien1":
                    scoreToAdd = alien1Value;
                    break;
                case "Alien2":
                    scoreToAdd = alien2Value;
                    break;
                case "Alien3":
                    scoreToAdd = alien3Value;
                    break;                   
            }
            scoreController.AddScore(scoreToAdd);
            incrementHitCounter();
        }
        else if(other.tag == "Brick")
        {
            consecutiveHitController.ResetConsecutiveHits();
        }
    }

    void InstantiateExplosion(Vector3 destroyedAlienPosition)
    {
        GameObject explosionTemp = (GameObject)Instantiate(explosion, destroyedAlienPosition, explosion.transform.rotation);
        Destroy(explosionTemp, explosionDuration);
    }

    void incrementHitCounter()
    {
        if(gameObject.name.StartsWith("Tank"))
        {
            consecutiveHitController.incrementConsecutiveHits();
        }
    }
}
