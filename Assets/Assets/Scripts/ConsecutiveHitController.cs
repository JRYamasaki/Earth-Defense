using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsecutiveHitController : MonoBehaviour 
{
    public GUIText consecutiveHitText;
    public int consecutiveHitMax;
    private int consecutiveHits;
    private AirStrikeController airStrikeController;

	void Start () 
    {
        consecutiveHits = 0;
        consecutiveHitText.text = "CONSECUTIVE HITS: 0";
        airStrikeController = GameObject.FindWithTag("AirStrikeController").GetComponent<AirStrikeController>();
	}

    public void incrementConsecutiveHits()
    {
        if(consecutiveHits < consecutiveHitMax)
        {
            consecutiveHits++;
            UpdateConsecutiveHits();
        }
    }

    public void ResetConsecutiveHits()
    {
        consecutiveHits = 0;
        airStrikeController.HideAirStrikeText();
        UpdateConsecutiveHits();
    }
	
    public void UpdateConsecutiveHits()
    {
        consecutiveHitText.text = "CONSECUTIVE HITS: " + consecutiveHits;
    }

    public bool AirStrikeIsReady()
    {
        return consecutiveHits == consecutiveHitMax;
    }
}
