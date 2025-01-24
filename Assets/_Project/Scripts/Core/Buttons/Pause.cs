using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private Button _pause;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _menuPause;
    [SerializeField] private AudioSource _backgroundAudio;

    private bool _isPause = false;
    private Sequence _animation;

    private void OnEnable()
    {
        _pause.onClick.AddListener(StopGame);
    }

    private void OnDisable()
    {
        _pause.onClick.RemoveListener(StopGame);
    }

    private void Show()
    {
        KillCurrentAnimatonIfActive();

        _pausePanel.SetActive(true);

        _animation = DOTween.Sequence();

        _animation
            .Append(_menuPause.transform.DOScale(6f, 1.5f))
            .Join(_menuPause.transform.DORotate(new Vector3(0f, 0f, 360f), 1.5f, RotateMode.FastBeyond360))
            .SetEase(Ease.Linear)
            .SetUpdate(true);
    }

    private void Hide()
    {
        KillCurrentAnimatonIfActive();

        _animation = DOTween.Sequence();

        _animation
            .Append(_menuPause.transform.DOScale(0f, 1.5f))
            .Join(_menuPause.transform.DORotate(new Vector3(0f, 0f, -360f), 1.5f, RotateMode.FastBeyond360))
            .SetEase(Ease.Linear)
            .SetUpdate(true)
            .OnComplete(() => _pausePanel.SetActive(false));
    }

    private void StopGame()
    {
        if (_isPause == false)
        {
            Time.timeScale = 0f;
            _isPause = true;
            _backgroundAudio.Pause();
            Show();
        }
        else
        {
            Time.timeScale = 1f;
            _isPause = false;
            _backgroundAudio.Play();
            Hide();
        }
    }

    private bool IsAnimaton() => _animation != null && _animation.active;

    private void KillCurrentAnimatonIfActive()
    {
        if (IsAnimaton())
            _animation.Kill();
    }
}
