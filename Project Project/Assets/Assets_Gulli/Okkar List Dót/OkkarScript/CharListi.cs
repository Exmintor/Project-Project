﻿namespace Examples
{
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine.EventSystems;
    using Endgame;
    using System;

    public class CharListi : MonoBehaviour
    {
        class ItemData
        {
            public float SliderValue;
            public string ImageKey;
        }

        public string hestur;
        public GameObject Buy;
        public CharacterGenerator charGen;
        public ListView ListView;
        public GameObject ItemButtonPrefab;
        public Sprite AndrosynthGuardianIcon;
        public Sprite ArilouSkiffIcon;
        public Sprite ChenjesuBroodhomeIcon;
        public Sprite ChmmrAvatarIcon;
        public Sprite UrQuanDreadnoughtIcon;
        public Sprite DruugeMaulerIcon;
        public Sprite EarthlingCruiserIcon;
        public Sprite KorAhMarauderIcon;
        public Sprite MelnormeTraderIcon;
        public Sprite MmrnmhrmXForm;
        public Sprite MyconPodshipIcon;
        public Sprite OrzNemesisIcon;
        public Sprite PkunkFuryIcon;
        public Sprite ShofixtiScoutIcon;
        public Sprite SlylandroProbeIcon;
        public Sprite SpathiEluderIcon;
        public Sprite SupoxBladeIcon;
        public Sprite SyreenPenetratorIcon;
        public Sprite ThraddashTorchIcon;
        public Sprite UmgahDroneIcon;
        public Sprite UtwigJuggerIcon;
        public Sprite VUXIntruderIcon;
        public Sprite YehatTerminatorIcon;
        public Sprite ZoqFotPikStingerIcon;
        private ImageList imageList;
        public GameObject SliderPrefab;
        private Button insertItemAtCurrentPositionButton;
        private Button removeItemAtCurrentPositionButton;
        private Button toggleColumnClickModeButton;
        //Okkar kodi
        private Button buyButton;
        public int nafn;
        public int IndexForName;
        public string NameTest;

        public int IndexOfItem;
        public string buyTextTest;
        public string PriceOfItem;
        public int PriceOfItemInt;

        //-----
        private int itemAddedCount = 0;
        private int itemInsertedCount = 0;
        private bool clickingAColumnSorts = true;
        private bool columnSortAscending = true;
        private const int columnWidthCount = 3;
        private int columnCount
        {
            get
            {
                return this.ListView.Columns.Count;
            }
        }
        private int[] columnWidths = new int[columnWidthCount];
        private int[] columnWidthStates = null;

        public void Start()
        {

            
            //create a new item, name it, and set the parent
            GameObject newItem = Instantiate(Buy) as GameObject;
            newItem.name = gameObject.name;
            newItem.transform.parent = gameObject.transform;



            // Get references to the buttons.
            this.insertItemAtCurrentPositionButton =
                GameObject.Find("/Canvas/Buttons/InsertItemAtCurrentPositionButton").GetComponent<Button>();
            this.removeItemAtCurrentPositionButton =
                GameObject.Find("/Canvas/Buttons/RemoveItemAtCurrentPositionButton").GetComponent<Button>();
            this.toggleColumnClickModeButton =
                GameObject.Find("/Canvas/Buttons/ToggleColumnClickModeButton").GetComponent<Button>();
            //Okkar kodi
            this.buyButton = GameObject.Find("/Canvas/Buttons/Buy").GetComponent<Button>();

            // Add some test data (columns and items).
            this.AddTestData();

            // Add some events.
            // (Clicking on the first column header will sort by that column, and
            // clicking on any other column header will change that column's width
            // between default, sized to the header or sized to the longest item.)
            this.ListView.ColumnClick += OnColumnClick;

            // Initialise an array with some example column widths
            // that will be toggled between by clicking on the column header.
            // (-1 in Windows Forms means size to the longest item, and
            // -2 means size to the column header.)
            this.columnWidths[0] = 100;
            this.columnWidths[1] = 150;
            this.columnWidths[2] = 200;


            this.columnWidthStates = new int[this.columnCount];
            for (int index = 0; index < columnCount; index++)
            {
                this.columnWidthStates[index] = 0;
            }

            this.ListView.Columns[0].Width = 110;
            this.ListView.Columns[1].Width = 110;
            this.ListView.Columns[2].Width = 110;

            this.ListView.Columns[3].Width = 110;

            this.ListView.Columns[4].Width = 110;
            this.ListView.Columns[5].Width = 110;

            // Create an image list.
            imageList = new ImageList();

            // Add some images.
            imageList.Images.Add("AndrosynthGuardianIcon", AndrosynthGuardianIcon);
            imageList.Images.Add("ArilouSkiffIcon", ArilouSkiffIcon);
            imageList.Images.Add("ChenjesuBroodhomeIcon", ChenjesuBroodhomeIcon);
            imageList.Images.Add("ChmmrAvatarIcon", ChmmrAvatarIcon);
            imageList.Images.Add("UrQuanDreadnoughtIcon", UrQuanDreadnoughtIcon);
            imageList.Images.Add("DruugeMaulerIcon", DruugeMaulerIcon);
            imageList.Images.Add("EarthlingCruiserIcon", EarthlingCruiserIcon);
            imageList.Images.Add("KorAhMarauderIcon", KorAhMarauderIcon);
            imageList.Images.Add("MelnormeTraderIcon", MelnormeTraderIcon);
            imageList.Images.Add("MmrnmhrmXForm", MmrnmhrmXForm);
            imageList.Images.Add("MyconPodshipIcon", MyconPodshipIcon);
            imageList.Images.Add("OrzNemesisIcon", OrzNemesisIcon);
            imageList.Images.Add("PkunkFuryIcon", PkunkFuryIcon);
            imageList.Images.Add("ShofixtiScoutIcon", ShofixtiScoutIcon);
            imageList.Images.Add("SlylandroProbeIcon", SlylandroProbeIcon);
            imageList.Images.Add("SpathiEluderIcon", SpathiEluderIcon);
            imageList.Images.Add("SupoxBladeIcon", SupoxBladeIcon);
            imageList.Images.Add("SyreenPenetratorIcon", SyreenPenetratorIcon);
            imageList.Images.Add("ThraddashTorchIcon", ThraddashTorchIcon);
            imageList.Images.Add("UmgahDroneIcon", UmgahDroneIcon);
            imageList.Images.Add("UtwigJuggerIcon", UtwigJuggerIcon);
            imageList.Images.Add("VUXIntruderIcon", VUXIntruderIcon);
            imageList.Images.Add("YehatTerminatorIcon", YehatTerminatorIcon);
            imageList.Images.Add("ZoqFotPikStingerIcon", ZoqFotPikStingerIcon);

            // Set the listview's image list.
            this.ListView.SmallImageList = imageList;

            this.ListView.SubItemClicked += this.OnSubItemClicked;
            this.ListView.ItemChanged += this.OnItemChanged;


            RefreshToggleColumnClickButtonText();
        }

        public void OnSubItemClicked(PointerEventData pointerEventData, ListViewItem.ListViewSubItem subItem)
        {
            //Debug.Log(pointerEventData.button);
        }

        public void OnItemChanged(ListViewItem listViewItem)
        {
            //Debug.Log("Item text changed to: " + listViewItem.Text);
        }

        public void OnToggleSubItem0ImageButtonClicked()
        {
            OnToggleImageButtonClicked(0);
        }

        public void OnToggleImageButtonClicked(int index)
        {
            if (this.ListView.SelectedItems.Count > 0)
            {
                ListViewItem item = this.ListView.SelectedItems[0];
                var subitem = item.SubItems[index];

                if (subitem.ImageKey == "")
                {
                    ItemData itemData = item.Tag as ItemData;
                    subitem.ImageKey = itemData.ImageKey;
                }
                else
                {
                    subitem.ImageKey = "";
                }
            }
        }

        private int imageSizeState = 0;
        public void OnToggleImageSizeButtonClicked()
        {
            if (imageSizeState == 0)
            {
                imageList.ImageSize = new Vector2(60, 60);
            }
            else
            {
                imageList.ImageSize = new Vector2(20, 20);
            }
            imageSizeState = imageSizeState ^ 1;
        }


        //HÉR

        private ListViewItem CreateListViewItem(string imageKey, string Race, string Class, string Name, string Background, string Price, string Id)
        {
            string[] subItemTexts = new string[]
        {
            Race,
            Class,
            Name,
            Background,
            Price,
            Id


        };

            ListViewItem item = new ListViewItem(subItemTexts);

            // Add an image to the first subitem.
            item.ImageKey = imageKey;
            ItemData itemData = new ItemData();
            itemData.ImageKey = imageKey;
            itemData.SliderValue = 0;
            item.Tag = itemData;

            // NOTE: Any custom controls to be added to the list view item 
            // should be created in OnItemBecameVisible, and destroyed in
            // OnItemBecameInvisible. This is because the list view only
            // creates GameObjects to display the items that are visible,
            // rather than for every item in ListView.Items.

            return item;
        }

        //HÉR
        private void AddListViewItem(string imageKey, string Race, string Class, string Name, string Background, string Price, string Id)
        {
            ListViewItem item = CreateListViewItem(imageKey, Race, Class, Name, Background, Price, Id);
            this.ListView.Items.Add(item);
        }

        //private static float GetItemSliderValue(ListViewItem item)
        //{
        //    RectTransform customControl = item.SubItems[3].CustomControl;
        //    if (customControl != null)
        //    {
        //        return customControl.gameObject.GetComponentInChildren<Scrollbar>().value;
        //    }
        //    else
        //    {
        //        return (item.Tag as ItemData).SliderValue;
        //    }
        //}

        private void OnItemBecameVisible(ListViewItem item)
        {
            //Create a slider custom control and add it to the third subitem.
            //var subItem = item.SubItems[3];
            //GameObject slider = GameObject.Instantiate(this.SliderPrefab) as GameObject;
            //subItem.CustomControl = slider.transform as RectTransform;

            //ItemData itemData = item.Tag as ItemData;
            //slider.GetComponentInChildren<Scrollbar>().value = itemData.SliderValue;
        }

        private void OnItemBecameInvisible(ListViewItem item)
        {
            //var subItem = item.SubItems[3];
            //GameObject slider = subItem.CustomControl.gameObject;

            //// Save the value of the slider so that it can be restored
            //// when the item becomes visible again.
            //ItemData itemData = item.Tag as ItemData;
            //itemData.SliderValue = slider.GetComponentInChildren<Scrollbar>().value;

            //// Destroy the slider custom control.
            //GameObject.Destroy(subItem.CustomControl.gameObject);
        }

        private void AddTestData()
        {
            if (this.ListView != null)
            {
                this.ListView.SuspendLayout();
                {
                    this.ListView.ItemBecameVisible += this.OnItemBecameVisible;
                    this.ListView.ItemBecameInvisible += this.OnItemBecameInvisible;

                    ColumnHeader Race = new ColumnHeader();
                    Race.Text = "Race";
                    this.ListView.Columns.Add(Race);

                    ColumnHeader Class = new ColumnHeader();
                    Class.Text = "Class";
                    this.ListView.Columns.Add(Class);

                    ColumnHeader Name = new ColumnHeader();
                    Name.Text = "Name";
                    this.ListView.Columns.Add(Name);




                    //ÞESSI ER FALINN (ÚTAF SLIDER)

                    //ColumnHeader AmountInFleetColumn = new ColumnHeader();
                    //AmountInFleetColumn.Text = "Amount In Fleet";
                    //this.ListView.Columns.Add(AmountInFleetColumn);




                    ColumnHeader Background = new ColumnHeader();
                    Background.Text = "Background";
                    this.ListView.Columns.Add(Background);




                    //KEMUR EKKI RÉTT ÚT

                    ColumnHeader Price = new ColumnHeader();
                    Price.Text = "Price";
                    this.ListView.Columns.Add(Price);


                    ColumnHeader Id = new ColumnHeader();
                    Id.Text = "ID";
                    this.ListView.Columns.Add(Id);


                    List<Character> charList = charGen.CharacterList;

                    for (int i = 0; i < charList.Count; i++)
                    {
                        AddListViewItem("ArilouSkiffIcon", charList[i].Race, charList[i].PlayerClass, charList[i].Name, charList[i].Background, charList[i].Price.ToString(), charList[i].Id.ToString());
                        //AddListViewItem("ArilouSkiffIcon", charList[i].Race, charList[i].PlayerClass, charList[i].Name, charList[i].Background, charList[i].Price);

                        //AddListViewItem("ArilouSkiffIcon", "Arilou", "Skiff");
                        //AddListViewItem("ChenjesuBroodhomeIcon", "Chenjesu", "Broodhome");
                        //AddListViewItem("ChmmrAvatarIcon", "Chmmr", "Avatar");
                        //AddListViewItem("UrQuanDreadnoughtIcon", "Ur-Quan", "Dreadnought");
                        //AddListViewItem("DruugeMaulerIcon", "Druuge", "Mauler");
                        //AddListViewItem("EarthlingCruiserIcon", "Earthling", "Cruiser");
                        //AddListViewItem("KorAhMarauderIcon", "Kor-Ah", "Marauder");
                        //AddListViewItem("MelnormeTraderIcon", "Melnorme", "Trader");
                        //AddListViewItem("MmrnmhrmXForm", "Mmrnmhrm", "X-Form");
                        //AddListViewItem("MyconPodshipIcon", "Mycon", "Podship");
                        //AddListViewItem("OrzNemesisIcon", "Orz", "Nemesis");
                        //AddListViewItem("PkunkFuryIcon", "Pkunk", "Fury");
                        //AddListViewItem("ShofixtiScoutIcon", "Shofixti", "Scout");
                        //AddListViewItem("SlylandroProbeIcon", "Slylandro", "Probe");
                        //AddListViewItem("SpathiEluderIcon", "Spathi", "Eluder");
                        //AddListViewItem("SupoxBladeIcon", "Supox", "Blade");
                        //AddListViewItem("SyreenPenetratorIcon", "Syreen", "Penetrator");
                        //AddListViewItem("ThraddashTorchIcon", "Thraddash", "Torch");
                        //AddListViewItem("UmgahDroneIcon", "Umgah", "Drone");
                        //AddListViewItem("UtwigJuggerIcon", "Utwig", "Jugger");
                        //AddListViewItem("VUXIntruderIcon", "VUX", "Intruder");
                        //AddListViewItem("YehatTerminatorIcon", "Yehat", "Terminator");
                        //AddListViewItem("ZoqFotPikStingerIcon", "ZoqFotPik", "Stinger");

                    }
                }
                this.ListView.ResumeLayout();
            }
        }



        public void OnAddNewItemButtonClicked()
        {
            this.itemAddedCount++;

            //SKOÐA NOGGER

            AddListViewItem("ZoqFotPikStingerIcon", "NEW SPECIES", "SHIP ADDED (" + this.itemAddedCount + ")", "NAME", "BACKGROUND", "PRICE", "ID");

            // Select the new item and scroll to it.
            this.ListView.SelectedIndices.Add(this.ListView.Items.Count - 1);
            this.ListView.SetVerticalScrollBarValue(1);



        }

        public void OnInsertItemAtCurrentPositionButtonClicked()
        {
            this.itemInsertedCount++;

            int selectedIndex = this.ListView.SelectedIndices[0];

            //SKOÐA NOGGER

            ListViewItem item = CreateListViewItem("ZoqFotPikStingerIcon", "NEW SPECIES", "SHIP INSERTED (" + this.itemInsertedCount + ")", "NAME", "BACKGROUND", "Price", "ID");
            this.ListView.Items.Insert(selectedIndex, item);

        }

        public void OnRemoveItemAtCurrentPositionButtonClicked()
        {
            int selectedIndex = this.ListView.SelectedIndices[0];
            this.ListView.Items.RemoveAt(selectedIndex);

        }
        public List<string> idstostring;


        //Okkar kodi

        public int numVal;
        public void OnBuyButtonClicked()
        {
            List<Character> charList = charGen.CharacterList;

            GameObject CharGen = GameObject.Find("CharacterGenerator");
            CharacterGenerator CharGenScr = CharGen.GetComponent<CharacterGenerator>();
            //CharGenScr.ids.ToString();

            int selectedInd = this.ListView.SelectedIndices[0];
            buyTextTest = this.ListView.Items[selectedInd].SubItems[5].Text;
            numVal = Int32.Parse(buyTextTest);


            PriceOfItem = this.ListView.Items[selectedInd].SubItems[4].Text;
            PriceOfItemInt = Int32.Parse(PriceOfItem);

            //index á itemi sem er ýtt á
            IndexOfItem = charList.FindIndex(x => x.Id == numVal);

        }



        public void Update()
        {

            //FYRIR NAFN Á TEXTABUTTON:

            List<Character> charList = charGen.CharacterList;
            GameObject CharGen = GameObject.Find("CharacterGenerator");
            CharacterGenerator CharGenScr = CharGen.GetComponent<CharacterGenerator>();
            //CharGenScr.ids.ToString();
            int selectedInd = this.ListView.SelectedIndices[0];
            NameTest = this.ListView.Items[selectedInd].SubItems[5].Text;
            nafn = Int32.Parse(NameTest);
            //index á itemi sem er ýtt á
            IndexForName = charList.FindIndex(x => x.Id == nafn);


            // Some buttons require a selection, so disable them if there is no 
            // selection.
            bool isItemSelected = false;
            if (this.ListView != null)
            {
                if (this.ListView.SelectedIndices.Count > 0)
                {
                    isItemSelected = true;
                }
            }

            this.insertItemAtCurrentPositionButton.interactable = isItemSelected;
            this.removeItemAtCurrentPositionButton.interactable = isItemSelected;
            //Okkar kodi
            this.buyButton.interactable = isItemSelected;


        }

        private void RefreshToggleColumnClickButtonText()
        {
            this.toggleColumnClickModeButton.GetComponentInChildren<Text>().text =
                string.Format(
                    "Clicking a column header will {0} (click here to change)",
                    this.clickingAColumnSorts ? "sort" : "change its width"
                );
        }

        public void OnToggleColumnClickModeButtonClicked()
        {
            this.clickingAColumnSorts = !this.clickingAColumnSorts;

            RefreshToggleColumnClickButtonText();
        }

        private class ListViewItemComparer : IComparer
        {
            private int columnIndex = 0;
            private bool sortAscending = true;

            public ListViewItemComparer(int columnIndex, bool sortAscending)
            {
                this.columnIndex = columnIndex;
                this.sortAscending = sortAscending;
            }

            public int Compare(object object1, object object2)
            {
                int comparisonValue = CompareAscending(object1, object2);
                return this.sortAscending ? comparisonValue : -comparisonValue;
            }

            private int CompareAscending(object object1, object object2)
            {
                ListViewItem listViewItem1 = object1 as ListViewItem;
                ListViewItem listViewItem2 = object2 as ListViewItem;
                ListViewItem.ListViewSubItem subItem1 = listViewItem1.SubItems[this.columnIndex];
                ListViewItem.ListViewSubItem subItem2 = listViewItem2.SubItems[this.columnIndex];

                return CompareSubItemsByText(subItem1, subItem2);
            }

            private int CompareSubItemsByText(ListViewItem.ListViewSubItem a, ListViewItem.ListViewSubItem b)
            {
                return string.Compare(a.Text, b.Text);

            }

            public string hestur(ListViewItem.ListViewSubItem a, ListViewItem.ListViewSubItem b)
            {
                return string.Copy(a.Text);

            }

        }


        private void OnColumnClick(object sender, ListView.ColumnClickEventArgs e)
        {
            if (this.clickingAColumnSorts)
            {
                ListView listView = (ListView)sender;
                listView.ListViewItemSorter = new ListViewItemComparer(e.Column, this.columnSortAscending);
                this.columnSortAscending = !this.columnSortAscending;
            }
            else
            {
                this.IncrementColumnWidthState(e.Column);
            }
        }

        private void IncrementColumnWidthState(int columnIndex)
        {
            this.columnWidthStates[columnIndex]++;
            if (this.columnWidthStates[columnIndex] >= columnWidthCount)
            {
                this.columnWidthStates[columnIndex] = 0;
            }

            int columnWidth = this.columnWidths[this.columnWidthStates[columnIndex]];
            this.ListView.Columns[columnIndex].Width = columnWidth;
        }
    }
}
