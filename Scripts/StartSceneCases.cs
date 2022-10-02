using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RemptyTool.Flowser;

public class StartSceneCases : MonoBehaviour
{
    [SerializeField]
    ESMessageSystem msgSys;

    private int progress = 0;
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
                    msgSys.SetupButtonUIPrefab("StartScene_case0");

                    msgSys.SetupButtonItem("DefaultButtonItemPrefab", "Start new game", () =>
                    {
                        msgSys.Resume();
                        msgSys.RemoveButtonUI();
                    });
                    msgSys.SetupButtonItem("DefaultButtonItemPrefab", "resume", () => { });
                    msgSys.SetupButtonItem("DefaultButtonItemPrefab", "achievement", () => { });
                    msgSys.SetupButtonItem("DefaultButtonItemPrefab", "quit", () => { });
                    msgSys.ReadTextFromResource("StartSceneCase0");
                    break;
                case 1:
                    msgSys.ReadTextFromResource("StartSceneCase1");
                    break;
            }
            progress++;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Continue the messages, stoping by [w] or [lr] keywords.
            msgSys.Next();
        }
    }
}
