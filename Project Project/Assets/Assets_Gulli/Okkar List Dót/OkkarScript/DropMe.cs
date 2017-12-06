namespace Endgame
{
	using System.Reflection;
	using UnityEngine;
	using UnityEngine.EventSystems;
	using UnityEngine.UI;
	using Examples;
	using System.Collections.Generic;
	using System.Collections;

	public class DropMe : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
	{
		public Image containerImage;
		public Image receivingImage;
		private Color normalColor;
		public Color highlightColor = Color.yellow;

		//okkar breytur:
		public CharacterGenerator charGen;
		public GameObject texti;
		Text txt;

		public void OnEnable ()
		{
			if (containerImage != null)
				normalColor = containerImage.color;
		}

		public void OnDrop(PointerEventData data)
		{
			containerImage.color = normalColor;

			if (receivingImage == null)
				return;

			Sprite dropSprite = GetDropSprite (data);
			if (dropSprite != null)
				receivingImage.overrideSprite = dropSprite;

				//OKKAR KÓÐI:

				texti = GameObject.FindWithTag("texti");
				txt = texti.GetComponent<Text>();

				List<Character> charList = charGen.CharacterList;

				GameObject OwnedListiObject = GameObject.Find("OwnedCharactersListi");
				OwnedCharacters OwnedListi = OwnedListiObject.GetComponent<OwnedCharacters>();
				int i = OwnedListi.IndexOfOwnedItem; //index númer á völdu itemi

				//nafnið á char á takkanum
				txt.text = "Nafn : " + charList[i].Name + ", Race : " + charList[i].Race + ", etc. blabla";

				//
		}

		public void OnPointerEnter(PointerEventData data)
		{
			if (containerImage == null)
				return;

			Sprite dropSprite = GetDropSprite (data);
			if (dropSprite != null)
				containerImage.color = highlightColor;
		}

		public void OnPointerExit(PointerEventData data)
		{
			if (containerImage == null)
				return;

			containerImage.color = normalColor;
		}

		//OKKAR KÓÐI:
		public GameObject[] column;
		public GameObject SpriteItem;
		public int itemIndex;

		private Sprite GetDropSprite(PointerEventData data)
		{
			var originalObj = data.pointerDrag;
			if (originalObj == null)
				return null;

			var dragMe = originalObj.GetComponent<DragMe>();
			if (dragMe == null)
				return null;

			//HÉRNA:
			GameObject charListiObject = GameObject.Find("CharacterListi");
			CharListi charListi = charListiObject.GetComponent<CharListi>();
			itemIndex = charListi.IndexOfItem; //index númer á völdu itemi

			column = GameObject.FindGameObjectsWithTag("ItemTag"); //taggið er á ItemButton prefabnum
			SpriteItem = column[itemIndex];

			var srcImage = SpriteItem.GetComponent<ItemButton>();
			if (srcImage == null)
				return null;

			return srcImage.Image.sprite;
		}

	}
}
