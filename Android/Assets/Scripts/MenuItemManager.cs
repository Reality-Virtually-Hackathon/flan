using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItemManager : MonoBehaviour {

    public GameObject itemPrefab;
    public string type;
    public bool repeat;
    public float price;
    public int calories;
    public bool recommended;
    public bool allergic;
    public bool canAddTwo = true;

    public int angle = 0;
    private int radius = 2;

    private GameObject item;

    void Start () {
        if (itemPrefab)
        {
            Instantiate();
        }
    }

    public void Instantiate()
    {
        item = Instantiate(itemPrefab);
        item.transform.parent = transform;
        item.transform.localPosition = new Vector3(0, 0, 0);
        item.name = item.name.Replace("(Clone)", "");
        item.layer = LayerMask.NameToLayer("Menu Item");

        gameObject.name = item.name;
        gameObject.transform.Find("Label").GetComponent<TextMesh>().text = gameObject.name + "\n" + calories + " Cal";
        if (recommended)
        {
            gameObject.transform.Find("Glow").GetComponent<Renderer>().enabled = true;
            gameObject.transform.Find("Label").GetComponent<TextMesh>().color = Color.green;
        }
    }

    public IEnumerator EnterRight()
    {
        Instantiate();
        for (int i = 360; i > angle; i -= 2)
        {
            float radians = i * Mathf.PI / 180f;
            transform.position = new Vector3(-radius * Mathf.Sin(radians), transform.position.y, radius * Mathf.Cos(radians));
            yield return null;
        }
    }

    public IEnumerator EnterLeft()
    {
        Instantiate();
        for (int i = 0; i < angle; i+=2)
        {
            float radians = i * Mathf.PI / 180f;
            transform.position = new Vector3(-radius * Mathf.Sin(radians), transform.position.y, radius * Mathf.Cos(radians));
            yield return null;
        }
    }

    public IEnumerator ExitRight()
    {
        for (int i = angle; i < 360; i += 2)
        {
            float radians = i * Mathf.PI / 180f;
            transform.position = new Vector3(-radius * Mathf.Sin(radians), transform.position.y, radius * Mathf.Cos(radians));
            yield return null;
        }
        Destroy(gameObject);
    }

    public IEnumerator ExitLeft()
    {
        for (int i = angle; i > 0; i -= 2)
        {
            float radians = i * Mathf.PI / 180f;
            transform.position = new Vector3(-radius * Mathf.Sin(radians), transform.position.y, radius * Mathf.Cos(radians));
            yield return null;
        }
        Destroy(gameObject);
    }

    public void AddToDish()
    {
        DishManager dishManager = GameObject.Find("Dish").GetComponent<DishManager>();
        dishManager.AddItem(gameObject.name);
        gameObject.AddComponent<AddItemToDish>();
    }

    public void RemoveFromDish()
    {
        DishManager dishManager = GameObject.Find("Dish").GetComponent<DishManager>();
        dishManager.RemoveItem(gameObject.name);
        //gameObject.AddComponent<RemoveItemFromDish>();
    }
}
