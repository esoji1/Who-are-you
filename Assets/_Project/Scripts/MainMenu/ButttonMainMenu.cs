using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButttonMainMenu : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private Button _settings;
    [SerializeField] private GameObject _settingsMenu;

    private bool _isOpen = false;

    private void OnEnable()
    {
        _play.onClick.AddListener(OpenGameplayScene);
        _settings.onClick.AddListener(OpenSettings);
    }

    private void OnDisable()
    {
        _play.onClick.RemoveListener(OpenGameplayScene);
        _settings.onClick.RemoveListener(OpenSettings);
    }

    private void OpenGameplayScene() => SceneManager.LoadScene(1);

    private void OpenSettings()
    {
        if (_isOpen == false)
        {
            _settingsMenu.SetActive(true);
            _isOpen = true;
        }
        else
        {
            _settingsMenu.SetActive(false);
            _isOpen = false;
        }
    }
}
