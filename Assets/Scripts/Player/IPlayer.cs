using UnityEngine;

interface IPlayer
{
	string Name { get;}
    Vector3 Direction { get; }
    Vector3 Position { get; }
    bool PickUp(IItem item);
    void ChangeLife(float ammount);
    Animator ArmAnimator { get; }
    GameObject NearEnimy { get; }
    void Push(Vector3 theForce);
}
