using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot :  Shot
{
    public override void Launch(Weapon weapon, PoolManager pool)
    {
        GameObject bullet = pool.GetPooledObject("Bullet");
        bullet.transform.position = weapon.transform.position;
        bullet.transform.rotation = weapon.transform.rotation;
        bullet.SetActive(true);
        bullet.GetComponent<ShotBehaviour>().Move(weapon.transform);
        
       
    }
}
