using UnityEngine;
public abstract class Shot : MonoBehaviour
{
    public abstract void Launch(Weapon weapon, PoolManager pool);
}
