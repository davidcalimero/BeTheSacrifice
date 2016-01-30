using UnityEngine;

interface IPlayer
{
    float LifeAmmount { get; set; }
    Vector3 Direction { get; }
    Vector3 Position { get; }
}
