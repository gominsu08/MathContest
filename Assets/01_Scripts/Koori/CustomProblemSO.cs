using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Problem")]
public class CustomProblemSO : ScriptableObject
{
    public Dictionary<int, Problem<string, string>> problems = new();
}
/// <summary>
/// 문제 형식 : 수식(Expression), 답(Answer)
/// </summary>
/// <typeparam name="Expression"></typeparam>
/// <typeparam name="Answer"></typeparam>
public struct Problem<Expression, Answer>
{
    public Expression expression;
    public Answer answer;
}
