using UnityEngine;

[RequireComponent(typeof(Character))]

class PlayerController : MonoBehaviour
{
    private Character character;
    private Inventory iventory;
    private Vector3 direction;

    void Awake()
    {
        character = GetComponent<Character>();
        iventory = GetComponent<Inventory>();
        direction = transform.forward;
    }

    void Update()
    {
        Move();
        UseItems();
    }

    private void Move()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        character.Move(direction);
    }

    private void UseItems()
    {
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
        IItem item = iventory.RequestItem(inputKey);
        if (item != null)
        {
            Vector3 position = transform.position;
            position.y = 1;
            item.Use(position, direction);
        }
    }
}