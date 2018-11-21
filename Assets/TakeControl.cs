using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeControl : MonoBehaviour {

    public Transform obj1;
    public Transform obj2;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Transform grabbedFood;

	// Use this for initialization
    void Start () {
        //Ctext.GetComponent<BoxCollider2D>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        print(gameObject.name);
        //if (Input.GetMouseButtonDown(0) && gameObject.name == "foodimage1")
        //{
        //    //grabbedFood = Instantiate(obj1, transform.position, transform.rotation);
        //    grabbedFood = Instantiate(obj1, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        //    // cannot do grabbedFood.transform.position.z = 10 because of struct properties.
        //    Vector3 newPosition = grabbedFood.position;
        //    newPosition.z = 10;
        //    grabbedFood.transform.position = newPosition;
        //    //grabbedFood.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //}
        //if (Input.GetMouseButton(0) && grabbedFood) {
        //    grabbedFood.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //}
        //if (Input.GetMouseButtonUp(0) && grabbedFood) {
        //    grabbedFood = null;
        //}

    }

    void OnMouseDown()
    {
        if (gameObject.name == "foodimage1")
        {
            //grabbedFood = Instantiate(obj1, transform.position, transform.rotation);
            //offset = grabbedFood.transform.position -
            //    Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));

            //print(offset);
            grabbedFood = Instantiate(obj1, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            // cannot do grabbedFood.transform.position.z = 10 because of struct properties.
            Vector3 newPosition = grabbedFood.position;
            newPosition.z = 10;
            grabbedFood.transform.position = newPosition;
        }

    }

    private void OnMouseDrag()
    {
        if (grabbedFood) {
            print("dragging");
            grabbedFood.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPosition = grabbedFood.position;
            newPosition.z = 10;
            grabbedFood.transform.position = newPosition;
        }
    }

    //void OnMouseDrag()
    //{
    //    //if (gameObject.name == "grabbedfood") {
    //    //    Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
    //    //    grabbedFood.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
    //    //}

    //}

    //private void OnMouseDown()
    //{
    //    if (gameObject.name == "foodimage1")
    //    {
    //        Instantiate(obj1, transform.position, transform.rotation);
    //    }
    //}
}
