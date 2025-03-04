using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Item")]
public class Item : ScriptableObject
{
	public enum Type
	{
		Tool,
		Placeable,
		Resource
	}

	[field: SerializeField] public Sprite sprite { get; private set; }
	[field: SerializeField] public Type type { get; private set; }
	[field: SerializeField] public int maxStackSize { get; private set; } = 1;
	[field: SerializeField] public float useCooldown { get; private set; } = 0;


	public virtual void Use() { }
}
