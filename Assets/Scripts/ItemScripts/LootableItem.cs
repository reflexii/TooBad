using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LootableItem : ClickAbleObject 
{
	public float lifeTime = 30;

	private Item item;
	private float timer;

	void Update()
	{
		if (timer >= lifeTime)
			Destroy (gameObject);
		else
			timer += Time.deltaTime;
	}

	public Item GetItem()
	{
		return item;
	}

	public void DestroyItem()
	{
		Destroy (gameObject);
	}

	public void SetItem(Item item)
	{
		this.item = item;
		GetComponent<SpriteRenderer>().color = item.itemIcon;
	}

	public override void PerformClickAction(MouseHandler clickActions)
	{
		clickActions.onClickActions.lootHandler.LootItem (this);
	}

	public override void PerformOnHoverAction(MouseHandler clickActions)
	{
		clickActions.onHoverActions.DisplayOnHoverInfo (item);
	}

	public override void UndoOnHoverAction(MouseHandler clickActions)
	{
		clickActions.onHoverActions.HideOnHoverInfo();
	}
}
