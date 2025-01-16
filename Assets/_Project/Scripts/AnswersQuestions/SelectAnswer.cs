using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectAnswer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _question;
    [SerializeField] private List<Button> _options = new();
    [SerializeField] private List<QuestionData> _questionData = new();

    private Dictionary<Hero, int> _characterScores = new Dictionary<Hero, int>();
    private int _currentQuestionIndex = 0;

    private void Start()
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

        throw new Exception("Соответствие не найдено!");
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

        _question.text = $"Викторина завершена! Ты — {topHero}!";

        foreach (Button button in _options)
            button.gameObject.SetActive(false);
    }
}
