using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    #region Fields
    [SerializeField] private GameObject deathPanel = default;
    [SerializeField] private AudioManager _audioManager = default;

    [SerializeField] private AudioClip deathClip = default;
    
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

    private void Start()
    {
        _audioManager.Audio = GetComponent<AudioSource>();
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
        Time.timeScale = 0f;
        deathPanel.SetActive(true);
        _audioManager.PlaySound(deathClip);
        deathPanel.transform.DOPunchScale(new Vector3(0.4f, 0.4f, 0.4f), 1f, 2, 0.2f).OnComplete(() =>
        {
            //DO Something
        });
    }

    #endregion
}
