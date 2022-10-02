using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RemptyTool.Flowser;

public class MissionSceneCases : MonoBehaviour
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
                    msgSys.SetupDialogUIPrefab("MissionDialogue");
                    msgSys.ReadTextFromResource("MissionSceneCase0");
                    break;

                case 1:
                    msgSys.SetupDialogUIPrefab("DefaultDialogUIPrefab");
                    msgSys.ReadTextFromResource("MissionSceneCase1");
                    break;

                case 2:
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
