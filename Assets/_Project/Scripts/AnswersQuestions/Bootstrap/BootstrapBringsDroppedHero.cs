using UnityEngine;

public class BootstrapBringsDroppedHero : MonoBehaviour
{
    [SerializeField] private DisplayHeroPerformedView _displayHeroPerformedView;
    [SerializeField] private BringsDroppedHero _bringsDroppedHero;

    private void Awake() => _bringsDroppedHero.Initialize(_displayHeroPerformedView);
}
