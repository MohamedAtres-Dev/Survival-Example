using UnityEngine;


public class MovableEnemy : Enemy
{
    [SerializeField] private float movementSpeed = 0f;

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        velocity *= movementSpeed;

        transform.position += velocity * Time.deltaTime;
    }

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
    }
}
