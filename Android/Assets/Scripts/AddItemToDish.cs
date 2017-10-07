using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemToDish : MonoBehaviour
{
    public GameObject dish;

    private float duration = 1f;

    private Vector3 startPoint;
    private Vector3 midPoint;
    private Vector3 endPoint;

    private float startTime;

    private bool firstHalf = true;

    private void Start()
    {
        dish = GameObject.Find("Dish");

        startPoint = transform.position;
        midPoint = transform.position / 2 + new Vector3(0, 3, 0) - dish.transform.position;
        endPoint = dish.transform.position;

        startTime = Time.time;
    }

    void Update()
    {
        if ((Time.time - startTime) / duration > 1f)
        {
            if (firstHalf)
            {
                transform.position = midPoint;
                firstHalf = false;
                startTime = Time.time;
            }
            else
            {
                if (gameObject.GetComponent<MenuItemManager>().canAddTwo)
                {
                    gameObject.GetComponent<AddItemToDish>().enabled = false;
                    Debug.Log("...");
                    GameObject seconds = Instantiate(gameObject);
                    Destroy(seconds.GetComponent<AddItemToDish>());
                    seconds.name = gameObject.name;
                    seconds.transform.position = startPoint;
                    seconds.transform.parent = gameObject.transform.parent;
                    seconds.GetComponent<MenuItemManager>().canAddTwo = false;
                }
                transform.position = endPoint;
                transform.parent = dish.transform;
                transform.name = transform.name + " - Dish";
                Destroy(this);
            }
        }
        else
        {
            if (firstHalf)
            {
                transform.position = Vector3.Lerp(startPoint, midPoint, (Time.time - startTime) / duration);
            }
            else
            {
                transform.position = Vector3.Lerp(midPoint, endPoint, (Time.time - startTime) / duration);
            }
        }
    }
}
