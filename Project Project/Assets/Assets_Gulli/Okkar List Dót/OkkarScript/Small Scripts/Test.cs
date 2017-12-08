using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Examples;
using System.Collections.Generic;

public class Test : MonoBehaviour
{
    public CharacterGenerator charGen;
    Text txt;

    // Use this for initialization
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        List<Character> charList = charGen.CharacterList;

        GameObject ChaList = GameObject.Find("CharacterListi");
        CharListi ChaListScr = ChaList.GetComponent<CharListi>();
        int i = ChaListScr.IndexOfItem;

        //nafnið á char á takkanum
        txt.text = "Buy : " + charList[i].Name;
    }
}
