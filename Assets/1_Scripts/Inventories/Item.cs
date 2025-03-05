using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Item")]
public class Item : ScriptableObject
{
	public enum ItemType
	{
		Tool,
		Placeable,
		Resource
	}

	[field: Header("Gameplay")]
	[field: SerializeField] public ItemType Type { get; private set; }
	[field: SerializeField] public int MaxStackSize { get; private set; } = 1;
	[field: SerializeField] public float UseCooldown { get; private set; } = 0;

	[field: Header("Art")]
	[field: SerializeField] public Sprite Sprite { get; private set; }

	public virtual void Use() { }
}
