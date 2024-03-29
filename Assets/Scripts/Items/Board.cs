﻿using UnityEngine;
using System.Collections;

class Board : MonoBehaviour, IItem {

	public static float lifeGainAmmount = 30f;

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

	public void Use(IPlayer player)
	{
		player.ArmAnimator.SetTrigger ("board");
		player.ChangeLife(-lifeGainAmmount);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.gameObject.tag == "Player") {
			IPlayer player = collision.collider.gameObject.GetComponent<IPlayer> ();

			if (player.PickUp (this)) {
				DestroyI ();
			}
		} else {
			Debug.Log ("not a player");
		}
	}

	public void DestroyI()
	{
		SpawnableGameObjects.Instance.DecrementItem();
		Destroy (this.gameObject);
	}
}
