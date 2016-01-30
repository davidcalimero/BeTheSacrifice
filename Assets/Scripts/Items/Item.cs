using System;
using UnityEngine;

class Item : IItem
{
    public Texture2D getIcon()
    {
        return null;
    }

    public void Use(Vector3 position, Vector3 direction)
    {
        Debug.Log("fire");
    }
}
