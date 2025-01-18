using UnityEngine;

public class BringsDroppedHero : MonoBehaviour
{
    [SerializeField] private SelectAnswer _selectAnswer;
    private DisplayHeroPerformedView _displayHeroPerformedView;

    private void OnEnable() => _selectAnswer.OnHero += DisplayHero;

    private void OnDisable() => _selectAnswer.OnHero -= DisplayHero;

    public void Initialize(DisplayHeroPerformedView displayHeroPerformedView) 
        => _displayHeroPerformedView = displayHeroPerformedView;

    private void DisplayHero(Hero hero)
    {
        _selectAnswer.Question.text = $"Викторина завершена! Ты — {hero}!";
        _displayHeroPerformedView.ShowHero(hero);
    }
}
