using UnityEngine;

class Item : MonoBehaviour, IItem
{
    public GameObject prefab;
    public float velocity = 20;

    public bool Used = false;

    public Texture2D getIcon()
    {
        return null;
    }

    public void Use(IPlayerController player)
    {
        Vector3 position = player.Position;
        position.y += 1;

        GameObject instance = Instantiate(prefab, position, new Quaternion()) as GameObject;
        instance.GetComponent<Rigidbody>().velocity = player.Direction * velocity;
        instance.GetComponent<Item>().Used = true;
    }
}
