using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RemptyTool.Flowser;
using UnityEngine.SceneManagement;

public class AchieveSceneCases : MonoBehaviour
{
    [SerializeField]
    ESMessageSystem msgSys;

    private int progress = 0;
    private bool isGameEnd = false;
    void Start()
    {
        // Define your customized keyword functions.
        msgSys.AddSpecialCharToFuncMap("UsageCase", CustomizedFunction);
    }
    private void CustomizedFunction()
    {
        Debug.Log("Hi! This is called by CustomizedFunction!");
    }

    void Update()
    {
        if (msgSys.isCompleted)
        {
            switch (progress)
            {
                case 0:
                    msgSys.SetupDialogUIPrefab("AchieveDialogue");
                    msgSys.SetupButtonUIPrefab("AchieveButton");
                    msgSys.SetupButtonItem("DefaultButtonItemPrefab", "Get new Achievement!", () =>
                    {
                        SceneManager.LoadScene("EndScene");
                    });
                    msgSys.ReadTextFromResource("AchieveSceneCase0");
                    break;
                case 3:
                    isGameEnd = true;
                    break;
            }
            progress++;
        }

        if (!isGameEnd && Input.GetKeyDown(KeyCode.Space))
        {
            //Continue the messages, stoping by [w] or [lr] keywords.
            msgSys.Next();
        }
    }
}
