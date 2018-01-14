using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseAliensThatWillShoot : MonoBehaviour 
{
    public GameObject alienShot;
    public float timeInSecondsBetweenShots;
    private List<GameObject> allRemainingAliens;
    private bool aliensStillAlive, playerIsAlive;
	// Use this for initialization
	void Start () 
    {
        aliensStillAlive = true;
        playerIsAlive = true;
        StartCoroutine(RandomlyChooseXAliensToShoot());
        StartCoroutine(ChooseAlienToShoot());
	}

    public void StopAlienShooting()
    {
        playerIsAlive = false;
    }

    public void StartAlienShooting()
    {
        playerIsAlive = true;
        StartCoroutine("ChooseAlienToShoot");
    }

    public void DoubleShootingRate()
    {
        timeInSecondsBetweenShots /= 2.0f;
    }

    IEnumerator RandomlyChooseXAliensToShoot()
    {
        while(aliensStillAlive)
        {
            allRemainingAliens = new List<GameObject>();
            foreach (Transform child in transform)
            {
                allRemainingAliens.Add(child.gameObject);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator ChooseAlienToShoot()
    {
        yield return new WaitForSeconds(2);
        while(aliensStillAlive && playerIsAlive)
        {
            float randomAlien = Random.Range(0f, allRemainingAliens.Count);
            if(allRemainingAliens.Count != 0) //only alien can shoot if it wont be shot?
            {
                GameObject alienToShoot = allRemainingAliens[(int)randomAlien]; //dangerous cast?
                if(alienToShoot != null)
                {
                    GameObject shotSpawn = alienToShoot.transform.GetChild(0).gameObject; //alien can be destroyed and then try to access its shotspawn
                    Instantiate(alienShot, shotSpawn.transform.position, shotSpawn.transform.rotation);
                }
            }
            yield return new WaitForSeconds(timeInSecondsBetweenShots + Random.Range(0.0f, 1.0f));
        }       
    }
}
