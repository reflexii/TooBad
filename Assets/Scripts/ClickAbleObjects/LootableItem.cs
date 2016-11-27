using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LootableItem : ClickAbleObject 
{
	public float lifeTime = 30;
    public KeyItem.KeyItemType keyItemType;
    public Item.ItemClass predefItem;

	protected Item item;
	private float timer;

    public override void Start()
    {
        base.Start();

        if (keyItemType != KeyItem.KeyItemType.None)
        {
            CreateItem(keyItemType);
        }

        if (predefItem != Item.ItemClass.None)
        {
            CreateItem(predefItem);
        }
    }

    void Update()
	{
        if (keyItemType != KeyItem.KeyItemType.None || lifeTime == 0)
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
		GetComponent<SpriteRenderer>().sprite = item.itemIcon;
	}

	public override void PerformClickAction(MouseHandler clickActions, int mouseButton)
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

    void CreateItem(Item.ItemClass type)
    {
        if (type == Item.ItemClass.Mushroom)
        {
            SetItem(new Consumables.Mushroom());
        }

        else if (type == Item.ItemClass.Sword)
        {
            SetItem(new Weapons.LongSword());
        }
        else if (type == Item.ItemClass.Axe)
        {
            SetItem(new Weapons.Axe());
        }
        else if (type == Item.ItemClass.Crossbow)
        {
            SetItem(new Weapons.CrossBow());

        }
        else if (type == Item.ItemClass.Wand)
        {
            SetItem(new Weapons.FireWand());
        }
    }

}
