using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [field: SerializeField] public Transform TargetCamera { get; set; }

    private void Start()
    {
        TargetCamera = TargetCamera != null ? TargetCamera : Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(TargetCamera);
    }
}
