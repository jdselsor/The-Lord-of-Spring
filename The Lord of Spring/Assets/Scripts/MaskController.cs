using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskController : MonoBehaviour
{
    [SerializeField] private Transform _target = null;
    [SerializeField] private float _smoothSpeed = 0.125f;
    [SerializeField] private Vector3 _offset = new Vector3(0.0f, 0.0f, -10.0f);

    private void Update()
    {
        Vector3 desiredPosition = _target.position + _offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        transform.position = smoothPosition;
    }
}
