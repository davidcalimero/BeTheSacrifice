using UnityEngine;
using System.Collections;

public class MusicSingleton : MonoBehaviour {

	public static MusicSingleton Instance;

	public static MusicSingleton GetInstance() {
		return Instance; 
	}
	
	void Awake() { 
		if (Instance != null && Instance != this) 
			{ Destroy(this.gameObject); return; 
		} else {
            Instance = this; 
		} 
		DontDestroyOnLoad(this.gameObject); 
	}

    public AudioClip AngelChoir;
    public AudioClip BananaHit;
    public AudioClip bzzzt;
    public AudioClip CharacterDamageVoice;
    public AudioClip CrowdScream1;
    public AudioClip CrowdScream2;
    public AudioClip ElectricShock;
    public AudioClip Empurrar;
    public AudioClip GameBackGroundTheme;
    public AudioClip GetHealth;
    public AudioClip MenuTheme;
    public AudioClip PickupItem;
    public AudioClip RockHit;
    public AudioClip TabuleiroHit;
    public AudioClip VictorySound;







}

