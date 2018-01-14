using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTankOrBarrier : MonoBehaviour 
{
    private LifeController lifeController;
    private TankSoundController tankSoundController;
    private ConsecutiveHitController consecutiveHitController;
    private AirStrikeController airStrikeController;

    void Start()
    {
        GameObject controller = GameObject.FindWithTag("GameController");
        GameObject tankSoundControl = GameObject.FindWithTag("TankSoundController");
        GameObject airStrikeControl = GameObject.FindWithTag("AirStrikeController");
        if (controller != null)
        {
            tankSoundController = tankSoundControl.GetComponent<TankSoundController>();
            lifeController = controller.GetComponent<LifeController>();
            consecutiveHitController = controller.GetComponent<ConsecutiveHitController>();
            airStrikeController = airStrikeControl.GetComponent<AirStrikeController>();
        }
        else
        {
            Debug.Log("Cannot find game controller");
        }
    }

    void Update()
    {
        gameObject.transform.Rotate(0, 0, 180);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tank")
        {
            tankSoundController.PlayTankExplosionSound();
            Destroy(other.gameObject);
            Destroy(gameObject);
            lifeController.decrementNumOfLives();
            consecutiveHitController.ResetConsecutiveHits();
            airStrikeController.HideAirStrikeText();
        }
    }
}
