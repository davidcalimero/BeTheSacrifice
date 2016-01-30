using UnityEngine;

class Inventory : MonoBehaviour
{
    public GameObject item;

    public IItem RequestItem(string inputKey)
    {
        return item.GetComponent<IItem>();
    }
}
