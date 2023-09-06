using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeLocalPosition : MonoBehaviour
{
    private Vector3 localPosition;

    private void Awake()
    {
        localPosition = this.transform.localPosition;
    }

    private void FixedUpdate()
    {
        this.transform.root.localPosition = localPosition;
    }
}
