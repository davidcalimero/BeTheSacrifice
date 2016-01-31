using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	
	void Start () {
        this.gameObject.GetComponent<AudioSource>().clip = MusicSingleton.Instance.GameBackGroundTheme;
        this.gameObject.GetComponent<AudioSource>().volume = 1f;
        this.gameObject.GetComponent<AudioSource>().Play(); //Plays the audio. 
        this.gameObject.GetComponent<AudioSource>().loop = true;
        

    }
}