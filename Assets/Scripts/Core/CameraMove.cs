using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] InputGetter inputGetter;
    [Header("Move")]
    [SerializeField] float speedMove;
    [Header("Zoom")]
    [SerializeField] Transform cameraChild;//Must look to direction of zoom
    [SerializeField] float speedZoom;
    [SerializeField] float maxComingCameraZ;
    [SerializeField] float maxLowerCameraZ;//Must be less zero
    private void Start()
    {
        
    }

    private void Update()
    {
        Move();
        Zoom();
    }

    private void Zoom()
    {
        //Move local camera to simulate the zoom
        var direction = new Vector3(0, 0, inputGetter.MouseScrollDelta.y);
        cameraChild.Translate(direction * speedZoom * Time.deltaTime);
        //Limit of zoom
        if (cameraChild.localPosition.z > 0)
            cameraChild.localPosition = Vector3.ClampMagnitude(cameraChild.localPosition, maxComingCameraZ);
        else if (cameraChild.localPosition.z < 0)
            cameraChild.localPosition = Vector3.ClampMagnitude(cameraChild.localPosition, maxLowerCameraZ);
    }

    private void Move()
    {
        var vertical = inputGetter.Vertical;
        var horizontal = inputGetter.Horizontal;
        var move = new Vector3(horizontal, 0, vertical);
        transform.Translate(move * speedMove * Time.deltaTime);
    }
}
