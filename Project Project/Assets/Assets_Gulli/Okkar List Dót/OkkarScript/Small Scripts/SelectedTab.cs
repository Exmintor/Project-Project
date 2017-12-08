using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Examples;
using System.Collections.Generic;

public class SelectedTab : MonoBehaviour
{
	public int selectedTab;

	void Start() {
		selectedTab = 1;
	}

	public void CharList() {
		selectedTab = 1;
	}

	public void OwnedList() {
		selectedTab = 2;
	}
}
