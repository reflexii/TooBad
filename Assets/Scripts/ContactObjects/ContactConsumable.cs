using UnityEngine;
using System.Collections;
using System;

public class ContactConsumable : ContactObject {

    public Item.ItemClass consumableType;

     void Start()
    {
        base.Start();

        if (consumableType == Item.ItemClass.RageDrug)
        {
            SetItem(new Consumables.NormalRageDrug());
        }
        else
        {
            Debug.Log(this.ToString() + " unknown consumableType: " + consumableType);
        }
    }

    protected override void TakeAction(Collider2D col)
    {
        if (col.tag == "Player")
        {
            item.master = col.GetComponent<Character>();
            item.TakeAction(null);
            Destroy(gameObject);
        }
    }
}
