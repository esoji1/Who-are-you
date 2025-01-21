using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    [SerializeField] private Button _restart;
    [SerializeField] private DisplayHeroPerformedView _displayHeroPerformedView;

    private void OnEnable() => _restart.onClick.AddListener(RestartGame);

    private void OnDisable() => _restart.onClick.RemoveListener(RestartGame);

    private void RestartGame()
    {
        _displayHeroPerformedView.KillAnimation();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }
}
