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

	[field: SerializeField] public string Name { get; private set; }
	[field: SerializeField] public ItemType Type { get; private set; }
	[field: SerializeField] public int MaxStackSize { get; private set; } = 1;
	[field: SerializeField] public float UseCooldown { get; private set; } = 0;
	[field: SerializeField] public Sprite Sprite { get; private set; }

	[HideInInspector] public int StackSize { get; private set; } = 1;

	public void AddToStack(int amount) { StackSize += amount; }

	public virtual void Use() { }
}
