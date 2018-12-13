using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// In other words, Capacity is the total space available in the List at present, whereas Count is the total space you've used of that capacity.
public class customerOrder : MonoBehaviour {
    
    public GameObject[] allBlobs;
    public List<List<GameObject>> allOrders;
    //public int totaltime = 20;
    public Transform score;
    public Transform timer;

    private bool slot0;
    private bool slot1;
    private bool slot2;
    private bool slot3;

    public static float interval;
    public static float nextTime;
    private float time;
    private int timerCount;
    public static float totaltime;
    public static int customerServed;
    public static int playerscore;



    // Use this for initialization
    void Start () {
        allBlobs = GameObject.FindGameObjectsWithTag("rawblob");
        allOrders = new List<List<GameObject>>(new List<GameObject>[4]);
        slot0 = false;
        slot1 = false;
        slot2 = false;
        slot3 = false;
        playerscore = 0;
        customerServed = 0;
        timerCount = (int)totaltime;
        StartCoroutine(LoseTime());
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update () {
        time = Time.timeSinceLevelLoad;
        if (time >= nextTime) {
            nextTime += interval;

            // every two seconds, check on the available slot and spawn order!
            // check one spot, if not available, check second, stop at the available one and spawn order.
            // need to make sure that on the spawn order, uncheck the boolean associate with the slot.
            // whenever you remove a list, turn one of the boolean off (starting from top if it's in true state?)
            if (!slot0) {
                allOrders[0] = SpawnOrder(-6);
                slot0 = true;
            }
            else if (!slot1) {
                allOrders[1] = SpawnOrder(1);
                slot1 = true;
            }
            else if (!slot2) {
                allOrders[2] = SpawnOrder(8);
                slot2 = true;
            }
            else if (!slot3) {
                allOrders[3] = SpawnOrder(15);
                slot3 = true;
            }
        }
        else if (time >= totaltime) {
            SceneManager.LoadScene("EndingMenu");
        }
        score.GetComponent<TextMesh>().text = "Player Score: " + playerscore;
        timer.GetComponent<TextMesh>().text = "Timer: " + timerCount;
    }

    public bool SearchandRemove(GameObject obj) {
        //print("passed on here");
        for (int i = 0; i < allOrders.Count; i++) {
            List<GameObject> eachlist = this.allOrders[i];
            for (int j = 0; j < eachlist.Count; j++) {
                if (obj.name == eachlist[j].name)
                {
                    Destroy(eachlist[j]);
                    eachlist.RemoveAt(j);
                    if (eachlist.Count == 0) {
                        if (i == 0) {
                            slot0 = false;
                        }
                        else if (i == 1) {
                            slot1 = false;
                        }
                        else if (i == 2) {
                            slot2 = false;
                        }
                        else if (i == 3) {
                            slot3 = false;
                        }
                        playerscore += 5;
                        customerServed++;

                    }
                    return true;
                }
            }
        }
        return false;
    }

    // spawn order based on the random order given
    public List<GameObject> SpawnOrder(float x)
    {
        float y = 8;
        // different x, same y
        List<GameObject> orderItems = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            GameObject tempItem = allBlobs[Random.Range(0, allBlobs.Length)];
            orderItems.Add(Instantiate(tempItem, new Vector3(x, y, 10), Quaternion.identity));
            x -= 1;
        }
        return orderItems;
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timerCount--;
        }
    }

}
