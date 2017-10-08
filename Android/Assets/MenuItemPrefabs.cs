using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItemPrefabs : MonoBehaviour {

    public GameObject smallBowl;
    public GameObject largeBowl;

    public GameObject brownRice;
    public GameObject whiteRice;
    public GameObject vermicelliNoodles;

    public GameObject beef;
    public GameObject chicken;
    public GameObject tofu;

    public GameObject carrots;
    public GameObject cucumbers;
    public GameObject doChua;
    public GameObject jalapenos;
    public GameObject peanuts;
    public GameObject pickledDaikon;
    public GameObject scallions;
    public GameObject sprouts;

    public GameObject limeFishSauce;
    public GameObject peanutSauce;
    public GameObject ponzuGingerSauce;
    public GameObject soySauce;

    private Dictionary<string, GameObject> menuItems;

    void Start()
    {
        menuItems = new Dictionary<string, GameObject>()
        {
            { "Small Bowl", smallBowl },
            { "Large Bowl", largeBowl },

            { "Brown Rice", brownRice },
            { "Vermicelli Noodles", vermicelliNoodles },
            { "White Rice", whiteRice },

            { "Beef", beef },
            { "Chicken", chicken },
            { "Tofu", tofu },

            { "Carrots", carrots },
            { "Cucumbers", cucumbers },
            { "Do Chua", doChua },
            { "Jalapenos", jalapenos },
            { "Peanuts", peanuts },
            { "Pickled Daikon", pickledDaikon },
            { "Scallions", scallions },
            { "Sprouts", sprouts }
        };
    }

    public GameObject GetPrefab(string item)
    {
        return menuItems[item];
    }
}
