using UnityEngine;

interface IPlayer
{
    Vector3 Direction { get; }
    Vector3 Position { get; }
    bool PickUp(IItem item);
    void ChangeLife(float ammount);
}
