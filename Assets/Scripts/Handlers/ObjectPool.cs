using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ObjectPool : MonoBehaviour
{
    public GameObject arrowPrefab;
    private List<Projectile> projectilePool;

    public ObjectPool()
    {
        projectilePool = new List<Projectile>();
    }

    public void FireProjectile(RangedWeapon weapon, Vector3 direction)
    {
        ActivateOrCreateProjectile(weapon, direction);
    }

    void ActivateOrCreateProjectile(RangedWeapon weapon, Vector3 direction)
    {
        if (projectilePool.Count == 0)
        {
            CreateProjectile(weapon,direction);
            return;
        }

        foreach (Projectile proj in projectilePool)
        {
            if (proj.projectileType == weapon.projectileType)
            {
                ActivateProjectile(proj,weapon,direction);
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
    }

    void ActivateProjectile(Projectile projectile, RangedWeapon weapon, Vector3 dir)
    {
        projectile.gameObject.SetActive(true);
        projectile.SetPreferences(weapon,dir);
    }

    public void AddBackToPool(Projectile projectile)
    {
        projectilePool.Add(projectile);
    }
}
