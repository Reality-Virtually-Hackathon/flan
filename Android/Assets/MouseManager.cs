using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Menu Item"))
                {
                    string name = hitInfo.transform.parent.gameObject.name;
                    Vector3 startPoint = hitInfo.transform.parent.gameObject.transform.position;

                    hitInfo.transform.parent.gameObject.AddComponent<AddItemToDish>();
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameObject.Find("Menu Items").GetComponent<MenuItemsManager>().NextMenuItems();
        }
    }
}