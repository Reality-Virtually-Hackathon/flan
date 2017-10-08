﻿using System.Collections;
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

    private Dictionary<string, float> prices;
    private Dictionary<string, int> calories;
    private Dictionary<string, GameObject> menuItems;

    void Start()
    {
        prices = new Dictionary<string, float>()
        {
            { "Small Bowl", 2.99f },
            { "Large Bowl", 4.99f },

            { "Brown Rice", 1.99f },
            { "Vermicelli Noodles", 1.99f },
            { "White Rice", 1.99f },

            { "Beef", 1.99f },
            { "Chicken", 1.99f },
            { "Tofu", 1.49f },

            { "Carrots", 0.99f },
            { "Cucumbers", 0.99f },
            { "Do Chua", 0.99f },
            { "Jalapenos", 0.99f },
            { "Peanuts", 0.99f },
            { "Pickled Daikon", 0.99f },
            { "Scallions", 0.99f },
            { "Sprouts", 0.99f }
        };

        calories = new Dictionary<string, int>()
        {
            { "Small Bowl", 0 },
            { "Large Bowl", 0 },

            { "Brown Rice", 250 },
            { "Vermicelli Noodles", 400 },
            { "White Rice", 300 },

            { "Beef", 200 },
            { "Chicken", 150 },
            { "Tofu", 125 },

            { "Carrots", 50 },
            { "Cucumbers", 75 },
            { "Do Chua", 150 },
            { "Jalapenos", 50 },
            { "Peanuts", 50 },
            { "Pickled Daikon", 100 },
            { "Scallions", 75 },
            { "Sprouts", 50 }
        };

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

    public float GetPrice(string item)
    {
        return prices[item];
    }

    public int GetCalories(string item)
    {
        return calories[item];
    }

    public GameObject GetPrefab(string item)
    {
        return menuItems[item];
    }
}
