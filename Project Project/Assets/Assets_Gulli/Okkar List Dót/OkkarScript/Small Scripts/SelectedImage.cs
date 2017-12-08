namespace Endgame {

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Examples;
using System.Collections.Generic;

public class SelectedImage : MonoBehaviour
{

	public Sprite SelSprite;

	public Sprite Warrior;
	public Sprite TimeMage;
	public Sprite OldFart;
	public Sprite Necromancer;
	public Sprite Spellsword;

	private string warString = "Warrior";
	private string mageString = "Time Mage";
	private string fartString = "Old Fart";
	private string necroString = "Necromancer";
	private string spellString = "Spellsword";

	public void itemClicked() {

		//ná í generator
		GameObject charGenObj = GameObject.Find("CharacterGenerator");
		CharacterGenerator charGenComp = charGenObj.GetComponent<CharacterGenerator>();
		List<Character> charList = charGenComp.CharacterList;

		//ná í selected tab
		GameObject SelTabObj = GameObject.Find("SelectedTab");
		SelectedTab SelTabScr = SelTabObj.GetComponent<SelectedTab>();
		int sel = SelTabScr.selectedTab;

		int i = 0;
		if (sel == 1) {
			//ná í char lista
			GameObject ChaList = GameObject.Find("CharacterListi");
			CharListi ChaListScr = ChaList.GetComponent<CharListi>();
			i = ChaListScr.IndexOfItem;
		}
		else if (sel == 2) {
			GameObject OwnChaList = GameObject.Find("OwnedCharactersListi");
			OwnedCharacters OwnChaListScr = OwnChaList.GetComponent<OwnedCharacters>();
			i = OwnChaListScr.IndexOfOwnedItem;
		}

		string itemClass = charList[i].PlayerClass;

		if (itemClass == warString) SelSprite = Warrior;
		else if (itemClass == mageString) SelSprite = TimeMage;
		else if (itemClass == fartString) SelSprite = OldFart;
		else if (itemClass == necroString) SelSprite = Necromancer;
		else SelSprite = Spellsword;
	}

}

}
