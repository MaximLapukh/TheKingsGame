using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputGetter : MonoBehaviour
{
    public UnityEvent Click0;
    public UnityEvent Click1;

    //todo: cannot modify in runtime
    public float Vertical;
    public float Horizontal;

    public Vector2 MouseScrollDelta;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) Click0.Invoke();
        if (Input.GetMouseButtonDown(1)) Click1.Invoke();

        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");

        MouseScrollDelta = Input.mouseScrollDelta;
    }
}
