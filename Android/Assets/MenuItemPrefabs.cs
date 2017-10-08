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

    private Dictionary<string, string> types;
    private Dictionary<string, bool> repeat;
    private Dictionary<string, float> prices;
    private Dictionary<string, int> calories;
    private Dictionary<string, bool> recommended;
    private Dictionary<string, bool> allergic;
    private Dictionary<string, GameObject> menuItems;

    void Start()
    {
        types = new Dictionary<string, string>()
        {
            { "Small Bowl", "Bowl" },
            { "Large Bowl", "Bowl" },

            { "Brown Rice", "Base" },
            { "Vermicelli Noodles", "Base" },
            { "White Rice", "Base" },

            { "Beef", "Protein" },
            { "Chicken", "Protein" },
            { "Tofu", "Protein" },

            { "Carrots", "Toppings" },
            { "Cucumbers", "Toppings" },
            { "Do Chua", "Toppings" },
            { "Jalapenos", "Toppings" },
            { "Peanuts", "Toppings" },
            { "Pickled Daikon", "Toppings" },
            { "Scallions", "Toppings" },
            { "Sprouts", "Toppings" },

            { "Lime Fish Suace", "Sauce" },
            { "Peanut Sauce", "Sauce" },
            { "Ponzu Ginger Sauce", "Sauce" },
            { "Soy Sauce", "Sauce" }
        };

        repeat = new Dictionary<string, bool>()
        {
            { "Small Bowl", false },
            { "Large Bowl", false },

            { "Brown Rice", false },
            { "Vermicelli Noodles", false },
            { "White Rice", false },

            { "Beef", true },
            { "Chicken", true },
            { "Tofu", true },

            { "Carrots", true },
            { "Cucumbers", true },
            { "Do Chua", true },
            { "Jalapenos", true },
            { "Peanuts", true },
            { "Pickled Daikon", true },
            { "Scallions", true },
            { "Sprouts", true },

            { "Lime Fish Suace", false },
            { "Peanut Sauce", false },
            { "Ponzu Ginger Sauce", false },
            { "Soy Sauce", false }
        };

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
            { "Sprouts", 0.99f },

            { "Lime Fish Suace", 1.00f },
            { "Peanut Sauce", 0.50f },
            { "Ponzu Ginger Sauce", 0.50f },
            { "Soy Sauce", 0.25f }
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
            { "Sprouts", 50 },

            { "Lime Fish Suace", 125 },
            { "Peanut Sauce", 150 },
            { "Ponzu Ginger Sauce", 100 },
            { "Soy Sauce", 125 }
        };

        recommended = new Dictionary<string, bool>()
        {
            { "Small Bowl", false },
            { "Large Bowl", false },

            { "Brown Rice", false },
            { "Vermicelli Noodles", false },
            { "White Rice", false },

            { "Beef", false },
            { "Chicken", false },
            { "Tofu", false },

            { "Carrots", false },
            { "Cucumbers", true },
            { "Do Chua", false },
            { "Jalapenos", true },
            { "Peanuts", false },
            { "Pickled Daikon", false },
            { "Scallions", true },
            { "Sprouts", false },

            { "Lime Fish Suace", false },
            { "Peanut Sauce", false },
            { "Ponzu Ginger Sauce", true },
            { "Soy Sauce", false }
        };

        allergic = new Dictionary<string, bool>()
        {
            { "Small Bowl", false },
            { "Large Bowl", false },

            { "Brown Rice", false },
            { "Vermicelli Noodles", false },
            { "White Rice", false },

            { "Beef", false },
            { "Chicken", false },
            { "Tofu", false },

            { "Carrots", false },
            { "Cucumbers", true },
            { "Do Chua", false },
            { "Jalapenos", false },
            { "Peanuts", true },
            { "Pickled Daikon", false },
            { "Scallions", false },
            { "Sprouts", false },

            { "Lime Fish Suace", false },
            { "Peanut Sauce", true },
            { "Ponzu Ginger Sauce", false },
            { "Soy Sauce", false }
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
            { "Sprouts", sprouts },

            { "Lime Fish Suace", limeFishSauce },
            { "Peanut Sauce", peanutSauce },
            { "Ponzu Ginger Sauce", ponzuGingerSauce },
            { "Soy Sauce", soySauce }
        };
    }

    public string GetType(string item)
    {
        return types[item];
    }

    public bool GetRepeat(string item)
    {
        return repeat[item];
    }

    public float GetPrice(string item)
    {
        return prices[item];
    }

    public int GetCalories(string item)
    {
        return calories[item];
    }

    public bool GetRecommendation(string item)
    {
        return recommended[item];
    }

    public bool GetAllergic(string item)
    {
        return allergic[item];
    }

    public GameObject GetPrefab(string item)
    {
        return menuItems[item];
    }
}
