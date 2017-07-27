using Examples;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    public int amount;
    public int money;

    public void TakeMoney()
    {
        GameObject CharList = GameObject.Find("CharacterListi");
        CharListi CharListScr = CharList.GetComponent<CharListi>();
        amount = CharListScr.PriceOfItemInt;

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