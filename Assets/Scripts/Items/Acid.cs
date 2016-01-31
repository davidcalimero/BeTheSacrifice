using UnityEngine;

class Acid : MonoBehaviour, IItem
{
    public float autoDestroyInSeconds = 10;
    public float damage = 1;

    private Texture2D texture;

    void Start()
    {
        SpawnableGameObjects.Instance.IncrementItem();
        StartCoroutine(Utils.ExecuteAfterTime(Destroy, autoDestroyInSeconds));
    }

    public Texture2D getIcon()
    {
        return null;
    }

    public void Use(IPlayer player)
    {

    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            IPlayer player = collision.collider.gameObject.GetComponent<IPlayer>();
            player.ChangeLife(-damage);
        }
    }

    public void Destroy()
    {
        SpawnableGameObjects.Instance.DecrementItem();
        Destroy(gameObject);
    }
}
