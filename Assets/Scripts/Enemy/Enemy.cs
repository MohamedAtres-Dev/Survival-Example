using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    protected float currentHealth = 0f;
    [SerializeField] protected float maxHealth = 0f;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
