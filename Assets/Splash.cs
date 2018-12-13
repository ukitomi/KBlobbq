using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {

    private string option;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        print(option);
	}

    public void OnMouseDown()
    {
        option += gameObject.name;
        if (option == "splash") {
            SceneManager.LoadScene("TitleMenu");
            option = "";
        }


    }
}
