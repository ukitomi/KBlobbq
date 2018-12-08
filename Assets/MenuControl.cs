using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {

    public Transform beginner;
    public Transform intermediate;
    public Transform expert;
    private string option;

	// Use this for initialization
	void Start () {
        Screen.SetResolution(1440, 900, true);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseDown()
    {
        option += gameObject.name;
        // easy level:
        // no burn blobs
        // order will generate super fast
        // 
        if (option == "beginner")
        {
            SceneManager.LoadScene("Game");
            customerOrder.interval = 3;
            customerOrder.totaltime = 30;
            customerOrder.nextTime = 0;
            TakeControl.cooktime = 2;
            TakeControl.burntime = 5;
            TakeControl.level = "easy";
            option = "";
        }
        // medium level
        // burn blobs will spawn on the side plate
        // 
        else if (option == "intermediate")
        {
            SceneManager.LoadScene("Game");
            customerOrder.interval = 5;
            customerOrder.totaltime = 30;
            customerOrder.nextTime = 0;
            TakeControl.cooktime = 3;
            TakeControl.burntime = 3;
            TakeControl.level = "medium";
            option = "";
        }
        // hard level
        // burn blobs will spawn on the side plate
        // blobs will also switch places every .... x seconds?
        else if (option == "expert")
        {
            SceneManager.LoadScene("Game");
            customerOrder.interval = 5;
            customerOrder.totaltime = 30;
            customerOrder.nextTime = 0;
            TakeControl.cooktime = 3;
            TakeControl.burntime = 3;
            TakeControl.level = "hard";
            option = "";
            TakeControl.list = new List<string>();
            TakeControl.list.Add("redblobcooked");
            TakeControl.list.Add("pinkblobcooked");
            TakeControl.list.Add("yellowblobcooked");
            TakeControl.list.Add("blueblobcooked");
            TakeControl.list.Add("greenblobcooked");
            Shuffle(TakeControl.list);
        }
    }

    void Shuffle(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            string x = list[i];
            int r = Random.Range(i, list.Count);
            list[i] = list[r];
            list[r] = x;
        }
    }
}
