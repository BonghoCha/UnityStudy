using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDrag : MonoBehaviour
{
    Vector3 initialPos;

    private void Start()
    {
        initialPos = transform.position;
    }
    public void OnDrag()
    {
        transform.position = Input.mousePosition;
    }

    public void OnPointerUp()
    {
        transform.position = initialPos;
    }
}
