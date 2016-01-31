using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	
	void Awake () {
        this.gameObject.GetComponent<AudioSource>().clip = MusicSingleton.Instance.GameBackGroundTheme;
        this.gameObject.GetComponent<AudioSource>().Play(); //Plays the audio. 
        this.gameObject.GetComponent<AudioSource>().loop = true;
	}
}