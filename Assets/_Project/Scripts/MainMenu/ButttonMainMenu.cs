using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButttonMainMenu : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _exit;
    [SerializeField] private GameObject _settingsMenu;


    private void OnEnable()
    {
        _play.onClick.AddListener(OpenGameplayScene);
        _settings.onClick.AddListener(OpenSettings);
        _exit.onClick.AddListener(Exit);
    }

    private void OnDisable()
    {
        _play.onClick.RemoveListener(OpenGameplayScene);
        _settings.onClick.RemoveListener(OpenSettings);
        _exit.onClick.RemoveListener(Exit);
    }

    private void OpenGameplayScene() => SceneManager.LoadScene(1);

    private void OpenSettings()
    {
        _settingsMenu.SetActive(true);
    }

    private void Exit()
    {
        _settingsMenu.SetActive(false);
    }
}
