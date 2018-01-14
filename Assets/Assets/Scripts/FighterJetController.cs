using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterJetController : MonoBehaviour 
{
    public float timeBetweenShotsMinimum;
    public GameObject fighterJetShot;
    private Transform shotSpawn;

	void Start () 
    {
        shotSpawn = this.gameObject.transform.GetChild(0).GetComponent<Transform>();
        StartCoroutine("FireShots");
	}

    IEnumerator FireShots()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            GameObject shot = Instantiate(fighterJetShot, shotSpawn.position, fighterJetShot.transform.rotation);
            shot.transform.SetParent(gameObject.transform);
            yield return new WaitForSeconds(timeBetweenShotsMinimum + Random.Range(0.0f, 0.5f));
        }
    }
}
