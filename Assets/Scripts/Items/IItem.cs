using UnityEngine;

interface IItem
{
	Texture2D getIcon();
    void Use(IPlayerController player);
}