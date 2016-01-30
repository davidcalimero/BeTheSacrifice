using UnityEngine;

interface IItem
{
	Texture2D getIcon();
    void Use(IPlayer player);
}