using UnityEngine;

public class MoneyScript : MonoBehaviour
{

    public int money;

    public void TakeMoney(int amount)
    {
        if (money - amount >= 0)

        {
            money -= amount;       
        }

        else

        {
            money += 0;
        }
    }
}