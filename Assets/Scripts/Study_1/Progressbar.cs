using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progressbar : MonoBehaviour
{
    [SerializeField] Slider bar;
    private float _max = 1.0f;

    private void Start()
    {
        // √ ±‚»≠
        bar.value = _max;
    }
    public void SetBarValue(float f)
    {
        bar.value = f;
    }
}
