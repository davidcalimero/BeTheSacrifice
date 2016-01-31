using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
	public Texture2D lifeBar;
	private float lifebarSize;
	private float maxlifebarSize;
	private float barWidth = 20.0f;
	private float yLifeBarOffset = 15f;

	void Start(){
		//_playerCharacter = this.gameObject.GetComponent <Player> ();

		maxlifebarSize = Screen.width * 0.5f - 0.1f * Screen.width;
	}

	void OnGUI(){
		if (this.gameObject.name.Equals ("Player1")) {
			lifebarSize = this.gameObject.GetComponent<Player>().LifeAmmount * maxlifebarSize * 0.01f;

			//GUI.Label(new Rect (0, 50, 100, 30), _player.lifeAmmount.ToString());
			GUI.DrawTexture(new Rect(Screen.width*0.5f - 30f, Screen.height - barWidth - yLifeBarOffset, -lifebarSize, barWidth), lifeBar);

		}
		else if(this.gameObject.name.Equals("Player2")){
			lifebarSize = this.gameObject.GetComponent<Player>().LifeAmmount * maxlifebarSize * 0.01f;

			//GUI.Label(new Rect (xOffset + 0, yOffset + 50, 100, 30), _player.lifeAmmount.ToString());
			GUI.DrawTexture(new Rect(Screen.width*0.5f + 30, Screen.height - barWidth - yLifeBarOffset , lifebarSize, barWidth), lifeBar);
		}
	}
}
