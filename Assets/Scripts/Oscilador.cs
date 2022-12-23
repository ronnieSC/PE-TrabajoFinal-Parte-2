using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]

public class Oscilador : MonoBehaviour
{
    [SerializeField] Vector3 motion;
    [SerializeField] float period = 1;
    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float interval = 0;
        if(period != 0)
            interval = Mathf.Sin(Mathf.PI * 2 * Time.time / period) / 2 + 0.5f;
        transform.position = initialPosition + motion * interval;
    }
}
