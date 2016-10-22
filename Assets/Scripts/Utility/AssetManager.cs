using UnityEngine;
using System.Collections;

public class AssetManager : MonoBehaviour
{
    public Sprite axeIcon;
    public Sprite swordIcon;
    public Sprite crossbowIcon;
    public Sprite potionIcon;
    public Sprite maceIcon;

    public Sprite GetIcon(Weapon.IconType iconType)
    {
        Sprite toReturn = null;

        if (iconType == Weapon.IconType.Axe)
        {
            toReturn = axeIcon;
        }
        else if (iconType == Weapon.IconType.Sword)
        {
            toReturn = swordIcon;
        }
        else if (iconType == Weapon.IconType.Crossbow)
        {
            toReturn = crossbowIcon;
        }
        else if (iconType == Weapon.IconType.Mace)
        {
            toReturn = maceIcon;
        }


        else if (iconType == Weapon.IconType.Potion)
        {
            toReturn = axeIcon;
        }


        if (toReturn == null)
        {
            Debug.Log("AssetManager:" + iconType.ToString() + " NOT FOUND");
            toReturn = maceIcon;
        }

        return toReturn;
    }
}
