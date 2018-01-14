using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour 
{
    private ConsecutiveHitController consecutiveHitController;

    void Start()
    {
        GameObject controller = GameObject.FindWithTag("GameController");
        if (controller != null)
        {
            consecutiveHitController = controller.GetComponent<ConsecutiveHitController>();
        }
        else
        {
            Debug.Log("Cannot find game controller");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag != "FighterJet")
        {
            Destroy(other.gameObject);
        }
        if(other.tag == "TankBullet")
        {
            consecutiveHitController.ResetConsecutiveHits();
        }
    }
}
