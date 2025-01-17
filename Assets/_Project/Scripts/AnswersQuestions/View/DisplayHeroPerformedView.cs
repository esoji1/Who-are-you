using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHeroPerformedView : MonoBehaviour
{
    private List<HeroSprite> _heroSprite;
    private GameObject _heroPanel;
    private Image _hero;

    private Sprite _sprite;
    private Sequence _heroPanelAnimation;

    public void Initialize(List<HeroSprite> heroSprite, GameObject heroPanel, Image hero)
    {
        _heroSprite = heroSprite;
        _heroPanel = heroPanel;
        _hero = hero;
    }

    public void ShowHero(Hero hero)
    {
        foreach (HeroSprite heroSprite in _heroSprite)
            if (heroSprite.Hero == hero)
                _sprite = heroSprite.Sprite;

        _heroPanel.SetActive(true);

        _heroPanel.GetComponent<Image>().sprite = _sprite;
        _hero.sprite = _sprite;

        PlaySpawnAnimations();
    }

    private void PlaySpawnAnimations()
    {
        _heroPanelAnimation = DOTween.Sequence();

        _heroPanelAnimation
            .Append(_hero.transform.DOScale(5f, 3f))
            .Join(_hero.transform
            .DORotate(new Vector3(0f, 0f, 360f), 3f, RotateMode.FastBeyond360));

        Tween tween = _heroPanel.transform.DOScaleY(1f, 3f);
    }
}
