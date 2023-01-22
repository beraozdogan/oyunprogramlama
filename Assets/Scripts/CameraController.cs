using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform TargetTransform;
    public Vector3 offset = Vector3.zero;

    public float cameraSpeed;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - TargetTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = TargetTransform.position + offset;

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * cameraSpeed);
    }
}
