using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class MiniGames : MonoBehaviour
{
    public List<ResourceDataSO> increaseResourceList = new List<ResourceDataSO>();
    public RectTransform increaseResourcePanel, parentPanel;
    public CustomProblemSO customProblemSO;
    public ResourceSOList resourceSOList;
    public TextMeshProUGUI Answertext;
    public SetImage setImage;
    public Image itemIcon;

    public int currentProblemIndex;
    public int increaseCount;
    public float solvingTime;


    protected string[] answers = { };
    protected string answer; // 정답
    protected bool isGameClear; // 게임이 끝나면 true

    protected virtual void Start()
    {
        GameEnter();
    }

    protected virtual void Update()
    {
        if (isGameClear && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("UpdgradeScene");
        }
    }


    protected virtual void GameEnter()
    {
        ProblemSet();
    }

    public virtual void GameExit()
    {
        for (int i = 0; i < increaseCount; i++)
        {
            ResourceDataSO data = resourceSOList.RandomList();
            increaseResourceList.Add(data);
        }

        SetAcquisitionItemIcon(ref increaseResourceList);
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
        int rand = Random.Range(1, customProblemSO.problems.Count + 1);
        currentProblemIndex = rand;

        Problem<string, string> problem = customProblemSO.problems[3];

        StartCoroutine(Wait(problem));

        answer = problem.answer;
    }

    public bool AnswerCheck(string answer)
    {
        if (answer == this.answer)
        {
            return true;
        }
        return false;
    }

    public IEnumerator Wait(Problem<string, string> problem)
    {
        yield return new WaitForSeconds(3f);
        setImage.GetTexture(problem.expression);
    }

    public IEnumerator Typing(bool isClear)
    {
        string ming;
        Answertext.gameObject.SetActive(true);
        ming = ".";
        Answertext.SetText(ming);
        yield return new WaitForSeconds(0.35f);
        ming = ". .";
        Answertext.SetText(ming);
        yield return new WaitForSeconds(0.45f);
        ming = ". . .";
        Answertext.SetText(ming);
        yield return new WaitForSeconds(0.5f);
        if (isClear) ming = "정답!";
        else ming = "오답";



        Answertext.SetText(ming);

        yield return new WaitForSeconds(1.5f);
        Answertext.gameObject.SetActive(false);
        if (isClear) GameExit();
    }

}
