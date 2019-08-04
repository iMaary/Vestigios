using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

[CreateAssetMenu(fileName = "DialogData", menuName = "DialogData", order = 1)]
public class DialogData : ScriptableObject
{
    [HideInInspector] public int currentQuestion;

    public Question[] questions;
}

[Serializable]
public class Question
{
    [Header("UI")]
    public Sprite background;
    public Sprite character;
    public Sprite otherCharacter;

    [Header("Settings")]
    public int id;
    public string questionText;
    public Answer[] answers;
}

[Serializable]
public class Answer
{
    public string answerText;
    public Consequences[] consequences;
}

[Serializable]
public class Consequences
{
    #region Variables
    public string sceneName;
    public int nextQuestionId;
    #endregion

    #region Enums
    public WillDo willDo; // Checked on UIController.CheckConsequences();
    #endregion

    #region Methods
    public void LoadScene()
    {
        if (sceneName != null)
            SceneManager.LoadScene(sceneName);
    }

    public void NextQuestion()
    {
        GameManager.Instance.data.currentQuestion = nextQuestionId;
        UIController.Instance.UpdateDialog(nextQuestionId);
    }
    #endregion

    #region Util
    private void ChangeToChat()
    {
        UIController.Instance.chatHolder.gameObject.SetActive(true);
    }
    #endregion
}

public enum WillDo { LoadScene, NextQuestion, }