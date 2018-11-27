using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customerOrder : MonoBehaviour {
    
    public GameObject[] allBlobs;
    public List<List<GameObject>> allOrders;

    // Use this for initialization
    void Start () {
        allBlobs = GameObject.FindGameObjectsWithTag("rawblob");
        allOrders = new List<List<GameObject>>();
        // checks if the order is added 
        // GameObject[] obj = allOrders[0];
        // for (int i = 0; i < obj.Length; i++) {
        //     print("element: " + obj[i]);
        // }

        allOrders.Add(SpawnOrder());

    }

    // Update is called once per frame
    void Update () {

    }

    public void SearchandRemove(GameObject obj) {
        //print("passed on here");
        print("name is: " + obj.name);
        print("allorder length so far: " + allOrders.Capacity);
        for (int i = 0; i < allOrders.Capacity; i++) {
            List<GameObject> eachlist = this.allOrders[0];
            for (int j = 0; j < eachlist.Capacity; j++) {
                print("eachlist's elt's name: " + eachlist[j].name);
                if (obj.name == eachlist[j].name) {
                    Destroy(eachlist[j]);
                    // delete this gameobject from the eachlist as well.
                    //eachlist.Remove(eachlist[j]);
                    eachlist.RemoveAt(j);
                    // so far, this removes all clones. need to fix that!
                    break;
                }

            }
        }
    }

    // spawn order based on the random order given
    public List<GameObject> SpawnOrder() {
        float minx = -14;
        float maxx = 7;
        float miny = 6;
        float maxy = 10;
        List<GameObject> orderItems = new List<GameObject>();
        for (int i = 0; i < allBlobs.Length; i++) {
            float x = Random.Range(minx, maxx);
            float y = Random.Range(miny, maxy);
            //int index = Random.Range(0, allBlobs.Length - 1);
            GameObject tempItem = allBlobs[0];
            orderItems.Add(Instantiate(tempItem, new Vector3(x, y, 10), Quaternion.identity));
        }
        return orderItems;
    }

    //public GameObject[] RandomOrder() {
    //    GameObject[] orders = new GameObject[allBlobs.Length];
    //    //print("order's length:" + orders.Length);
    //    int index;
    //    GameObject orderItem;
    //    for (int i = 0; i < 2; i++) {
    //        index = Random.Range(0, allBlobs.Length);
    //        orderItem = allBlobs[index];
    //        orders[i] = orderItem;
    //    }
    //    return orders;
    //}

}
