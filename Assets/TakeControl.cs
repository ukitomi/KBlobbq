using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeControl : MonoBehaviour {

    // first food stack
    public Transform raw1;
    // second food stack
    public Transform raw2;
    // the cooked food item 1
    public Transform cooked1;
    // the cooked food item 1
    public Transform cooked2;
    // the cooked food item 1
    public Transform burned1;
    // the cooked food item 1
    public Transform burned2;

    public Transform orderblob1;
    public Transform orderblob2;

    // the food item that's being drag and drop for cooking
    // create an arraylist to store the gameobjects....
    public Transform food1;
    // the second food item
    public Transform food2;

    // from customerOrder side
    public GameObject gm;
    public customerOrder corder;
    public List<GameObject[]> list;


    // custom range for random spawn location
    public float MinX = -7;
    public float MaxX = 3;
    public float MinY = -7;
    public float MaxY = 3;

    GameObject[] clone;
    // Use this for initialization
    void Start () {
        gm = GameObject.Find("GM");
        corder = gm.GetComponent<customerOrder>();
        //list = corder.allOrders;
        

        // try to get the order[0] from customerOrder.cs, and remove one of the gameobject 
        //GameObject[] curlist = list[0];
        ////print("0: " + curlist[0]);
        ////print("1: " + curlist[1]);
        //StartCoroutine(DestroyObjects(curlist));

        // alarm the customerOrder's orderlist, search each array and find if there's corresponding elements
        // if there is, remove
        // Q: How does one order know it's completed?
        // when one order is completed, it will be removed from the list and add points ...

    }

    // Update is called once per frame
    void Update () {

    }

    void OnMouseDown()
    {
        // food item 1
        if (gameObject.name == "blobraw1") {
            StartCoroutine(cookandburn("blobraw1"));
        }
        // food item 2
        else if (gameObject.name == "blobraw2") {
            StartCoroutine(cookandburn("blobraw2"));
        }
        else if (gameObject.name.Contains("blobcooked1")) {
            Destroy(gameObject);
            corder.SearchandRemove(gameObject);
        }
        else if (gameObject.name.Contains("blobcooked2")) {
            Destroy(gameObject);
            corder.SearchandRemove(gameObject);
        }
        // if the tag is "rawblob"
        // and the name is orderblob1
        // then remove it.
        //else if (gameObject.name.Contains("orderblob1") && gameObject.tag == "rawblob") {
        //    Destroy(gameObject);
        //    print("destroyed");
        //}
    }


    public IEnumerator cookandburn(string rawFoodName) {
        float x = Random.Range(MinX, MaxX);
        float y = Random.Range(MinY, MaxY);

        yield return new WaitForSeconds(2);
        if (rawFoodName == "blobraw1") {
            food1 = Instantiate(cooked1, new Vector3(x, y, 10), Quaternion.identity);
        }
        else if (rawFoodName== "blobraw2") {
            food1 = Instantiate(cooked2, new Vector3(x, y, 10), Quaternion.identity);

        }
        //StopCoroutine(cookandburn(rawFoodName, position));


        // if doesn't get pick up by customer within the next 5 seconds, turn it to a burn food.
    }

    public IEnumerator DestroyObjects(GameObject[] list) {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < list.Length; i++) {
            Destroy(list[i]);
        }

    }
}
