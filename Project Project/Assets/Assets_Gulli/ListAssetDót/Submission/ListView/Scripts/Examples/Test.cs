using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Examples;

public class Test : MonoBehaviour
{

    Text txt;
    private int currentscore = 0;

    // Use this for initialization
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = "Score : " + currentscore;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Kappa = GameObject.Find("ListViewTester");
        CharListi Keepo = Kappa.GetComponent<CharListi>();
        string pleb = Keepo.buyTextTest;


        txt.text = pleb;
        //currentscore = PlayerPrefs.GetInt("TOTALSCORE");
        //PlayerPrefs.SetInt("SHOWSTARTSCORE", currentscore);
    }
}