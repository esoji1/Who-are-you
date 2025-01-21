using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private Button _pause;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private AudioSource _backgroundAudio;

    private bool _isPause = false;

    private void OnEnable()
    {
        _pause.onClick.AddListener(StopGame);
    }

    private void OnDisable()
    {
        _pause.onClick.RemoveListener(StopGame);
    }

    private void Show() => _pausePanel.SetActive(true);
    private void Hide() => _pausePanel.SetActive(false);

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
}
