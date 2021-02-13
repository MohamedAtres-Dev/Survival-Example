using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    public static event UnityAction gameOverEvent = delegate { };

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("JumperEnemy") || collision.gameObject.CompareTag("MovableEnemy"))
        {
            Debug.Log("Game Over");
            gameOverEvent.Invoke();
        }
    }
}
