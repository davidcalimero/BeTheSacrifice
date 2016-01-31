using UnityEngine;

class Seringa : MonoBehaviour, IItem
{
    private Texture2D texture;

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

    IPlayer player;
    public void Use(IPlayer player)
    {
        player.ArmAnimator.SetTrigger("seringa");
        StartCoroutine(Utils.ExecuteAfterTime(() => player.ArmAnimator.ResetTrigger("seringa"), 2));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            IPlayer player = collision.collider.gameObject.GetComponent<IPlayer>();
            if (player.PickUp(this))
            {
                Destroy();
            }
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
