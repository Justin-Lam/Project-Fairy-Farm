using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Item/Sword")]
public class Item_Sword : Item
{
	public override void Use()
	{
		Debug.Log("Use");
	}
}
