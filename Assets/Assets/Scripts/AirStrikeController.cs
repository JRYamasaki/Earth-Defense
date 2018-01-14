using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirStrikeController : MonoBehaviour 
{
    public GameObject fighterJet, fighterJetSpawn;
    private GUIText airStrikeText;
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
        airStrikeText = this.GetComponent<GUIText>();
        HideAirStrikeText();
        airStrikeText.text = "PRESS 'E' FOR AIR STRIKE";
    }

    void Update()
    {
        if(consecutiveHitController.AirStrikeIsReady())
        {
            ShowAirStrikeText();
        }
        if(Input.GetKeyDown(KeyCode.E) && consecutiveHitController.AirStrikeIsReady())
        {
            HideAirStrikeText();
            consecutiveHitController.ResetConsecutiveHits();
            CallAirStrike();
        }
    }

    void CallAirStrike()
    {
        Instantiate(fighterJet, fighterJetSpawn.transform.position, fighterJet.transform.rotation);
    }

    public void ShowAirStrikeText()
    {
        airStrikeText.enabled = true;
    }

    public void HideAirStrikeText()
    {
        airStrikeText.enabled = false;
    }
}
