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
        Debug.Log($"{_problemSO.problems[3].expression} = {_problemSO.problems[3].answer}, Is Included Description? = {_problemSO.problems[3].isIncludDesc}");
    }
    public void ProblemLoad(string csvPath)
    {
        _problemSO.problems.Clear();
        try
        {
            using (StreamReader reader = new StreamReader(csvPath))
            {
                // 첫 번째 줄 (헤더) 건너뛰기
                reader.ReadLine();
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
                            bool isIncludDesc = Convert.ToBoolean(fields[3].Trim());

                            // 딕셔너리에 추가
                            _problemSO.problems.Add(problemNumber, new Problem<string, string, bool>()
                            { expression = expression, answer = answer, isIncludDesc = isIncludDesc});
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