using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Problem")]
public class CustomProblemSO : ScriptableObject
{
    public Dictionary<int, Problem<string, string, bool>> problems = new();
}
/// <summary>
/// ���� ���� : ����(Expression), ��(Answer), ���� ���� ����(IsIncludDesc)
/// </summary>
/// <typeparam name="Expression"></typeparam>
/// <typeparam name="Answer"></typeparam>
/// <typeparam name="IsIncludDesc"></typeparam>
public struct Problem<Expression, Answer, IsIncludDesc>
{
    public Expression expression;
    public Answer answer;
    public IsIncludDesc isIncludDesc;
}
