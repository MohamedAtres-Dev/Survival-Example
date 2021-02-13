using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class ShotBehaviour : MonoBehaviour
{
    #region Fields
    protected Rigidbody2D rb2D;
    [SerializeField] protected float shotSpeed = 5f;
    [SerializeField] protected float impactAffect = 20f;

    #endregion

    #region Monobehaviour
    void OnEnable()
    {
        rb2D = GetComponent<Rigidbody2D>();
        StartCoroutine(SelfDeactive());
    }

    private void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("JumperEnemy") || collision.gameObject.CompareTag("MovableEnemy"))
        {
            collision.gameObject.GetComponent<IHealth>().TakeDamage(impactAffect);
            gameObject.SetActive(false);
        }
    }
    #endregion

    IEnumerator SelfDeactive()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
    #region Abstract Methods
    public abstract void Move(Transform trans);

    #endregion
}
