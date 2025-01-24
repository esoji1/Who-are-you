using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class ButttonMainMenu : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private Button _settings;
    [SerializeField] private GameObject _settingsMenu;

    private bool _isOpen = false;
    private Sequence _animation;

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

    private void OpenGameplayScene()
    {
        _animation.Kill();
        SceneManager.LoadScene(1);
    }
    private void OpenSettings()
    {
        if (_isOpen == false)
        {
            _settingsMenu.SetActive(true);
            _isOpen = true;
            Show();
        }
        else
        {
            Hide();
            _isOpen = false;
        }
    }

    private void Show()
    {
        KillCurrentAnimatonIfActive();

        _animation = DOTween.Sequence();

        _animation
            .Append(_settingsMenu.transform.DOScale(6.5f, 1.5f));
    }

    private void Hide()
    {
        KillCurrentAnimatonIfActive();

        _animation = DOTween.Sequence();

        _animation
            .Append(_settingsMenu.transform.DOScale(0f, 1.5f))
            .OnComplete(() => _settingsMenu.SetActive(false));
    }

    private bool IsAnimaton() => _animation != null && _animation.active;

    private void KillCurrentAnimatonIfActive()
    {
        if (IsAnimaton())
            _animation.Kill();
    }
}
