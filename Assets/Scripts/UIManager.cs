using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
	//Player _player;

	public Texture2D lifeBar;
	public float lifebarSize;
	private float barWidth = 30.0f;
	private float widthFix = 5.0f;

	void Start(){
		//_playerCharacter = this.gameObject.GetComponent <Player> ();

	}

	void OnGUI(){
		if (this.gameObject.name.Equals ("Player1")) {
			//_lifebarSize = _player.lifeAmmount;

			//GUI.Label(new Rect (0, 50, 100, 30), _player.lifeAmmount.ToString());
			GUI.DrawTexture(new Rect(Screen.width*0.5f - 15f, 50, -(lifebarSize), barWidth), lifeBar);

		}
		else if(this.gameObject.name.Equals("Player2")){
			//_lifebar_size = playerManager.lifeAmmount;

			//GUI.Label(new Rect (xOffset + 0, yOffset + 50, 100, 30), _player.lifeAmmount.ToString());
			GUI.DrawTexture(new Rect(Screen.width*0.5f + 15, 50, lifebarSize, barWidth), lifeBar);
		}
	}
}
