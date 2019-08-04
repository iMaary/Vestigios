using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public static UIController Instance;

    [Header("Data")]
    public DialogData data;

    [Header("Screens")]
    public GameObject dialogCanvas;
    public Image background;
    public Image character;
    public Image otherCharacter;
    public Button chatHolder;
    public Text chatText;
    public GameObject questionHolder;
    public GameObject questionPrefab;

    [Header("Dialog Scene")]
    public string sceneName;

    // Privates
    private bool showingText;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance != null)
            Destroy(Instance);

        Instance = this;

        GameManager.Instance.UpdateData(data);
    }

    private void Update()
    {
        dialogCanvas.SetActive(SceneManager.GetActiveScene().name == sceneName);

        if (showingText)
            CheckSkip();
    }

    public void UpdateDialog(int questionId)
    {
        DialogData data = GameManager.Instance.data;

        chatText.gameObject.SetActive(true);
        StartCoroutine(ShowText(data.questions[questionId].questionText));

        background.sprite = data.questions[questionId].background;
        character.sprite = data.questions[questionId].character;
        otherCharacter.sprite = data.questions[questionId].otherCharacter;
    }

    #region Util
    private IEnumerator ShowText(string resp)
    {
        showingText = true;
        for (int i = 0; i <= resp.Length; i++)
        {
            if (showingText)
                chatText.text = resp.Substring(0, i);
            else i = resp.Length;
            yield return new WaitForSeconds(0.1f);
        }
        chatText.text = resp;
    }

    private void CheckSkip()
    {
        if (Input.anyKeyDown)
            showingText = false;
    }

    private void SetQuestions()
    {
        for (int i = 0; i < questionHolder.transform.childCount; i++)
        {
            Destroy(questionHolder.transform.GetChild(i));
        }

        foreach (var question in data.questions)
        {
            foreach (var answer in question.answers)
            {
                Instantiate(questionPrefab, questionHolder.transform);
                question.questionText = answer.answerText;
            }
        }
    }
    #endregion

    #region Utils public
    public void CheckConsequences()
    {
        foreach (var question in data.questions)
        {
            foreach (var answer in question.answers)
            {
                foreach (var consequences in answer.consequences)
                {
                    switch (consequences.willDo)
                    {
                        case WillDo.LoadScene:
                            consequences.LoadScene();
                            break;
                        case WillDo.NextQuestion:
                            consequences.NextQuestion();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
    #endregion

    #region Button Methods
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    public void ChangeToQuestions()
    {
        chatHolder.gameObject.SetActive(false);
        SetQuestions();
    }

    public void SetCurrentQuestion(int id)
    {
        data.currentQuestion = id;
    }
    #endregion

}
