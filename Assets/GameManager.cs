using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public DialogData data { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance != null)
            Destroy(this);

        Instance = this;
    }

    public void UpdateData(DialogData data)
    {
        this.data = data;
    }

}
