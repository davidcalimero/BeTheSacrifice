using System;
using UnityEngine;

[RequireComponent(typeof(Actuator))]

class Player : MonoBehaviour, IPlayer
{
    public float maxLife = 100;
    public int pushForce = 100000;
    public int Id = 1;
    public GameObject opponent;

    private bool canPush = false;
    private Actuator actuator;
    private Inventory inventory;

    private float lifeAmmount;
    public float LifeAmmount
    {
        get { return lifeAmmount; }
        set { lifeAmmount = Math.Max(value, 0); }
    }

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

        direction = new Vector3(Input.GetAxis("Horizontal" + Id), 0, Input.GetAxis("Vertical" + Id));
        actuator.Move(direction);

        if (Input.GetButtonDown("Fire1" + Id))
        {
            UseItem("Fire1");
        }
        else if (Input.GetButtonDown("Fire2" + Id))
        {
            UseItem("Fire2");
        }

        if (Input.GetButtonDown("Push" + Id) && canPush)
        {
            Vector3 directionToPush = (opponent.transform.position - this.gameObject.transform.position).normalized;
            this.opponent.GetComponent<Actuator>().Push(directionToPush * pushForce);
        }
    }

    private void UseItem(string inputKey)
    {
        IItem item = inventory.RequestItem(inputKey);
        if (item != null)
        {
            item.Use(this);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        canPush = true;
    }

    void OnTriggerExit(Collider col)
    {
        canPush = false;
    }
}