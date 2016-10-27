using UnityEngine;
using System.Collections;

public abstract class ContactObject : LootableItem
{

    protected abstract void TakeAction(Collider2D col);
    public void OnTriggerEnter2D(Collider2D col)
    {
        TakeAction(col);
    }

    public override void PerformClickAction(MouseHandler clickActions)
    {
    }
    
}
