/*using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlotScipt : ClickAbleUI {
	public Image itemIcon;
	public Image durabilityObject;
	public Text itemAmount;
	public int slotNumber;
	public Item.ItemType validItemType;
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
			if (item.itemType == Item.ItemType.Weapon)
				HighlightSlot ();

			ScaleUp ();
			item.TakeAction (this);
			UpdateItemValues ();
		}
	}

	public override void PerformClickAction()
	{
		if (item != null) 
		{
			if (!SlotHandler.Instance.dragging) {
				SlotHandler.Instance.StartDragging (item, this);
				RemoveItem ();
			} else {
				SlotHandler.Instance.EndDragging (this);
			}
		}
		else
		{
			if(SlotHandler.Instance.dragging) 
				SlotHandler.Instance.EndDragging (this);
		}
	}

	public override void PerformOnHoverAction()
	{
		if (item == null)
			return;
		SlotHandler.Instance.DisplayOnHoverInfo (item, transform.position, size);
	}

	public override void UndoOnHoverAction()
	{
		if (item == null)
			return;
		SlotHandler.Instance.HideOnHoverInfo ();
	}

	public void SetItem(Item itemToAdd)
	{
		RemoveItem ();

		if (item == null) {
			item = itemToAdd;
			itemIcon.gameObject.SetActive (true);
			itemIcon.color = itemToAdd.itemIcon;
		} 

		if (item.itemType == Item.ItemType.Consumable) {
			itemAmount.gameObject.SetActive (true);
			itemAmount.text = item.itemAmount.ToString ();
		}
		else
			itemAmount.gameObject.SetActive (false);

		if (item.itemType == Item.ItemType.Weapon)
			durabilityObject.gameObject.SetActive (true);
		else
			durabilityObject.gameObject.SetActive (false);
	}

	public void RemoveItem()
	{
		item = null;
		itemIcon.gameObject.SetActive (false);
		CancelHighlight ();
	}

	public void IncreaseAmount(int amount)
	{
		item.itemAmount += amount;
		itemAmount.text = item.itemAmount.ToString ();
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
		SlotHandler.Instance.HighlightSlot(gameObject, size);

	}

	void CancelHighlight()
	{
		SlotHandler.Instance.CancelHighlight (gameObject);
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
}*/