using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float countdownTime;
    public GameObject player;
    public Text gameoverText;
    
    void Update()
    {
        if (countdownTime > 0.0f){
            countdownTime -= Time.deltaTime;
            timerText.text = "" + countdownTime.ToString("0.00");
        }

        if (countdownTime <= 0.0f){
            gameOver(player);
        }
    }

    void gameOver(GameObject other)
    {
        Debug.Log("Game Over");
        Vector3 theScale = transform.localScale;
        theScale.y = -1;
        other.transform.localScale = theScale;
        other.GetComponent<Movement>().enabled = false;
        gameoverText.GetComponent<Text>().enabled = true;

    }
}

