using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MissionSceneScripts : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform Achieve;

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
        OnClickAchieve();
        float cam_x = Camera.main.transform.position.x;
        float cam_y = Camera.main.transform.position.y;
        float cam_z = Camera.main.transform.position.z;
        Vector3 vCamPos = new Vector3(cam_x, cam_y, cam_z);
        float distanceToAchieve = Vector3.Distance(vCamPos, Achieve.position);
        if (Input.GetMouseButton(0))
        {
            Debug.Log(distanceToAchieve);
        }
    }

    void MoveCamera()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            float cam_x = Camera.main.transform.position.x;
            float cam_y = Camera.main.transform.position.y;
            float cam_z = Camera.main.transform.position.z;
            Vector3 vCamPos = new Vector3(cam_x - 0.3f, cam_y, cam_z);
            Camera.main.transform.position = vCamPos;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            float cam_x = Camera.main.transform.position.x;
            float cam_y = Camera.main.transform.position.y;
            float cam_z = Camera.main.transform.position.z;
            Vector3 vCamPos = new Vector3(cam_x + 0.3f, cam_y, cam_z);
            Camera.main.transform.position = vCamPos;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            float cam_x = Camera.main.transform.position.x;
            float cam_y = Camera.main.transform.position.y;
            float cam_z = Camera.main.transform.position.z;
            Vector3 vCamPos = new Vector3(cam_x, cam_y + 0.3f, cam_z);
            Camera.main.transform.position = vCamPos;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            float cam_x = Camera.main.transform.position.x;
            float cam_y = Camera.main.transform.position.y;
            float cam_z = Camera.main.transform.position.z;
            Vector3 vCamPos = new Vector3(cam_x, cam_y - 0.3f, cam_z);
            Camera.main.transform.position = vCamPos;
        }
    }

    void OnClickAchieve()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            float cam_x = Camera.main.transform.position.x;
            float cam_y = Camera.main.transform.position.y;
            float cam_z = Camera.main.transform.position.z;
            Vector3 vCamPos = new Vector3(cam_x, cam_y, cam_z);

            float distanceToAchieve = Vector3.Distance(vCamPos, Achieve.position);

            if (Physics.Raycast(ray, out hit, distanceToAchieve + 10))
            {
                SceneManager.LoadScene("AchieveScene");
            }
        }
    }
}
