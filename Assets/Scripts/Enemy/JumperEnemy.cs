using UnityEngine;

public class JumperEnemy : Enemy

{
    #region Fields
    [SerializeField] private float jumpForce = 0f;
    private float nextTimeChange;
    [SerializeField] private float refreshTime = 0.2f;
    #endregion

    #region Monobehaviour
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (Time.time > nextTimeChange + refreshTime)
        {
            nextTimeChange = Time.time;
            rb2D.AddForce(velocity * jumpForce, ForceMode2D.Impulse);
        }
        rb2D.AddForce(velocity * refreshTime);
    }
    #endregion

    #region Abstract Methods
    //override this method if I need to make a different feature
    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        particleSetting.startColor = new ParticleSystem.MinMaxGradient(Color.red);
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
    }
    #endregion
}
