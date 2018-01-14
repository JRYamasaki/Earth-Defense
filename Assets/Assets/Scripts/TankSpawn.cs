using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawn : MonoBehaviour 
{
    public GameObject tank, tankSpawn;

	// Use this for initialization
	void Start () 
    {
        SpawnTank();
	}

    public void SpawnTank()
    {
        Instantiate(tank, tankSpawn.transform.position, tankSpawn.transform.rotation);
    }
}
