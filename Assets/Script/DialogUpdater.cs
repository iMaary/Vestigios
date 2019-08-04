using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogUpdater : MonoBehaviour
{

    private void Start()
    {
        UIController.Instance.UpdateDialog(GameManager.Instance.data.currentQuestion);
    }

}
