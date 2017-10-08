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
    private float yRadius;
    private float zRadius;

    private bool firstHalf = true;

    private float verticalJump = 3f;

    private void Start()
    {
        dish = GameObject.Find("Dish");

        startPoint = transform.position;
        centerPoint = (transform.position - dish.transform.position) / 2;
        endPoint = dish.transform.position;

        xRadius = centerPoint.x;
        yRadius = verticalJump;
        zRadius = centerPoint.z;

        startTime = Time.time;

        if (dish.transform.Find(gameObject.GetComponent<MenuItemManager>().type).transform.childCount <= 0)
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
        transform.parent = dish.transform.Find(gameObject.GetComponent<MenuItemManager>().type).transform;
        transform.localPosition = new Vector3(0, 0, 0);
        Destroy(transform.Find("Label").gameObject);
        Destroy(this);
    }
}
