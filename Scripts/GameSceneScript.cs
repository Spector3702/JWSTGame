using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneScript : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform OriginalPoint;
    [SerializeField] private Transform Misson;
    [SerializeField] private float distanceToTarget = 1;

    private Vector3 previousPosition;
    public Text ValueText;

    // Update is called once per frame
    void Update()
    {
        RotateCam();
        OnClickMission();
        ShowCameraRotation();
    }

    void RotateCam()
    {
        if (Input.GetMouseButtonDown(1))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Debug.Log(Camera.main.transform.rotation.y);
        }
        else if (Input.GetMouseButton(1))
        {
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = previousPosition - newPosition;

            float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
            float rotationAroundXAxis = direction.y * 180; // camera moves vertically

            cam.transform.position = OriginalPoint.position;

            cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
            cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <— This is what makes it work!
            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

            previousPosition = newPosition;
        }
    }

    void OnClickMission()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            float distanceToMisson = Vector3.Distance(new Vector3(0, 0, 0), Misson.position);

            if (Physics.Raycast(ray, out hit, distanceToMisson + 40 + 1))
            {
                SceneManager.LoadScene("MissionScene");
            }
        }
    }

    void ShowCameraRotation()
    {
        float cam_x = Camera.main.transform.rotation.x;
        float cam_y = Camera.main.transform.rotation.y;
        float cam_z = Camera.main.transform.rotation.z;
        ValueText.text = "x:" + cam_x.ToString() + "\n" + "y:" + cam_y.ToString() + "\n" + "z:" + cam_z.ToString();
    }
}
