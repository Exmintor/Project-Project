using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Examples;

public class CreditsText : MonoBehaviour
{

    Text txt;

    // Use this for initialization
    void Start()
    {
        
        txt = gameObject.GetComponent<Text>();
        txt.text = "Credits : ";
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Credits = GameObject.Find("Credits");
        MoneyScript CreditsScr = Credits.GetComponent<MoneyScript>();
        txt.text = "Credits : " + CreditsScr.money.ToString();
    }
}