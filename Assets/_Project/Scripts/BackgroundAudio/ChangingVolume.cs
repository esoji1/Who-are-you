using UnityEngine;
using UnityEngine.UI;

public class ChangingVolume : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void Update() => 
        SoundSettings.SetVolume(_slider.value);
}
