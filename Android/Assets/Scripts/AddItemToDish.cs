using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemToDish : MonoBehaviour
{
    public GameObject dish;

    private float duration = 1f;

    private Vector3 startPoint;
    private Vector3 centerPoint;
    private Vector3 endPoint;

    private float startTime;

    private float xRadius;
    private float yRadius = 3f;
    private float zRadius;

    private bool firstHalf = true;

    private void Start()
    {
        dish = GameObject.Find("Dish");

        startPoint = transform.position;
        centerPoint = (transform.position - dish.transform.position) / 2;
        endPoint = dish.transform.position;

        xRadius = centerPoint.x;
        zRadius = centerPoint.z;

        startTime = Time.time;

        if (dish.transform.Find(gameObject.GetComponent<MenuItemManager>().type).transform.childCount <= 0)
        {
            StartCoroutine(Move());
        }
        else if (gameObject.GetComponent<MenuItemManager>().type == "Toppings" && dish.GetComponent<DishManager>().numToppings < dish.transform.Find("Toppings").transform.childCount)
        {
            StartCoroutine(Move());
        }
        else
        {
            Debug.Log("Already there!");
        }
    }

    public IEnumerator Move()
    {
        for (int i = 180; i > 0; i-=2)
        {
            float radians = i * Mathf.PI / 180f;
            transform.position = new Vector3(centerPoint.x - xRadius * Mathf.Cos(radians),
                centerPoint.y + yRadius * Mathf.Sin(radians),
                centerPoint.z - zRadius * Mathf.Cos(radians));
            yield return null;
        }
        transform.position = endPoint;
        if (gameObject.GetComponent<MenuItemManager>().type != "Toppings")
        {
            transform.parent = dish.transform.Find(gameObject.GetComponent<MenuItemManager>().type);
        }
        else
        {
            dish.GetComponent<DishManager>().numToppings++;
            transform.parent = dish.transform.Find("Toppings/Topping " + dish.GetComponent<DishManager>().numToppings);
        }
        transform.localPosition = new Vector3(0, 0, 0);
        Destroy(transform.Find("Label").gameObject);
        Destroy(this);
    }
}
