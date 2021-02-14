using UnityEngine;


public class MovableEnemy : Enemy
{
    [SerializeField] private float movementSpeed = 0f;

    #region Monobehaviour
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        velocity *= movementSpeed;

        transform.position += velocity * Time.deltaTime;
        //rb2D.AddForce(velocity * Time.deltaTime , ForceMode2D.Force);
    }

    #endregion

    #region AbstractMethod
    //override this method if I need to make a different feature
    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        particleSetting.startColor = new ParticleSystem.MinMaxGradient(Color.yellow);
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
    }
    #endregion
}
