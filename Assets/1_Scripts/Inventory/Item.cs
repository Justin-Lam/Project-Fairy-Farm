using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Item")]
public class Item : ScriptableObject
{
	public enum Type
	{
		TOOL,
		PLACEABLE,
		RESOURCE
	}

	public Sprite sprite;
	public Type type;
	public bool stackable;
}
