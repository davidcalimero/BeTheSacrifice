using UnityEngine;

[RequireComponent(typeof(Character))]

class PlayerController : MonoBehaviour, IPlayerController
{
    public string inputHorizontal = "Horizontal";
    public string inputVertical = "Vertical";
    public string inputPush = "Push";
    public GameObject opponent;

    private bool canPush = false;
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
        direction = new Vector3(Input.GetAxis(inputHorizontal), 0, Input.GetAxis(inputVertical));
        character.Move(direction);

        if (Input.GetButtonDown("Fire1"))
        {
            UseItem("Fire1");
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            UseItem("Fire2");
        }

        if (Input.GetButtonDown(inputPush) && canPush)
        {
            Vector3 directionToPush = opponent.transform.position - this.gameObject.transform.position;
            this.opponent.GetComponent<Character>().Push(directionToPush.normalized * 5000);
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

    private void OnTriggerEnter(Collider col)
    {
        canPush = true;
    }

    private void OnTriggerExit(Collider col)
    {
        canPush = false;
    }
}