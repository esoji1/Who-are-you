using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BootstrapDisplayHeroPerformedView : MonoBehaviour
{
    [SerializeField] private List<HeroSprite> _heroSprite = new();
    [SerializeField] private GameObject _heroPanel;
    [SerializeField] private Image _hero;
    [SerializeField] private DisplayHeroPerformedView _displayHeroPerformedView;

    private void Awake() => _displayHeroPerformedView.Initialize(_heroSprite, _heroPanel, _hero);
}
