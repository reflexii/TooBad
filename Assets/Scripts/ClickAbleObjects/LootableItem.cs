using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LootableItem : ClickAbleObject 
{
	public float lifeTime = 30;
    public KeyItem.KeyItemType keyItemType;

	private Item item;
	private float timer;

    public override void Awake()
    {
        base.Awake();

        if (keyItemType != KeyItem.KeyItemType.None)
        {
            CreateItem(keyItemType);
        }
    }

    void Update()
	{
        if (keyItemType != KeyItem.KeyItemType.None)
        {
            return;
        }

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

    void CreateItem(KeyItem.KeyItemType type)
    {
        if (type == KeyItem.KeyItemType.NormalKey)
        {
            SetItem(new KeyItems.NormalKey());
        }
    }
}
