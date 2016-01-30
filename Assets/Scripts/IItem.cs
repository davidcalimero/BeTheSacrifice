using UnityEngine;

interface IItem
{
	Texture2D getIcon();
    void Use(Vector3 position, Vector3 direction);
}