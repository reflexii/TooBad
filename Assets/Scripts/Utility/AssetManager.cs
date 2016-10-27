using UnityEngine;
using System.Collections;

public class AssetManager : MonoBehaviour
{
    public Sprite axeIcon;
    public Sprite swordIcon;
    public Sprite crossbowIcon;
    public Sprite potionIcon;
    public Sprite maceIcon;
    public Sprite keyIcon;
    public Sprite rageDrugIcon;

    public Sprite GetIcon(Weapon.ItemClass iconType)
    {
        Sprite toReturn = null;

        if (iconType == Weapon.ItemClass.Axe)
        {
            toReturn = axeIcon;
        }
        else if (iconType == Weapon.ItemClass.Sword)
        {
            toReturn = swordIcon;
        }
        else if (iconType == Weapon.ItemClass.Crossbow)
        {
            toReturn = crossbowIcon;
        }
        else if (iconType == Weapon.ItemClass.Mace)
        {
            toReturn = maceIcon;
        }
        else if (iconType == Weapon.ItemClass.Potion)
        {
            toReturn = axeIcon;
        }
        else if (iconType == Weapon.ItemClass.NormalKey)
        {
            toReturn = keyIcon;
        }

        else if (iconType == Weapon.ItemClass.RageDrug)
        {
            toReturn = rageDrugIcon;
        }



        if (toReturn == null)
        {
            Debug.Log("AssetManager:" + iconType.ToString() + " NOT FOUND");
            toReturn = maceIcon;
        }

        return toReturn;
    }
}
