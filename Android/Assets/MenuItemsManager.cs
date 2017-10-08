using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItemsManager : MonoBehaviour {

    public GameObject menuItemPrefab;

    private Dictionary<int, string[]> menu = new Dictionary<int, string[]>();
    private int currentMenuItem = 0;
    private string[] menu_items = new string[] { "Bowl", "Base", "Protein", "Toppings", "Sauce" };

    private bool busy = false;

    void Start()
    {
        string[] bowls = new string[] { "Small Bowl", "Large Bowl" };
        menu.Add(0, bowls);
        string[] bases = new string[] { "White Rice", "Brown Rice", "Vermicelli Noodles" };
        menu.Add(1, bases);
        string[] protein = new string[] { "Chicken", "Beef", "Tofu" };
        menu.Add(2, protein);
        string[] toppings = new string[] { "Carrots", "Cucumbers", "Do Chua", "Jalapenos", "Peanuts", "Pickled Daikon", "Scallions", "Sprouts" };
        menu.Add(3, toppings);
        string[] sauces = new string[] { "Lime Fish Sauce", "Peanut Sauce", "Ponzu Ginger Sauce", "Soy Sauce" };
        menu.Add(4, sauces);
    }

    public void NextMenuItems()
    {
        if (currentMenuItem + 1 < menu_items.Length)
        {
            if (currentMenuItem > 0)
            {
                StartCoroutine(ExitMenuItemsRight());
            }
            StartCoroutine(EnterMenuItemsLeft());
        }
        else
        {
            ErrorMenuItemsRight();
        }
    }

    public void PreviousMenuItems()
    {
        if (currentMenuItem - 1 > 0)
        {
            ExitMenuItemsLeft();
            currentMenuItem--;
            EnterMenuItemsRight();
        }
        else
        {
            ErrorMenuItemsLeft();
        }
    }

    private IEnumerator EnterMenuItemsLeft()
    {
        while (busy)
        {
            yield return new WaitForSeconds(0.1f);
        }
        busy = true;
        for (int i = 0; i < menu[currentMenuItem].Length; i++)
        {
            StartCoroutine(StartEnterMenuItemLeft(i));
            yield return new WaitForSeconds(0.25f);
        }
        currentMenuItem++;
        busy = false;
    }

    private IEnumerator StartEnterMenuItemLeft(int i)
    {
        GameObject child = Instantiate(menuItemPrefab);
        child.transform.parent = transform;

        child.GetComponent<MenuItemManager>().itemPrefab = transform.GetComponent<MenuItemPrefabs>().GetPrefab(menu[currentMenuItem][i]);
        child.GetComponent<MenuItemManager>().angle = 210 - 30 * i;

        StartCoroutine(child.GetComponent<MenuItemManager>().EnterLeft());
        yield return null;
    }

    private void EnterMenuItemsRight()
    {

    }

    private void ExitMenuItemsLeft()
    {

    }

    private IEnumerator ExitMenuItemsRight()
    {
        while (busy)
        {
            yield return new WaitForSeconds(0.1f);
        }
        busy = true;
        for (int i = 0; i < menu[currentMenuItem - 1].Length; i++)
        {
            StartCoroutine(StartExitMenuItemRight(i));
            yield return new WaitForSeconds(0.25f);
        }
        busy = false;
    }

    private IEnumerator StartExitMenuItemRight(int i)
    {
        StartCoroutine(transform.GetChild(i).GetComponent<MenuItemManager>().ExitRight());
        yield return null;
    }

    private void ErrorMenuItemsLeft()
    {

    }

    private void ErrorMenuItemsRight()
    {

    }
}