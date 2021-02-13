using UnityEngine;

public class JumperEnemy : Enemy

{
    [SerializeField] private float jumpForce = 0f;

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
    }

}
