using UnityEngine;

public class ProjectileShot : Shot
{
    public override void Launch(Weapon weapon, PoolManager pool)
    {
        GameObject projectile = pool.GetPooledObject("Projectile");
        projectile.transform.position = weapon.transform.position;
        projectile.transform.rotation = weapon.transform.rotation;
        projectile.SetActive(true);
        projectile.GetComponent<ShotBehaviour>().Move(weapon.transform);

        //Play Sound
        weapon._audioManger.PlaySound(clip);
    }
}
