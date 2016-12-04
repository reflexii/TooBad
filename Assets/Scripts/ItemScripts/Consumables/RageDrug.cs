using UnityEngine;
using System.Collections;
using System;

public class RageDrug : Consumable {
    public float rageRecoveryAmount;

    public RageDrug(string itemName, float madnessRecoveryAmount, ItemClass iconType) : base(itemName, iconType)
    {
        this.rageRecoveryAmount = madnessRecoveryAmount;
    }

    protected override void Action()
    {
        Player tmpMaster = (Player)master;
        tmpMaster.currentRageAmount += rageRecoveryAmount;

        if (tmpMaster.currentRageAmount > tmpMaster.maxRageAmount)
        {
            tmpMaster.currentRageAmount = tmpMaster.maxRageAmount;
        }

        if (itemClass == ItemClass.Mushroom)
        {
            //GameManager.Instance.eventManager.StartEvent(EventManager.Event.Prologue, DialogManager.TextKey.Dialog1_0);
        }
    }
}
