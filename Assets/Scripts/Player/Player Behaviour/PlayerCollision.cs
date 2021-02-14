using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    public static event UnityAction gameOverEvent = delegate { };

    [SerializeField] private ParticleSystem explosion;
    private ParticleSystem.MainModule particleSetting;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("JumperEnemy") || collision.gameObject.CompareTag("MovableEnemy"))
        {
            
            particleSetting = explosion.GetComponent<ParticleSystem>().main;
            particleSetting.startColor = new ParticleSystem.MinMaxGradient(Color.blue);
            Instantiate(explosion, transform.position, Quaternion.identity);
            gameOverEvent.Invoke();
            gameObject.SetActive(false);
        }
    }
}
