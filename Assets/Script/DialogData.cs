using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "DialogData", menuName = "DialogData", order = 1)]
public class DialogData : ScriptableObject
{
    public Question[] questions;
}

[Serializable]
public class Question
{
    public int id;
    public string questionText;
    public Answer[] answers;
}

[Serializable]
public class Answer
{
    public string answerText;
    public string questionResult;
}