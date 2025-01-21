using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectAnswer : MonoBehaviour
{
    [SerializeField] private List<Button> _options = new();

    private TextMeshProUGUI _question;
    private List<QuestionData> _questionData;

    private Dictionary<Hero, int> _characterScores = new Dictionary<Hero, int>();
    private int _currentQuestionIndex = 0;

    public event Action<Hero> OnHero;

    public TextMeshProUGUI Question => _question;

    public void Initialze(TextMeshProUGUI question, List<QuestionData> questionData)
    {
        _question = question;
        _questionData = questionData;
    }

    public void StartSelectAnswer()
    {
        foreach (Hero hero in Enum.GetValues(typeof(Hero)))
            _characterScores[hero] = 0;

        for (int i = 0; i < _options.Count; i++)
        {
            int index = i;
            _options[i].onClick.AddListener(() => OnOptionSelected(index));
        }

        ShowQuestion(_currentQuestionIndex);
    }

    private void ShowQuestion(int index)
    {
        if (index >= _questionData.Count)
        {
            EndQuiz();
            return;
        }

        QuestionData currentQuestion = _questionData[index];
        _question.text = currentQuestion.QuestionText;

        for (int i = 0; i < _options.Count; i++)
            _options[i].GetComponentInChildren<TextMeshProUGUI>().text =
                currentQuestion.Options[i].OptionText;
    }

    private void OnOptionSelected(int optionIndex)
    {
        if (_currentQuestionIndex >= _questionData.Count)
            return;

        Option selectedOption = CheckCompliance(optionIndex);

        foreach (HeroScore heroScore in selectedOption.HeroScores)
            if (_characterScores.ContainsKey(heroScore.Hero))
                _characterScores[heroScore.Hero] += heroScore.Score;

        _currentQuestionIndex++;
        ShowQuestion(_currentQuestionIndex);
    }

    private Option CheckCompliance(int optionIndex)
    {
        QuestionData currentQuestion = _questionData[_currentQuestionIndex];
        string textOption = _options[optionIndex].GetComponentInChildren<TextMeshProUGUI>().text;

        foreach (Option option in currentQuestion.Options)
            if (option.OptionText == textOption)
                return option;

        throw new Exception("No match found!");
    }

    private void EndQuiz()
    {
        List<Hero> topHeroes = new List<Hero>();
        int maxScore = int.MinValue;

        foreach (KeyValuePair<Hero, int> score in _characterScores)
        {
            if (score.Value > maxScore)
            {
                maxScore = score.Value;
                topHeroes.Clear();
                topHeroes.Add(score.Key);
            }
            else if (score.Value == maxScore)
            {
                topHeroes.Add(score.Key);
            }
        }

        Hero topHero = topHeroes[UnityEngine.Random.Range(0, topHeroes.Count)];

        _options
            .ForEach(button => button.gameObject.SetActive(false));

        OnHero?.Invoke(topHero);
    }
}
