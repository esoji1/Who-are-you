using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BootstrapSelectAnswer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _question;
    [SerializeField] private List<QuestionData> _questionData = new();
    [SerializeField] private DisplayHeroPerformedView _displayHeroPerformedView;
    [SerializeField] private SelectAnswer _selectAnswer;

    private void Awake()
    {
        _selectAnswer.Initialze(_question, _questionData, _displayHeroPerformedView);
        _selectAnswer.StartSelectAnswer();
    }
}
