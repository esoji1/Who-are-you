using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    [SerializeField] private Button _exit;
    [SerializeField] private DisplayHeroPerformedView _displayHeroPerformedView;

    private void OnEnable() => _exit.onClick.AddListener(ExitHome);

    private void OnDisable() => _exit.onClick.RemoveListener(ExitHome);

    private void ExitHome()
    {
        _displayHeroPerformedView.KillAnimation();
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
}
