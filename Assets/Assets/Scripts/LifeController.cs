using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour 
{
    public GameObject tankLifeSpawn1, tankLifeSpawn2, tankSymbol;
    private GameObject life3, life2;
    public GUIText lifeText;
    public int numOfLives;

    void Start()
    {
        UpdateLife();
        life2 = Instantiate(tankSymbol, tankLifeSpawn1.transform.position, tankSymbol.transform.rotation);
        life3 = Instantiate(tankSymbol, tankLifeSpawn2.transform.position, tankSymbol.transform.rotation);
    }

    public void decrementNumOfLives()
    {
        numOfLives--;
        UpdateLife();
        if(numOfLives == 2)
        {
            Destroy(life3);
        }
        else if(numOfLives == 1)
        {
            Destroy(life2);
        }
    }

    public int numberOflives()
    {
        return numOfLives;
    }

    void UpdateLife()
    {
        lifeText.text = numOfLives.ToString();
    }
}
