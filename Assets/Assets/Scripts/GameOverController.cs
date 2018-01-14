using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

    public float textDelay, delayAfterDeath;
    public string fullText;
    private string currentText = "";

    // Use this for initialization
	
	public IEnumerator ShowText()
    {
        yield return new WaitForSeconds(delayAfterDeath);
        for(int i = 0; i < fullText.Length + 1; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(textDelay);
        }
        StopAllCoroutines(); //doesnt stop all coroutines, end game here
    }
}
