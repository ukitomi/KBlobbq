using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class TakeControl : MonoBehaviour {

    // food stacks
    public Transform raw1;
    public Transform raw2;
    public Transform raw3;
    public Transform raw4;
    public Transform raw5;

    // cooked items
    public Transform cooked1;
    public Transform cooked2;
    public Transform cooked3;
    public Transform cooked4;
    public Transform cooked5;

    // burned items
    public Transform burned1;
    public Transform burned2;
    public Transform burned3;
    public Transform burned4;
    public Transform burned5;

    // from customerOrder side
    public GameObject gm;
    public customerOrder corder;

    // custom range for random spawn location
    public float MinX = -7;
    public float MaxX = 3;
    public float MinY = -7;
    public float MaxY = 3;

    // cooktime and burntime adjusted by level
    public static float cooktime;
    public static float burntime;
    public static string level;

    // hard level list
    public static List<string> list;


    // Use this for initialization
    void Start () {
        gm = GameObject.Find("GM");
        corder = gm.GetComponent<customerOrder>();

        // for hard level shuffling
        if (level == "hard") {
            raw1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("mysteryblob");
            raw2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("mysteryblob");
            raw3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("mysteryblob");
            raw4.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("mysteryblob");
            raw5.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("mysteryblob");

            cooked1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(list[0]);
            cooked2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(list[1]);
            cooked3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(list[2]);
            cooked4.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(list[3]);
            cooked5.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(list[4]);
        }

        //for (int i = 0; i < list.Count; i++) {
        //    print("list elt: " + list[i]);
        //}
        // set each raw sprite to mystery blob
        // randomized each cooked sprite
        // we dont need to care about burned
    }


    // Update is called once per frame
    void Update () {

    }

    void OnMouseDown()
    {
        // food item 1
        if (gameObject.name == "blobraw1") {
            StartCoroutine(cookandburn("blobraw1"));
            gameObject.GetComponent<AudioSource>().Play();
        }
        // food item 2
        else if (gameObject.name == "blobraw2") {
            StartCoroutine(cookandburn("blobraw2"));
            gameObject.GetComponent<AudioSource>().Play();
        }
        else if (gameObject.name == "blobraw3")
        {
            StartCoroutine(cookandburn("blobraw3"));
            gameObject.GetComponent<AudioSource>().Play();
        }
        else if (gameObject.name == "blobraw4")
        {
            StartCoroutine(cookandburn("blobraw4"));
            gameObject.GetComponent<AudioSource>().Play();
        }
        else if (gameObject.name == "blobraw5")
        {
            StartCoroutine(cookandburn("blobraw5"));
            gameObject.GetComponent<AudioSource>().Play();
        }
        else if (gameObject.name.Contains("blobcooked1")) {
            if(corder.SearchandRemove(gameObject)) {
                Destroy(gameObject);
            };
        }
        else if (gameObject.name.Contains("blobcooked2")) {
            if (corder.SearchandRemove(gameObject)) {
                Destroy(gameObject);
            }
        }
        else if (gameObject.name.Contains("blobcooked3"))
        {
            if (corder.SearchandRemove(gameObject))
            {
                Destroy(gameObject);
            }
        }
        else if (gameObject.name.Contains("blobcooked4"))
        {
            if (corder.SearchandRemove(gameObject))
            {
                Destroy(gameObject);
            }
        }
        else if (gameObject.name.Contains("blobcooked5"))
        {
            if (corder.SearchandRemove(gameObject))
            {
                Destroy(gameObject);
            }
        }
    }

    public IEnumerator cookandburn(string rawFoodName) {
        float x = Random.Range(MinX, MaxX);
        float y = Random.Range(MinY, MaxY);

        float a = Random.Range(10, 20);
        float b = Random.Range(-6, 2);
        yield return new WaitForSeconds(cooktime);
        if (rawFoodName == "blobraw1")
        {
            Transform clone = Instantiate(cooked1, new Vector3(x, y, 10), Quaternion.identity);
            yield return new WaitForSeconds(burntime);
            if (level == "easy") {
            }
            // medium or hard level
            else {
                Destroy(clone.gameObject);
                clone = Instantiate(burned1, new Vector3(a, b, 10), Quaternion.identity);
            }
        }
        else if (rawFoodName== "blobraw2") {
            Transform clone = Instantiate(cooked2, new Vector3(x, y, 10), Quaternion.identity);
            yield return new WaitForSeconds(burntime);
            if (level == "easy") {
            }
            // medium or hard level
            else
            {
                Destroy(clone.gameObject);
                clone = Instantiate(burned2, new Vector3(a, b, 10), Quaternion.identity);
            }
        }
        else if (rawFoodName == "blobraw3")
        {
            Transform clone = Instantiate(cooked3, new Vector3(x, y, 10), Quaternion.identity);
            yield return new WaitForSeconds(burntime);
            if (level == "easy")
            {
            }
            // medium or hard level
            else
            {
                Destroy(clone.gameObject);
                clone = Instantiate(burned2, new Vector3(a, b, 10), Quaternion.identity);
            }
        }
        else if (rawFoodName == "blobraw4")
        {
            Transform clone = Instantiate(cooked4, new Vector3(x, y, 10), Quaternion.identity);
            yield return new WaitForSeconds(burntime);
            if (level == "easy")
            {
            }
            // medium or hard level
            else
            {
                Destroy(clone.gameObject);
                clone = Instantiate(burned2, new Vector3(a, b, 10), Quaternion.identity);
            }
        }
        else if (rawFoodName == "blobraw5")
        {
            Transform clone = Instantiate(cooked5, new Vector3(x, y, 10), Quaternion.identity);
            yield return new WaitForSeconds(burntime);
            if (level == "easy")
            {
            }
            // medium or hard level
            else
            {
                Destroy(clone.gameObject);
                clone = Instantiate(burned2, new Vector3(a, b, 10), Quaternion.identity);
            }
        }
    }

}
