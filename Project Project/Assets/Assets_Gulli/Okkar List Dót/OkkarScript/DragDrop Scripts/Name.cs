using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Examples;
using System.Collections.Generic;

public class Name : MonoBehaviour
{
    public CharacterGenerator charGen;

    Text txt;
    private int currentscore = 0;

    // Use this for initialization
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        List<Character> charList = charGen.CharacterList;

				GameObject charListiObject = GameObject.Find("OwnedCharactersListi");
				OwnedCharacters charListi = charListiObject.GetComponent<OwnedCharacters>();
				int i = charListi.IndexOfOwnedItem; //index númer á völdu itemi

        //nafnið á char á takkanum
        txt.text = "Buy : " + charList[i].Name;
    }
}
