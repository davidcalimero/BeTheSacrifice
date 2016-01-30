using UnityEngine;

[RequireComponent(typeof(Character))]

class PlayerController : MonoBehaviour
{
    private Character character;

    void Awake()
    {
        character = GetComponent<Character>(); 
    }

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {

    }

    protected void Move()
    {
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        character.Move(direction);
    }
}