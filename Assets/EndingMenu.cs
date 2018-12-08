using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingMenu : MonoBehaviour {

    public Transform score;
    public Transform time;
    public Transform served;

	// Use this for initialization
	void Start () {
        score.GetComponent<TextMesh>().text = customerOrder.playerscore + "";
        time.GetComponent<TextMesh>().text = customerOrder.totaltime + "";
        served.GetComponent<TextMesh>().text = customerOrder.customerServed + "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseDown()
    {
        SceneManager.LoadScene("TitleMenu");
    }
}
