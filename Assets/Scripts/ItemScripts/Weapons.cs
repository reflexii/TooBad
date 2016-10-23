using UnityEngine;
using System.Collections;

public class Weapons 
{
	public class ShortSword : MeleeWeapon
	{
		public ShortSword() : base ("Short Sword",5,5,40,90,1,500,IconType.Sword)
		{
			
		}
	}

	public class LongSword : MeleeWeapon
    {
		public LongSword() : base ("Long Sword",10,5,40,90,2,300, IconType.Sword)
		{

		}
	}

    public class CrossBow : RangedWeapon
    {
        public CrossBow() : base("Short Bow",5,5,1,10,7,ProjectileType.Arrow, IconType.Crossbow)
        {

        }
    }

    public class SplitFireCrossBow : RangedWeapon
    {
        public SplitFireCrossBow() : base("Splitfire Crosbow", 5, 5,0.08f, 10,100, ProjectileType.Arrow, IconType.Crossbow)
        {

        }
    }

    public class FireWand : RangedWeapon
    {
        public FireWand() : base("Fire Wand", 5, 5, 1, 7, 12, ProjectileType.FireBall, IconType.Sword)
        {

        }
    }

    public class Boomerang : RangedWeapon
    {
        public Boomerang() : base("Boomerang", 5, 5, 1, 1, 12, ProjectileType.Boomerang, IconType.Sword)
        {

        }
    }
}
