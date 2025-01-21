using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHeroPerformedView : MonoBehaviour
{
    private List<HeroSprite> _heroSprite;
    private GameObject _heroPanel;
    private Image _hero;

    private Sprite _sprite;
    private Sequence _heroPanelAnimation;
    private Tween _tween;

    public void Initialize(List<HeroSprite> heroSprite, GameObject heroPanel, Image hero)
    {
        _heroSprite = heroSprite;
        _heroPanel = heroPanel;
        _hero = hero;

        LockHeroPanelBorders();
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

    public void KillAnimation()
    {
        DOTween.KillAll();
    }

    private void PlaySpawnAnimations()
    {
        _heroPanelAnimation = DOTween.Sequence();

        _heroPanelAnimation
            .Append(_hero.transform.DOScale(5f, 3f))
            .Join(_hero.transform.DORotate(new Vector3(0f, 0f, 360f), 3f, RotateMode.FastBeyond360));

        _tween = _heroPanel.transform.DOScaleY(1f, 3f).SetEase(Ease.OutBack);
    }

    private void LockHeroPanelBorders()
    {
        RectTransform panelRect = _heroPanel.GetComponent<RectTransform>();
        panelRect.anchorMin = new Vector2(panelRect.anchorMin.x, 0);
        panelRect.anchorMax = new Vector2(panelRect.anchorMax.x, 1);
        panelRect.offsetMin = new Vector2(panelRect.offsetMin.x, 0);
        panelRect.offsetMax = new Vector2(panelRect.offsetMax.x, 0);
    }
}
