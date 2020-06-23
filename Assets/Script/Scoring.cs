using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    private int points;
    public int increment;
    public Text scoreText;
    public Text finishText;
    public Text gameoverText;
    public GameObject player;
    public GameObject timer;
    public GameObject restart;

    // Start is called before the first frame update
    void Start(){

        points = 0;
        Debug.Log ("Score: " + points);
        scoreText.text = "Score: ";

    }

    // Update is called once per frame
    void Update(){


    }

    public void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Plus")){
            Destroy (other.gameObject);
            points = points + increment;
            scoreText.text = "Score: " + points;
            Debug.Log ("Score: " + points);
        }

        if (other.gameObject.CompareTag("Minus")){
            Destroy (other.gameObject);
            points = points - increment;
            scoreText.text = "Score: " + points;
            Debug.Log ("Score: " + points);
        }

        if (other.gameObject.CompareTag("Finish")){
            Debug.Log ("You Win!");
            finishText.GetComponent<Text>().enabled = true;
            GetComponent<Movement>().enabled = false;
            timer.GetComponent<Timer>().enabled = false;

        }

        if (other.gameObject.CompareTag("Death")){
            gameOver(player);
        }

    }

    void gameOver(GameObject other){
        Debug.Log("Game Over");
        Vector3 theScale = transform.localScale;
        theScale.y = -1;
        other.transform.localScale = theScale;
        other.GetComponent<Movement>().enabled = false;
        gameoverText.GetComponent<Text>().enabled = true;
        timer.GetComponent<Timer>().enabled = false;
        restart.GetComponent<Button>().enabled = true;

    }



}
