using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject raw1;
    public GameObject raw2;

    public GameObject cooked1;
    public GameObject cooked2;

    public GameObject burned1;
    public GameObject burned2;

    // Use this for initialization
    void Start () {
        raw1 = (GameObject)Resources.Load<GameObject>("redblobraw");
        //raw2 = Resources.Load<GameObject>("blueblobraw");

    }
	
	// Update is called once per frame
	void Update () {
        Instantiate(raw1, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        print("INSTANTIATINGGGGG");
	}


}
