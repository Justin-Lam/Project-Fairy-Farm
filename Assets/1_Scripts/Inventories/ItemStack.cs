public class ItemStack
{
	public Item Item {  get; private set; }
	public int Size { get; private set; }

	public void Set(Item item, int amount = 1)
	{
		Item = item;
		Size = amount;
	}
	public void Add(int amount) { Size += amount; }
}
