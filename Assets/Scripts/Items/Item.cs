using UnityEngine;

class Item : MonoBehaviour, IItem
{
    public GameObject prefab;
    public float velocity = 10;
    public float damage = 20;

    public bool Used = false;

    public Texture2D getIcon()
    {
        return null;
    }

    public void Use(IPlayer player)
    {
        Vector3 position = player.Position + player.Direction * 0.4f;
        GameObject instance = Instantiate(prefab, position, new Quaternion()) as GameObject;
        instance.GetComponent<Rigidbody>().velocity = player.Direction * velocity;
        instance.GetComponent<Item>().Used = true;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            IPlayer player = col.gameObject.GetComponent<IPlayer>();
            if (Used)
            {
                player.ChangeLife(-damage);
            }

            if (Used || player.PickUp(this))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
