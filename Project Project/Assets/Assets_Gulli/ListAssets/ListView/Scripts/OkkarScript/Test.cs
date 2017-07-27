using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Examples;
using System.Collections.Generic;

public class Test : MonoBehaviour
{
    public CharacterGenerator charGen;


    Text txt;
    private int currentscore = 0;

    // Use this for initialization
    void Start()
    {

        txt = gameObject.GetComponent<Text>();
        txt.text = "Buy : " + currentscore;
    }

    // Update is called once per frame
    void Update()
    {

        List<Character> charList = charGen.CharacterList;

        GameObject ChaList = GameObject.Find("CharacterListi");
        CharListi ChaListScr = ChaList.GetComponent<CharListi>();
        int i = ChaListScr.IndexForName;
        
        //nafnið á char á takkanum
        txt.text = "Buy : " + charList[i].Name;


        /*
        eins og þetta var fyrir testing

        GameObject Kappa = GameObject.Find("CharacterListi");
        CharListi Keepo = Kappa.GetComponent<CharListi>();
        //string pleb = Keepo.buyTextTest;
        string pleb = Keepo.numVal.ToString();
        string pleb2 = Keepo.PriceOfItem;
        //int pleb = Keepo.IndexOfItem;


        txt.text = pleb.ToString() + "  " + pleb2;
        //currentscore = PlayerPrefs.GetInt("TOTALSCORE");
        //PlayerPrefs.SetInt("SHOWSTARTSCORE", currentscore);
        */
    }
}