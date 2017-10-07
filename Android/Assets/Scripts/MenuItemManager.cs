using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItemManager : MonoBehaviour {

    public GameObject itemPrefab;
    public bool canAddTwo = true;

    private GameObject item;

    void Start () {
        if (itemPrefab)
        {
            UpdateInfo();
        }
    }

    public void UpdateInfo()
    {
        item = Instantiate(itemPrefab);
        item.transform.parent = transform;
        item.transform.localRotation = new Quaternion(0, 0, 0, 0);
        item.transform.localPosition = new Vector3(0, 0, 0);
        item.name = item.name.Replace("(Clone)", "");
        item.layer = LayerMask.NameToLayer("Menu Item");

        gameObject.name = item.name;
    }
}
