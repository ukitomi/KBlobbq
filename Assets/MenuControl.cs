using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {

    public Transform title;
    public Transform beginner;
    public Transform intermediate;
    public Transform expert;
    private string option;

	// Use this for initialization
	void Start () {
        option = "";
        //Screen.SetResolution(720, 480, false);
        //float screenRatio = Camera.main.orthographicSize / (480f / 720f);
        //camera.orthographicSize = screenRatio * (Camera.getheight / camera.GetScreenWidth());
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("Game");
        }

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
            title.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("rules");
            customerOrder.interval = 4;
            customerOrder.totaltime = 60;
            customerOrder.nextTime = 0;
            TakeControl.cooktime = 2;
            TakeControl.burntime = 5;
            TakeControl.level = "easy";
        }
        // medium level
        // burn blobs will spawn on the side plate
        // 
        else if (option == "intermediate")
        {
            title.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("rules");
            customerOrder.interval = 3;
            customerOrder.totaltime = 75;
            customerOrder.nextTime = 0;
            TakeControl.cooktime = 3;
            TakeControl.burntime = 4;
            TakeControl.level = "medium";
        }
        // hard level
        // burn blobs will spawn on the side plate
        // blobs will also switch places every .... x seconds?
        else if (option == "expert")
        {
            title.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("rules");
            customerOrder.interval = 3;
            customerOrder.totaltime = 90;
            customerOrder.nextTime = 0;
            TakeControl.cooktime = 3;
            TakeControl.burntime = 3;
            TakeControl.level = "hard";
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
