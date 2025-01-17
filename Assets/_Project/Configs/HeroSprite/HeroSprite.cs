using UnityEngine;

[CreateAssetMenu(fileName = "HeroSprite", menuName = "Configs/HeroSprite")]
public class HeroSprite : ScriptableObject
{
    [field: SerializeField] public Hero Hero { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }
}