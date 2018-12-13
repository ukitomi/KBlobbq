using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingMenu : MonoBehaviour {

    public Transform endscreen;
    public Transform score;
    public Transform time;
    public Transform served;
    public Transform comment;

	// Use this for initialization
	void Start () {
        int actualscore = customerOrder.playerscore - TakeControl.burned;
        time.GetComponent<TextMesh>().text = customerOrder.totaltime + "";
        served.GetComponent<TextMesh>().text = customerOrder.customerServed + "";
        if (TakeControl.level == "easy") {
            endscreen.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("endeasy");
            score.GetComponent<TextMesh>().text = customerOrder.playerscore + "";
            comment.GetComponent<TextMesh>().text = quotes(customerOrder.playerscore);
        }
        else if (TakeControl.level == "medium") {
            endscreen.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("endmedium");
            comment.GetComponent<TextMesh>().text = quotes(customerOrder.playerscore);
            score.GetComponent<TextMesh>().text = actualscore + "";
        }
        else if (TakeControl.level == "hard") {
            endscreen.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("endhard");
            comment.GetComponent<TextMesh>().text = quotes(customerOrder.playerscore);
            score.GetComponent<TextMesh>().text = actualscore + "";
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space")) {
            SceneManager.LoadScene("TitleMenu");
        }
	}

    public void OnMouseDown()
    {

    }



    public string quotes(int score) {
        if (score > 0 && score <= 10) {
            return "I have never, ever, ever, ever\n met someone I believe in\n as little as you.";
        }
        else if (score > 10 && score <= 20) {
            return "I wish you'd jump in the oven,\n cause that will make my\n life easier.";
        }
        else if (score > 20 && score <= 30) {
            return "What are you? An idiot sandwich!";
        }
        else if (score > 30 && score <= 40) {
            return "This is slightly better than \nwhat I saw before.";
        }
        else if (score > 40 && score <= 50) {
            return "Some can handle it, and some \ncan't. I am not interested in\n the ones who can't.";
        }
        else if (score > 50 && score <= 60) {
            return "Kitchens are hard environments\n and they form incredibly strong\n characters like you.";
        }
        else if (score > 60 && score <= 70) {
            return "Well done, you earned my \nrespect.";
        }
        else if (score > 70){
            return "I have nothing to say, you are\n getting a raise soon.";
        }
        else {
            return "You are fired!";
        }
        
    }
}
