using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject deathPanel = default;
    
    #endregion

    #region Monobehaviour
    private void OnEnable()
    {
        PlayerCollision.gameOverEvent += OnPlayerDied;
    }

    private void OnDisable()
    {
        PlayerCollision.gameOverEvent -= OnPlayerDied;
    }

    #endregion

    #region Methods
    public void MainMenuScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void OnPlayerDied()
    {
        Time.timeScale = 0;
        deathPanel.SetActive(true);
    }

    #endregion
}
