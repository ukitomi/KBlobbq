using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeControl : MonoBehaviour {

    // first food stack
    public Transform obj1;
    // second food stack
    public Transform obj2;
    // the food item that's being drag and drop for cooking
    private Transform food1;
    // ??
    private Transform cookedfood;
    // object name of the drag and drop raw food, so we know what kinds of food we are making
    public GameObject objname;
    // the spawn and finished food, we probably need three more since our plates have 3 slots...
    public GameObject spawn1;


	// Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnMouseDown()
    {
        // food item 1
        if (gameObject.name == "foodimage1") {
            food1 = Instantiate(obj1, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            objname = food1.gameObject;
            // cannot do grabbedFood.transform.position.z = 10 because of struct properties.
            food1.GetComponent<SpriteRenderer>().enabled = true;
            Vector3 newPosition = food1.position;
            newPosition.z = 10;
            food1.transform.position = newPosition;
        }
        // food item 2
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
        // the range here determines where player drop the food, customizable
        // -2 <= x <= 5
        // -4 <= y <= 2
        if (food1.transform.position.x >= -2 && food1.transform.position.x <= 5 &&
                food1.transform.position.y >= -4 && food1.transform.position.y <= 2) {
            Vector3 position = food1.position;
            food1.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(food1.gameObject);
            // instantiate something after 5 seconds at certain position..
            if (objname.name.Contains("grabbedfood1")) {
                print("instantiating...");
                // wait for 5 seconds here
                StartCoroutine(cookandburn(spawn1, position));
                // if the item is not picked up by 5 seconds, then it will turn into a burned food
            }
        }
    }

    public IEnumerator cookandburn(GameObject obj, Vector3 position) {

        yield return new WaitForSeconds(2);
        Instantiate(spawn1, new Vector3(position.x, position.y - 5, position.z), Quaternion.identity);

        // if doesn't get pick up by customer within the next 5 seconds, turn it to a burn food.
    }


}
