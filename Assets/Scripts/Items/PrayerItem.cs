using UnityEngine;
using System.Collections;

class PrayerItem : MonoBehaviour, IItem {

	private static float lifeGainAmmount = 30f;

	private Texture2D texture;

	void Awake(){
		texture = GetComponent<SpriteRenderer>().sprite.texture;
	}

	void Start () {
		SpawnableGameObjects.Instance.IncrementItem();
	}

	public Texture2D getIcon()
	{
		return texture;
	}

	//whaaaaat
	public void Use(IPlayer player)
	{
		if (player.Name.Equals ("Player1")) {
			GameObject playa = GameObject.Find ("Player2");
			playa.GetComponent<Player> ().ChangeLife (lifeGainAmmount);
		}

		if (player.Name.Equals ("Player2")) {
			GameObject playa = GameObject.Find ("Player1");
			playa.GetComponent<Player> ().ChangeLife (lifeGainAmmount);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.gameObject.tag == "Player")
		{
			IPlayer player = collision.collider.gameObject.GetComponent<IPlayer>();

			if (player.PickUp(this))
			{
				DestroyI();
			}
		}
	}


	public void DestroyI()
	{
		SpawnableGameObjects.Instance.DecrementItem();
		Destroy (this.gameObject);
	}

}
