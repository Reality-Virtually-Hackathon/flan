using GoogleARCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class TouchManager : MonoBehaviour {
    public Camera m_firstPersonCamera;

    public GameObject dishPrefab;

    public int count = 0;

    void Update()
    {
        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }
        count++;

        GameObject dish;

        if (count == 1)
        {
            dish = Instantiate(dishPrefab);
            dish.name = "Dish";
            dish.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            dish.transform.position = m_firstPersonCamera.transform.position + m_firstPersonCamera.transform.forward;
        }
        else if (count == 2)
        {
            GameObject.Find("Dish/Menu Items").GetComponent<MenuItemsManager>().NextMenuItems();
        }
        else if (count == 3)
        {
            GameObject.Find("Dish/Menu Items/Large Bowl").AddComponent<AddItemToDish>();
        }
        else if (count == 4)
        {
            GameObject.Find("Dish/Menu Items").GetComponent<MenuItemsManager>().NextMenuItems();
        }
        else if (count == 5)
        {
            GameObject.Find("Dish/Menu Items/Brown Rice").AddComponent<AddItemToDish>();
        }
        else if (count == 6)
        {
            GameObject.Find("Dish/Menu Items").GetComponent<MenuItemsManager>().NextMenuItems();
        }
        else if (count == 7)
        {
            GameObject.Find("Dish/Menu Items/Beef").AddComponent<AddItemToDish>();
        }
        else if (count == 6)
        {
            GameObject.Find("Dish/Menu Items").GetComponent<MenuItemsManager>().NextMenuItems();
        }
        else if (count == 7)
        {
            GameObject.Find("Dish/Menu Items/Scallions").AddComponent<AddItemToDish>();
        }

        //// Perform action based on object clicked
        //if (hitInfo.collider.GetComponent<Hologram>())
        //{

        //}
        //Touch touch;
        //if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        //{
        //    return;
        //}

        //TrackableHit hit;
        //TrackableHitFlag raycastFilter = TrackableHitFlag.PlaneWithinBounds | TrackableHitFlag.PlaneWithinPolygon;

        //if (Session.Raycast(m_firstPersonCamera.ScreenPointToRay(touch.position), raycastFilter, out hit))
        //{
        //    hit.po
        //    // Create an anchor to allow ARCore to track the hitpoint as understanding of the physical
        //    // world evolves.
        //    var anchor = Session.CreateAnchor(hit.Point, Quaternion.identity);

        //    // Intanstiate an Andy Android object as a child of the anchor; it's transform will now benefit
        //    // from the anchor's tracking.
        //    var andyObject = Instantiate(m_andyAndroidPrefab, hit.Point, Quaternion.identity,
        //        anchor.transform);

        //    // Andy should look at the camera but still be flush with the plane.
        //    andyObject.transform.LookAt(m_firstPersonCamera.transform);
        //    andyObject.transform.rotation = Quaternion.Euler(0.0f,
        //        andyObject.transform.rotation.eulerAngles.y, andyObject.transform.rotation.z);

        //    // Use a plane attachment component to maintain Andy's y-offset from the plane
        //    // (occurs after anchor updates).
        //    andyObject.GetComponent<PlaneAttachment>().Attach(hit.Plane);

        //    //GameObject.Find("Menu Items").GetComponent<MenuItemsManager>().NextMenuItems();
        //    placed = true;
        //}
    }
}