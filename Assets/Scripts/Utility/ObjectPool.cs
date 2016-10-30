using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject fireBallPrefab;
    public GameObject boomerangPrefab;
    public GameObject lootPrefab;
    public Animator explosion;

    private List<Projectile> projectilePool;
    private List<LootableItem> lootPool;

    public ObjectPool()
    {
        projectilePool = new List<Projectile>();
        lootPool = new List<LootableItem>();
    }

    //ADD change this method.
    public void DropItem(Vector3 pos)
    {
        GameObject o = (GameObject)Instantiate(lootPrefab);
        pos.z = -0.1f;
        o.transform.position = pos;
        int random = Random.Range(0, 3);

        if (random == 0)
            o.GetComponent<LootableItem>().SetItem(new Weapons.ShortSword());
        else if (random == 1)
            o.GetComponent<LootableItem>().SetItem(new Weapons.LongSword());
        else if (random == 2)
            o.GetComponent<LootableItem>().SetItem(new Weapons.CrossBow());
    }

    public void FireProjectile(RangedWeapon weapon, Vector3 direction)
    {
        ActivateOrCreateProjectile(weapon, direction);
    }

    void ActivateOrCreateProjectile(RangedWeapon weapon, Vector3 direction)
    {
        if (projectilePool.Count == 0)
        {
            CreateProjectile(weapon, direction);
            return;
        }

        foreach (Projectile proj in projectilePool)
        {
            if (proj.projectileType == weapon.projectileType)
            {
                ActivateProjectile(proj, weapon, direction);
                projectilePool.Remove(proj);
                return;
            }
        }

        CreateProjectile(weapon, direction);
    }

    void CreateProjectile(RangedWeapon weapon, Vector3 direction)
    {
        if (weapon.projectileType == RangedWeapon.ProjectileType.Arrow)
        {
            GameObject go = (GameObject)Instantiate(arrowPrefab);
            go.GetComponent<Projectile>().SetPreferences(weapon, direction);
        }

        else if (weapon.projectileType == RangedWeapon.ProjectileType.FireBall)
        {
            GameObject go = (GameObject)Instantiate(fireBallPrefab);
            go.GetComponent<Projectile>().SetPreferences(weapon, direction);
        }

        else if (weapon.projectileType == RangedWeapon.ProjectileType.Boomerang)
        {
            GameObject go = (GameObject)Instantiate(boomerangPrefab);
            go.GetComponent<Projectile>().SetPreferences(weapon, direction);
        }

    }

    void ActivateProjectile(Projectile projectile, RangedWeapon weapon, Vector3 dir)
    {
        projectile.gameObject.SetActive(true);
        projectile.SetPreferences(weapon, dir);
    }

    public void AddBackToPool(Projectile projectile)
    {
        projectilePool.Add(projectile);
    }
}
