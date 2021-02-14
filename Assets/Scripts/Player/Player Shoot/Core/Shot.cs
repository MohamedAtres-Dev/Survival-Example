using UnityEngine;
public abstract class Shot : MonoBehaviour
{
    public AudioClip clip;
    public abstract void Launch(Weapon weapon, PoolManager pool);
}
