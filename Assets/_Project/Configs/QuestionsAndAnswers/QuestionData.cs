using UnityEngine;

[CreateAssetMenu(fileName = "QuestionData", menuName = "Configs/QuestionData")]
public class QuestionData : ScriptableObject
{
    [field: SerializeField] public string QuestionText { get; private set; } 
    [field: SerializeField] public Option[] Options { get; private set; } = new Option[4];
}
