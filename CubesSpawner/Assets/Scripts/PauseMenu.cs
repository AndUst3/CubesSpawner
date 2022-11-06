using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _exitButton;

    private void Awake()
    {
        _pauseButton.onClick.AddListener(OnPause);
        _exitButton.onClick.AddListener(ExitGame);
        _pauseMenu.gameObject.SetActive(false);
    }

    private void OnPause()
    {
        Time.timeScale = 0;
        _pauseMenu.gameObject.SetActive(true);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
