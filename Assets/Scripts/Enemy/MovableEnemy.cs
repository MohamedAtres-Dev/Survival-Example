using UnityEngine;


public class MovableEnemy : Enemy
{
    [SerializeField] private float movementSpeed = 0f;

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
    }
}
