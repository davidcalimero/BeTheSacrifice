﻿using System;
using UnityEngine;

[RequireComponent(typeof(Actuator))]

class Player : MonoBehaviour, IPlayer
{
    public float maxLife = 100;
    public int pushForce = 100000;
    public int Id = 1;
    public GameObject arm;

	public GameObject particleHeal;
    public ParticleSystem Blood;

    private bool canPush = false;
    private Actuator actuator;
    private Inventory inventory;

    private GameObject nearEnimy;
    public GameObject NearEnimy
    {
        get { return nearEnimy; }
    }

    private float lifeAmmount;
    public float LifeAmmount
    {
        get { return lifeAmmount; }
    }

	public string Name {get{ return name;}}

    public Vector3 Position { get { return transform.position; } }

    private Vector3 direction;
    public Vector3 Direction
    {
        get
        {
            if (direction.magnitude == 0)
                return transform.right;
            return direction.normalized;
        }
    }

    void Awake()
    {
        actuator = GetComponent<Actuator>();
        inventory = GetComponent<Inventory>();
        lifeAmmount = maxLife;
    }

    void Update()
    {
        if (actuator.IsOnFallState)
           return;

		if (lifeAmmount <= 0) return;

        direction = new Vector3(Input.GetAxis("Horizontal" + Id), 0, Input.GetAxis("Vertical" + Id));
        actuator.Move(direction);

        if (Input.GetButtonDown("Fire1" + Id))
        {
            UseItem(0);
        }
        else if (Input.GetButtonDown("Fire2" + Id))
        {
            UseItem(1);
        }
        else if (Input.GetButtonDown("Fire3" + Id))
        {
            UseItem(2);
        }
        else if (Input.GetButtonDown("Fire4" + Id))
        {
            UseItem(3);
        }

        if (Input.GetButtonDown("Push" + Id) && NearEnimy != null)
        {
            Animator enemyAnimator = NearEnimy.GetComponent<Animator>();
            Vector3 directionToPush = (NearEnimy.transform.position - gameObject.transform.position).normalized;
            NearEnimy.GetComponent<Actuator>().Push(directionToPush * pushForce);
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(MusicSingleton.Instance.Empurrar, 1f);

        }
    }

    public void ChangeLife(float ammount)
    {
        if (ammount < 0)
        {
            ArmAnimator.SetTrigger("damage");
            Blood.Play();
        }
        else if (lifeAmmount == 0 && ammount > 0)
        {
            GameManager.Instance.PlayerItsAlive();
        }

        lifeAmmount += ammount;
        if (lifeAmmount <= 0) lifeAmmount = 0;
        if (lifeAmmount >= maxLife) lifeAmmount = maxLife;

        if (lifeAmmount == 0)
        {
            GameManager.Instance.PlayerDeath();
            Push(Vector3.zero);
        }

        if(ammount > 0)
        {
			particleHeal.GetComponent<Animator> ().SetTrigger ("activated");
			this.gameObject.GetComponent<AudioSource>().PlayOneShot(MusicSingleton.Instance.GetHealth, 1f);

        }

        if (ammount < 0)
        {
           // this.gameObject.GetComponent<AudioSource>().PlayOneShot(MusicSingleton.Instance.CharacterDamageVoice, 1f);
        }
    }

    private void UseItem(uint itemSlot)
    {
        IItem item = inventory.useItem(itemSlot);
        if (item != null)
        {
            item.Use(this);
        }
    }

    public bool PickUp(IItem item)
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(MusicSingleton.Instance.PickupItem, 1f);
        return inventory.addItem(item);
    }

    public Animator ArmAnimator
    {
        get
        {
            return arm.GetComponent<Animator>();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        nearEnimy = col.gameObject;
    }

    void OnTriggerExit(Collider col)
    {
        nearEnimy = null;
    }

    public void Push(Vector3 theForce)
    {
        actuator.Push(theForce);
    }
}