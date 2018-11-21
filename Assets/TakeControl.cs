using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeControl : MonoBehaviour {

    public Transform obj1;
    public Transform obj2;
    private Vector3 screenPoint;
    private Vector3 offset;
    public Transform food1;
    public Transform food2;
    public GameObject objname;

	// Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (objname.name.Contains("grabbedfood1")) {
            print("food1");
        }
        else if (objname.name.Contains("grabbedfood2")) {
            print("food2");
        }
        
    }

    void OnMouseDown()
    {
        if (gameObject.name == "foodimage1") {
            food1 = Instantiate(obj1, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            objname = food1.gameObject;
            // cannot do grabbedFood.transform.position.z = 10 because of struct properties.
            food1.GetComponent<SpriteRenderer>().enabled = true;
            Vector3 newPosition = food1.position;
            newPosition.z = 10;
            food1.transform.position = newPosition;
        }
        else if (gameObject.name == "foodimage2") {
            food1 = Instantiate(obj2, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            objname = food1.gameObject;
            food1.GetComponent<SpriteRenderer>().enabled = true;
            // cannot do grabbedFood.transform.position.z = 10 because of struct properties.
            Vector3 newPosition = food1.position;
            newPosition.z = 10;
            food1.transform.position = newPosition;
        }

    }

    private void OnMouseDrag()
    {
        if (food1 != null) {
            food1.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPosition = food1.position;
            newPosition.z = 10;
            food1.transform.position = newPosition;
        }
    }

    private void OnMouseUp()
    {
        // the range here determines where player drop the food
        // -2 <= x <= 5
        // -4 <= y <= 2
        if (food1.transform.position.x >= -2 && food1.transform.position.x <= 5 &&
                food1.transform.position.y >= -4 && food1.transform.position.y <= 2) {
            food1.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(food1.gameObject);
        }
        //if (food2.transform.position.x >= -2 && food2.transform.position.x <= 5 &&
        //        food2.transform.position.y >= -4 && food2.transform.position.y <= 2)
        //{
        //    food2.GetComponent<SpriteRenderer>().enabled = false;
        //    Destroy(food2.gameObject);
        //}

    }


}
