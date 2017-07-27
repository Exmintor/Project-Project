

using UnityEngine;
using System.Collections;

public class MoneySystem : MonoBehaviour
{
    //an internal reference to the system itself
    private static MoneySystem _instance;

    //current balance
    public int money;

    //interval for saving the money to Playerprefs
    public float saveInterval;

    //internal variable which uses getters and setters to ensure that the money system is ALWAYS available.
    private static MoneySystem instance
    {
        get
        {
            //if the instance is null, first make sure there's not already a gameobject named MoneySystem. If there is, check for the
            //MoneySystem component and set it as instance, otherwise add the component and set the new one as instance.
            // If there isn't a gameobject named MoneySystem, make one and add the MoneySystem component.
            //Lastly, return the instance.
            if (_instance == null)
            {
                if (GameObject.Find("MoneySystem"))
                {
                    GameObject g = GameObject.Find("MoneySystem");
                    if (g.GetComponent<MoneySystem>())
                    {
                        _instance = g.GetComponent<MoneySystem>();
                    }
                    else
                    {
                        _instance = g.AddComponent<MoneySystem>();
                    }
                }
                else
                {
                    GameObject g = new GameObject();
                    g.name = "MoneySystem";
                    _instance = g.AddComponent<MoneySystem>();
                }
            }

            return _instance;
        }


        set
        {
            _instance = value;
        }
    }

    void Start()
    {
        //Make sure the Gameobject is named MoneySystem.
        gameObject.name = "MoneySystem";

        _instance = this;

        //load the saved money
        AddMoney(PlayerPrefs.GetInt("MoneySave", 0));

        //start the save interval.
        StartCoroutine("SaveMoney");
    }

    //while reality exists, save money every saveInterval.
    public IEnumerator SaveMoney()
    {
        while (true)
        {
            yield return new WaitForSeconds(saveInterval);
            PlayerPrefs.SetInt("MoneySave", instance.money);
        }
    }

    //Checks if you have enough money to buy item with cost, if you do buy it and return true. Otherwise, return false.
    public static bool BuyItem(int cost)
    {
        if (instance.money - cost >= 0)
        {
            instance.money -= cost;
            return true;
        }
        else
        {
            return false;
        }
    }









//Simply return the balance
public static int GetMoney()
    {
        return instance.money;
    }

    
    
    
    
    
    //Add some money to the balance.
    public static void AddMoney(int amount)
    {
        instance.money += amount;
    }



//Add some money to the balance.
public static void kaupa(int verd)
    {
        if (instance.money - verd >= 0)
        {
            instance.money -= verd;
            ;
        }
        else
        {
            instance.money += 0;
        }
    }




}


