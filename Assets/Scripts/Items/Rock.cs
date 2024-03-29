﻿using UnityEngine;

class Rock : MonoBehaviour, IItem
{
    public string prefabPath;
    public float force = 10;
    public float damage = 20;

    private Texture2D texture;

    public bool Used = false;

    void Awake()
    {
        texture = GetComponent<SpriteRenderer>().sprite.texture;
    }

    void Start()
    {
        SpawnableGameObjects.Instance.IncrementItem();
    }

    public Texture2D getIcon()
    {
        return texture;
    }

    private string playerName;
    public void Use(IPlayer player)
    {
        playerName = player.Name;
        Vector3 position = player.Position + player.Direction * 0.4f;
        GameObject instance = Instantiate(Resources.Load(prefabPath), position, new Quaternion()) as GameObject;
        instance.GetComponent<Rigidbody>().AddForce(player.Direction * force, ForceMode.Impulse);
        instance.GetComponent<Rock>().Used = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && playerName != collision.gameObject.name)
        {
            IPlayer player = collision.collider.gameObject.GetComponent<IPlayer>();
            if (Used)
            {
                player.ChangeLife(-damage);
                player.Push(Vector3.zero);
                this.gameObject.GetComponent<AudioSource>().PlayOneShot(MusicSingleton.Instance.RockHit, 1f);

            }

            if (Used || player.PickUp(this))
            {
                Destroy();
            }
        }
        else if (Used)
        {
            Destroy();
        }
        else
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    public void Destroy()
    {
        SpawnableGameObjects.Instance.DecrementItem();
        Destroy(gameObject);
    }
}
