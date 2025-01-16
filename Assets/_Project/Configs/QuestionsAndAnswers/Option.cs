using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Option", menuName = "Configs/Option")]
public class Option : ScriptableObject
{
    [field: SerializeField] public string OptionText { get; private set; }
    [SerializeField] private List<HeroScore> _heroScores = new();

    public List<HeroScore> HeroScores => _heroScores;
}
