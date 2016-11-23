using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlotScipt : ClickAbleUI {
	public Image itemIcon;
	public Image durabilityObject;
	public Text itemAmount;
	public int slotNumber;
	public Item.ItemClass validItemType;
	public SlotType slotType;
	public KeyCode inputKey;
	public int maxStackSize = 5;

	private Item item;
	private Image durabilityBar;
	private float size;

	void Start()
	{
		durabilityBar = durabilityObject.transform.GetChild (0).GetComponent<Image>();
		size = GetComponent<RectTransform> ().rect.width;
	}

	public void Update()
	{
		
		//Add everything related to actionBarSlots after this if statement! Everyting else before.
		if (slotType != SlotType.ActionBarSlot)
			return;
		if (Input.GetKeyDown (inputKey) && item != null) {
			ScaleDown ();
		}
		if (Input.GetKeyUp (inputKey) && item != null) {

            if (item is Weapon)
            {
                Weapon w = item as Weapon;
                if (w.currentDurability <= 0 && w.durability != 0)
                {
                    return;
                }
            }

            EquipOrUseItem();
		}
	}
    
	public override void PerformClickAction(MouseHandler mouseHandler, int mouseButton)
	{
        return;

		OnClickActions onClick = mouseHandler.onClickActions;

        if (mouseButton == 0)
        {
            if (item != null)
            {
                if (!onClick.dragging)
                {
                    onClick.StartDragging(item, this);
                    RemoveItem();
                }
                else
                {
                    onClick.EndDragging(this);
                }
                mouseHandler.onHoverActions.dragging = onClick.dragging;
            }
            else
            {
                if (onClick.dragging)
                {
                    onClick.EndDragging(this);
                    mouseHandler.onHoverActions.dragging = false;
                }
            }
        }

        if (mouseButton == 1)
        {
            onClick.QuickEquip(this);
            UndoOnHoverAction(mouseHandler);
        }
	}

	public override void PerformOnHoverAction(MouseHandler onHoverAction)
	{
        if (item == null)
			return;
		onHoverAction.onHoverActions.DisplayOnHoverInfo (item);
	}

	public override void UndoOnHoverAction(MouseHandler onHoverAction)
	{
		onHoverAction.onHoverActions.HideOnHoverInfo ();
	}
		
	public void SetItem(Item itemToAdd)
	{
		RemoveItem ();

		if (item == null) {
			item = itemToAdd;
			itemIcon.gameObject.SetActive (true);
			itemIcon.sprite = itemToAdd.itemIcon;
		} 

		if (item.itemType == Item.ItemType.Consumable) {
			itemAmount.gameObject.SetActive (true);
			itemAmount.text = item.itemAmount.ToString ();
		}
		else
			itemAmount.gameObject.SetActive (false);

        if (item.itemType == Item.ItemType.Weapon)
        {
            durabilityObject.gameObject.SetActive(true);
            UpdateItemDurability();
        }
        else
            durabilityObject.gameObject.SetActive(false);
	}

    public void EquipOrUseItem()
    {
        if (item != null && item.itemType == Item.ItemType.Weapon)
            HighlightSlot();

        ScaleUp();
        item.TakeAction(this);
        UpdateItemValues();
    }

	public void RemoveItem()
	{
        if (item == null)
            return;

        if (slotType == SlotType.ActionBarSlot)
        {
            CancelHighlight();

            if (item.master.equippedWeapon == item)
            {
                item.master.UnEquip();
            }
        }

		item = null;
		itemIcon.gameObject.SetActive (false);


	}

	public void IncreaseAmount(int amount)
	{
		item.itemAmount += amount;
		itemAmount.text = item.itemAmount.ToString ();
	}

    public void UpdateItemDurability()
    {
        if (durabilityBar != null && item != null)
        {
            Weapon weapon = item as Weapon;

            if(weapon.durability != 0)
                durabilityBar.transform.localScale = new Vector3((float)weapon.currentDurability / (float)weapon.durability, 1, 1);
        }
    }
		
	void UpdateItemValues()
	{
		if (item == null)
			return;
		itemAmount.text = item.itemAmount.ToString ();	
	}

	public Item GetItem()
	{
		return item;
	}
		
	void HighlightSlot()
	{
		//ADD something to show which weapons has been equipped.
		GameManager.Instance.inventory.actionBar.slotHandler.HighlightSlot(gameObject, size);

	}

	void CancelHighlight()
	{
        GameManager.Instance.inventory.actionBar.slotHandler.CancelHighlight (gameObject);
	}

	void ScaleDown()
	{
		itemIcon.transform.localScale = new Vector3 (0.9f, 0.9f, 1f);
	}

	void ScaleUp()
	{
		itemIcon.transform.localScale = new Vector3 (1f, 1f, 1f);
	}

	public enum SlotType
	{
		InventorySlot,
		ActionBarSlot
	}
}
