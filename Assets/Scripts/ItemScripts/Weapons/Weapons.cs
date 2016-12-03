using UnityEngine;
using System.Collections;

public class Weapons
{
    public class ShortSword : MeleeWeapon
    {
        public ShortSword() : base("Short Sword", 5, 0.2f, 10, 40, 90, 1, 500, ItemClass.Sword)
        {

        }
    }

    public class LongSword : MeleeWeapon
    {
        public LongSword() : base("Long Sword", 2.5f, 0.5f, 0,40, 90, 1f, 500, ItemClass.Sword)
        {

        }
    }

    public class Axe : MeleeWeapon
    {
        public Axe() : base("Axe", 10f, 0.5f, 10, 40, 90, 1f, 300, ItemClass.Axe)
        {

        }
    }

    public class Fist : MeleeWeapon
    {
        public Fist() : base("Fist", 5, 1, 5, 40, 90, 1, 300, ItemClass.Sword)
        {

        }
    }

    public class CrossBow : RangedWeapon
    {
        public CrossBow() : base("CrossBow", 10, 5, 1, 10, 9, ProjectileType.Arrow, ItemClass.Crossbow)
        {

        }
    }

    public class AutomaticCrossBow : RangedWeapon
    {
        public AutomaticCrossBow() : base("Automatic Crossbow", 5, 5, 0.08f, 10, 100, ProjectileType.Arrow, ItemClass.Crossbow)
        {

        }
    }

    public class FireWand : RangedWeapon
    {
        public FireWand() : base("Fire Wand", 20, 5, 1, 7, 12, ProjectileType.FireBall, ItemClass.Wand)
        {

        }
    }

    public class Boomerang : RangedWeapon
    {
        public Boomerang() : base("Boomerang", 5, 5, 1, 1, 12, ProjectileType.Boomerang, ItemClass.Sword)
        {

        }
    }
}
