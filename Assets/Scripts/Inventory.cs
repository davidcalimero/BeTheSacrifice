﻿using UnityEngine;

class Inventory : MonoBehaviour
{
	private const int MAX_ITEMS = 4;

	public Texture2D itemSlotBorder;

	private float iconSpace = 30.0f;
	private float xOffset = 15.0f;
	private float iconSize = 30.0f;

	public IItem[] inventoryPlayer = new IItem[MAX_ITEMS];

	public Texture2D dummyTexture;
	private Item dummyItem = new Item ();

	public IItem useItem(int inventorySlot)
	{
		Debug.Log ("ime here");
		if (inventorySlot < MAX_ITEMS && inventorySlot >= 0 ){
			IItem ret = inventoryPlayer [inventorySlot];
			inventoryPlayer [inventorySlot] = null;
			return ret;
		}
		return null;
    }

	public bool addItem(IItem possiblePickup){
		for (int i = 0; i < MAX_ITEMS; i++)
			if (inventoryPlayer [i] == null) {
				inventoryPlayer [i] = possiblePickup;
				return true;
			}
		return false;
	}

	void OnGUI(){
		if (this.gameObject.name.Equals ("Player1")) {
			GUI.DrawTexture(new Rect(iconSpace, Screen.height - 2f*iconSize, iconSize, iconSize), itemSlotBorder);
			GUI.DrawTexture(new Rect(iconSpace*2f + xOffset, Screen.height - 2f*iconSize, iconSize, iconSize), itemSlotBorder);
			GUI.DrawTexture(new Rect(iconSpace*3f + xOffset*2f, Screen.height - 2f*iconSize,iconSize , iconSize), itemSlotBorder);
			GUI.DrawTexture(new Rect(iconSpace*4f + xOffset*3f, Screen.height - 2f*iconSize,iconSize , iconSize), itemSlotBorder);

			//draw the icons on the squares
			if (inventoryPlayer [0] != null) GUI.DrawTexture(new Rect(iconSpace*1f + xOffset*0f, Screen.height - 2f*iconSize, iconSize, iconSize), dummyTexture);
			if (inventoryPlayer [1] != null) GUI.DrawTexture(new Rect(iconSpace*2f + xOffset*1f, Screen.height - 2f*iconSize, iconSize, iconSize), dummyTexture);
			if (inventoryPlayer [2] != null) GUI.DrawTexture(new Rect(iconSpace*3f + xOffset*2f, Screen.height - 2f*iconSize,iconSize , iconSize), dummyTexture);
			if (inventoryPlayer [3] != null) GUI.DrawTexture(new Rect(iconSpace*4f + xOffset*3f, Screen.height - 2f*iconSize,iconSize , iconSize), dummyTexture);
		}

		else if(this.gameObject.name.Equals("Player2")){
			GUI.DrawTexture(new Rect(Screen.width - iconSpace*0f - xOffset*0f - 2f*iconSpace, Screen.height - 2f*iconSize, iconSize, iconSize), itemSlotBorder);
			GUI.DrawTexture(new Rect(Screen.width - iconSpace*1f - xOffset*1f - 2f*iconSpace, Screen.height - 2f*iconSize, iconSize, iconSize), itemSlotBorder);
			GUI.DrawTexture(new Rect(Screen.width - iconSpace*2f - xOffset*2f - 2f*iconSpace, Screen.height - 2f*iconSize, iconSize, iconSize), itemSlotBorder);
			GUI.DrawTexture(new Rect(Screen.width - iconSpace*3f - xOffset*3f - 2f*iconSpace, Screen.height - 2f*iconSize, iconSize, iconSize), itemSlotBorder);

			if (inventoryPlayer [0] != null) GUI.DrawTexture(new Rect(Screen.width - iconSpace*0f - xOffset*0f - 2f*iconSpace, Screen.height - 2f*iconSize, iconSize, iconSize), dummyTexture);
			if (inventoryPlayer [1] != null) GUI.DrawTexture(new Rect(Screen.width - iconSpace*1f - xOffset*1f - 2f*iconSpace, Screen.height - 2f*iconSize, iconSize, iconSize), dummyTexture);
			if (inventoryPlayer [2] != null) GUI.DrawTexture(new Rect(Screen.width - iconSpace*2f - xOffset*2f - 2f*iconSpace, Screen.height - 2f*iconSize, iconSize, iconSize), dummyTexture);
			if (inventoryPlayer [3] != null) GUI.DrawTexture(new Rect(Screen.width - iconSpace*3f - xOffset*3f - 2f*iconSpace, Screen.height - 2f*iconSize, iconSize, iconSize), dummyTexture);
		}
	}

	void Update(){
		if (this.gameObject.name.Equals ("Player1")) {
			if (Input.GetKeyDown ("z")) {
				Debug.Log ("z");
				useItem (0);
			}
			if (Input.GetKeyDown ("x")) {
				Debug.Log ("x");
				useItem (1);
			}
			if (Input.GetKeyDown ("c")) {
				Debug.Log ("c");
				useItem (2);
			}
			if (Input.GetKeyDown ("v")) {
				Debug.Log ("v");
				useItem (3);
			}

			if (Input.GetKeyDown ("m")) {
				Debug.Log ("m");
				addItem (dummyItem);
			}
		}
	}

}
