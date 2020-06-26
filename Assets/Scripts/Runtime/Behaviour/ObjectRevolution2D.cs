using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using P2Playworks.ModularFrameworks;

public class ObjectRevolution2D : MonoBehaviour
{
    public ReferenceBool Clockwise;

    public ReferenceFloat Radius;

    public ReferenceFloat Speed;

    private void Update()
    {
        UpdatePosition(Radius, Speed);
    }

    void UpdatePosition(float radius, float speed)
    {
        var x = Mathf.Cos(Mathf.Deg2Rad * Time.time * speed * 36f) * radius;
        var y = Mathf.Sin(Mathf.Deg2Rad * Time.time * speed * 36f) * radius;
        var z = 0;

        var newPosition = new Vector3(x, y, z);

        transform.localPosition = newPosition;
    }
}