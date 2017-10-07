using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("wut");
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
            {
                Debug.Log("da");
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Menu Item"))
                {
                    Debug.Log("f");
                    string name = hitInfo.transform.parent.gameObject.name;
                    Vector3 startPoint = hitInfo.transform.parent.gameObject.transform.position;

                    hitInfo.transform.parent.gameObject.AddComponent<AddItemToDish>();
                    //if (hitInfo.transform.parent.GetComponent<MenuItemManager>().canAddTwo)
                    //{
                    //    Debug.Log("...");
                    //    GameObject seconds = Instantiate(hitInfo.transform.parent.gameObject);
                    //    seconds.name = gameObject.name;
                    //    seconds.transform.position = startPoint;
                    //}
                }
            }
        }
    }
}