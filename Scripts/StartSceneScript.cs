using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartSceneScript : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget = 10;

    private Vector3 previousPosition;

    void Update()
    {
        RotateCam();
        ZoomCamera();
        OnClickStart();
    }

    void RotateCam()
    {
        if (Input.GetMouseButtonDown(1))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(1))
        {
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = previousPosition - newPosition;

            float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
            float rotationAroundXAxis = direction.y * 180; // camera moves vertically

            cam.transform.position = target.position;

            cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
            cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <— This is what makes it work!
            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

            previousPosition = newPosition;
        }
        else
        {
            cam.transform.position = target.position;
            cam.transform.Rotate(new Vector3(0, 1, 0), 0.03f, Space.World);
            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));
        }
    }

    void OnClickStart()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, distanceToTarget + 1))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }

    void ZoomCamera()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && distanceToTarget < 16)
        {
            distanceToTarget++;
            cam.transform.position = target.position;
            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && distanceToTarget > 3)
        {
            distanceToTarget--;
            cam.transform.position = target.position;
            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));
        }
    }
}