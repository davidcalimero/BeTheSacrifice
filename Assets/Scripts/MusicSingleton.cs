using UnityEngine;
using System.Collections;

public class MusicSingleton : MonoBehaviour {

	private static MusicSingleton instance;

	public static MusicSingleton GetInstance() {
		return instance; 
	}
	
	void Awake() { 
		if (instance != null && instance != this) 
			{ Destroy(this.gameObject); return; 
		} else { 
			instance = this; 
		} 
		DontDestroyOnLoad(this.gameObject); 
	}
}

