using UnityEngine;

[RequireComponent(typeof(Character))]

class PlayerController : MonoBehaviour, IPlayerController
{
    private Character character;
    private Inventory inventory;

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
        character = GetComponent<Character>();
        inventory = GetComponent<Inventory>();
        direction = transform.right;
    }

    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        character.Move(direction);

        if (Input.GetButtonDown("Fire1"))
        {
            UseItem("Fire1");
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            UseItem("Fire2");
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
}