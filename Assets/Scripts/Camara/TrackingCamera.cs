using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCamera : MonoBehaviour
{
    public Transform followObject;
    private Vector3 newPosition;

    [SerializeField]
    private float followVelocity;

    void Update()
    {
        newPosition = this.transform.position;
        newPosition.x = followObject.transform.position.x;
        transform.position = newPosition;
    }
}
