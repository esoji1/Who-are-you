using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundAudio;

    private void Awake() => 
        _backgroundAudio.volume = SoundSettings.Volume;
}
