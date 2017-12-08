namespace Examples
{
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine.EventSystems;
    using Endgame;
    using System;

    public class OwnedCharacters : MonoBehaviour
    {
        class ItemData
        {
            public float SliderValue;
            public string ImageKey;
        }

        //public int selOwnedIndex = this.ListView.SelectedIndices[0];

        public string hestur;
        public GameObject Buy;
        public CharacterGenerator charGen;
        public ListView ListView;
        public GameObject ItemButtonPrefab;

        private ImageList imageList;

        public GameObject SliderPrefab;
        private Button insertItemAtCurrentPositionButton;
        private Button removeItemAtCurrentPositionButton;
        private Button toggleColumnClickModeButton;
        //Okkar kodi
        private Button buyButton;
        public int IndexOfOwnedItem;
        public int nafn;
        public string NameTest;

        public string buyTextTest;
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
            // Get references to the buttons.
            this.insertItemAtCurrentPositionButton =
                GameObject.Find("/Canvas/Buttons/InsertItemAtCurrentPositionButton").GetComponent<Button>();
            this.removeItemAtCurrentPositionButton =
                GameObject.Find("/Canvas/Buttons/RemoveItemAtCurrentPositionButton").GetComponent<Button>();
            this.toggleColumnClickModeButton =
                GameObject.Find("/Canvas/Buttons/ToggleColumnClickModeButton").GetComponent<Button>();
            //Okkar kodi
            this.buyButton = GameObject.Find("/Canvas/CharListTab/Panel/Buy").GetComponent<Button>();

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
            GameObject ChaList = GameObject.Find("CharacterListi");
            CharListi ChaListScr = ChaList.GetComponent<CharListi>();
            imageList = ChaListScr.imageList;

            // Add some images.
            //imageList.Images.Add("Healer", Healer);

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

        public ListViewItem CreateListViewItem(string imageKey, string Race, string Class, string Name, string Background, string Price, string Id)
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
        public void AddListViewItem(string imageKey, string Race, string Class, string Name, string Background, string Price, string Id)
        {
            ListViewItem item = CreateListViewItem(imageKey, Race, Class, Name, Background, Price, Id);
            this.ListView.Items.Add(item);
        }

        private void OnItemBecameVisible(ListViewItem item)
        {
        }

        private void OnItemBecameInvisible(ListViewItem item)
        {
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

                    ColumnHeader Background = new ColumnHeader();
                    Background.Text = "Background";
                    this.ListView.Columns.Add(Background);

                    ColumnHeader Price = new ColumnHeader();
                    Price.Text = "Price";
                    this.ListView.Columns.Add(Price);

                    ColumnHeader Id = new ColumnHeader();
                    Id.Text = "ID";
                    this.ListView.Columns.Add(Id);

                    List<Character> charList = charGen.CharacterList;

                    for (int i = 0; i < charList.Count; i++)
                    {
                    }
                }
                this.ListView.ResumeLayout();
            }
        }



        public void OnAddNewItemButtonClicked()
        {
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



        //Okkar kodi
        //BÆTA VIÐ KEYPTUM CHAR HÉRNA VÁ
        public void OnBuyButtonClicked()
        {
            GameObject Credits = GameObject.Find("Credits");
            MoneyScript CreditsScr = Credits.GetComponent<MoneyScript>();

            List<Character> charList = charGen.CharacterList;
            GameObject ChaList = GameObject.Find("CharacterListi");
            CharListi ChaListScr = ChaList.GetComponent<CharListi>();
            int i = ChaListScr.IndexOfItem;
            int selectedInd = ChaListScr.ListView.SelectedIndices[0];

            //STUNDUM VESEN ÞEGAR FER Í 0, CHARACTER BÆTIST EKKI VIÐ
            //max char fjöldi 10
            if (CreditsScr.money - CreditsScr.amount >= 0) // & (this.itemAddedCount <= 9))
            {
                this.itemAddedCount++;

                //MUNA AÐ BREYTA ICONI LÍKA HÉR
                string classImage = charList[i].PlayerClass; //myndirnar heita eftir classes
                AddListViewItem(classImage, charList[i].Race, charList[i].PlayerClass, charList[i].Name, charList[i].Background, charList[i].Price.ToString(), charList[i].Id.ToString());

                // Select the new item and scroll to it.
                this.ListView.SelectedIndices.Add(this.ListView.Items.Count - 1);
                this.ListView.SetVerticalScrollBarValue(1);

                //delete-a char úr sjoppunni
                ChaListScr.ListView.Items.RemoveAt(selectedInd);
            }

            else { }
        }


        public void Update()
        {
          //ATH FÁ INDEX Á ITEMI:
          List<Character> charList = charGen.CharacterList;
          GameObject CharGen = GameObject.Find("CharacterGenerator");

          if(this.ListView.SelectedIndices.Count != 0)
          {
              int selectedInd = this.ListView.SelectedIndices[0];
              NameTest = this.ListView.Items[selectedInd].SubItems[5].Text;
              nafn = Int32.Parse(NameTest);
              //index á itemi sem er ýtt á
              IndexOfOwnedItem = charList.FindIndex(x => x.Id == nafn);
          }



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
