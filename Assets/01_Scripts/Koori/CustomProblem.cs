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
                // ù ��° �� (���) �ǳʶٱ�
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        // CSV ���Ͽ��� �� �ʵ带 �Ľ�
                        string[] fields = line.Split(',');

                        if (fields.Length >= 3)
                        {
                            int problemNumber = int.Parse(fields[0].Trim());
                            string expression = fields[1].Trim();
                            string answer = fields[2].Trim();
                            bool isIncludDesc = Convert.ToBoolean(fields[3].Trim());

                            // ��ųʸ��� �߰�
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