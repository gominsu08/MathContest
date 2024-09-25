using System;
using System.IO;
using UnityEngine;

public class CustomProblem : MonoBehaviour
{
    string csvFilePath = Application.streamingAssetsPath + "/" + "CustomProblem.csv";
    [SerializeField] private CustomProblemSO _problemSO;

    private void Awake()
    {
        ProblemLoad(csvFilePath);
        Debug.Log($"{_problemSO.problems[2].expression} = {_problemSO.problems[2].answer}");
    }
    public void ProblemLoad(string csvPath)
    {
        _problemSO.problems.Clear();
        try
        {
            using (StreamReader reader = new StreamReader(csvPath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        // CSV 파일에서 각 필드를 파싱
                        string[] fields = line.Split(',');

                        if (fields.Length >= 3)
                        {
                            int problemNumber = int.Parse(fields[0].Trim());
                            string expression = fields[1].Trim();
                            string answer = fields[2].Trim();

                            // 딕셔너리에 추가
                            _problemSO.problems.Add(problemNumber, new Problem<string, string>()
                            { expression = expression, answer = answer });
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error reading CSV file: {e.Message}");
        }
    } 
}