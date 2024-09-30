using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class MiniGames : MonoBehaviour
{
    public List<ResourceDataSO> increaseResourceList = new List<ResourceDataSO>();
    public List<string> unAnswer = new List<string>();
    public RectTransform increaseResourcePanel, parentPanel;
    public CustomProblemSO customProblemSO;
    public ResourceSOList resourceSOList;
    public TextMeshProUGUI answertext;
    public TextMeshProUGUI problemText;
    public SetImage setImage;
    public Image itemIcon;
    public Memo memoPrefab;
    protected Memo m_Memo;
    public string inSceneName;

    private bool _isActiveMemo = false;

    public int currentProblemIndex;
    public int increaseCount;
    public float solvingTime;
    private bool isHardProblem;

    protected string[] answers = { };
    protected string answer; // 정답
    protected bool isGameClear; // 게임이 끝나면 true


    

    protected virtual void Awake()
    {
        GameEnter();
    }

    protected virtual void Update()
    {
    }

   

    protected virtual void GameEnter()
    {
        ProblemSet();
    }

    public virtual void GameExit()
    {
        GetItem();
        SetAcquisitionItemIcon(ref increaseResourceList);
    }

    private void GetItem()
    {
        for (int i = 0; i < increaseCount; i++)
        {
            ResourceDataSO data = resourceSOList.RandomList();
            increaseResourceList.Add(data);
        }
    }

    private void SetAcquisitionItemIcon(ref List<ResourceDataSO> increaseResourceList)
    {
        increaseResourcePanel.gameObject.SetActive(true);

        foreach (ResourceDataSO data in increaseResourceList)
        {
            Image image = Instantiate(itemIcon, parentPanel);
            image.sprite = data.sprite;
        }

        increaseResourceList.Clear();
        itemIcon.gameObject.SetActive(false);
        isGameClear = true;
    }

    public virtual void ProblemSet()
    {
        int rand = Random.Range(2, customProblemSO.problems.Count + 1);
        currentProblemIndex = rand;

        
        Problem<string, string, bool> problem = customProblemSO.problems[3];

        isHardProblem = problem.isIncludDesc;


        if (isHardProblem)
            SetProblemeText(problem);
        else
            StartCoroutine(Wait(problem));

        answer = problem.answer;

        for (int i = 1; i <= customProblemSO.problems.Count; i++)
        {
            unAnswer.Add(customProblemSO.problems[i].answer);
        }

        unAnswer.Remove(answer);
    }

    private void SetProblemeText(Problem<string, string, bool> problem)
    {
        problemText.gameObject.SetActive(true);
        setImage.gameObject.SetActive(false);

        problemText.SetText(problem.expression);

    }

    public bool AnswerCheck(string answer)
    {
        if (answer == this.answer)
        {
            return true;
        }
        return false;
    }

    public IEnumerator Wait(Problem<string, string, bool> problem)
    {
        yield return new WaitForSeconds(3f);
        setImage.GetTexture(problem.expression);
    }

    public IEnumerator Typing(bool isClear)
    {
        string ming;
        answertext.gameObject.SetActive(true);
        ming = ".";
        answertext.SetText(ming);
        yield return new WaitForSeconds(0.35f);
        ming = ". .";
        answertext.SetText(ming);
        yield return new WaitForSeconds(0.45f);
        ming = ". . .";
        answertext.SetText(ming);
        yield return new WaitForSeconds(0.5f);
        if (isClear) ming = "정답!";
        else ming = "오답";



        answertext.SetText(ming);

        yield return new WaitForSeconds(1.5f);
        answertext.gameObject.SetActive(false);
        if (isClear) GameExit();
        else SceneChanged();
    }

    public string GetAnswer()
    {
        return this.answer;
    }

    public void SceneChanged()
    {
        SceneManager.LoadScene("UpdgradeScene");
    }

    public void ReStart()
    {
        SceneManager.LoadScene(inSceneName);
    }
}
