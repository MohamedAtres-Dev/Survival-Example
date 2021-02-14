using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

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
        deathPanel.transform.DOPunchScale(new Vector3(0.4f, 0.4f, 0.4f), 1f, 2, 0.2f);

    }

    #endregion
}
