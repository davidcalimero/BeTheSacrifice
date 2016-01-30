using UnityEngine;

class Inventory : MonoBehaviour
{
    public GameObject item;
	public Texture2D itemSlot;

	private float iconSpace = 30.0f;
	private float xOffset = 15.0f;
	private float iconSize = 30.0f;


    public IItem RequestItem(string inputKey)
    {
        return item.GetComponent<IItem>();
    }

	void OnGUI(){
		if (this.gameObject.name.Equals ("Player1")) {
			GUI.DrawTexture(new Rect(iconSpace, Screen.height - 2f*iconSize, iconSize, iconSize), itemSlot);
			GUI.DrawTexture(new Rect(iconSpace*2f + xOffset, Screen.height - 2f*iconSize, iconSize, iconSize), itemSlot);
			GUI.DrawTexture(new Rect(iconSpace*3f + xOffset*2f, Screen.height - 2f*iconSize,iconSize , iconSize), itemSlot);
			GUI.DrawTexture(new Rect(iconSpace*4f + xOffset*3f, Screen.height - 2f*iconSize,iconSize , iconSize), itemSlot);
		}

		else if(this.gameObject.name.Equals("Player2")){
			GUI.DrawTexture(new Rect(Screen.width - iconSpace*0f - xOffset*0f - 2f*iconSpace, Screen.height - 2f*iconSize, iconSize, iconSize), itemSlot);
			GUI.DrawTexture(new Rect(Screen.width - iconSpace*1f - xOffset*1f - 2f*iconSpace, Screen.height - 2f*iconSize, iconSize, iconSize), itemSlot);
			GUI.DrawTexture(new Rect(Screen.width - iconSpace*2f - xOffset*2f - 2f*iconSpace, Screen.height - 2f*iconSize, iconSize, iconSize), itemSlot);
			GUI.DrawTexture(new Rect(Screen.width - iconSpace*3f - xOffset*3f - 2f*iconSpace, Screen.height - 2f*iconSize, iconSize, iconSize), itemSlot);
		}
	}
}
