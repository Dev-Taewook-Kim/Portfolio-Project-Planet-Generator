using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using P2Playworks.ModularFrameworks;

public class ObjectRotation2D : MonoBehaviour
{
    public ReferenceBool Clockwise;

    public ReferenceBool Resonance;

    public ReferenceFloat Speed;

    private void Start()
    {
        if (Speed == null)
        {
            Speed = 1f;
        }
    }

    private void Update()
    {
        UpdatePosition(Speed, Clockwise, Resonance);
    }

    void UpdatePosition(float speed, bool clockwise, bool resonance)
    {
        var direction = clockwise ? -1 : 1;

        transform.Rotate(Vector3.forward, Speed * direction * Time.smoothDeltaTime);

        if (resonance)
        {
            var x = 0;
            var y = Mathf.Sin(Time.time * speed) * Time.smoothDeltaTime;
            var z = 0;

            var newPosition = new Vector3(x, y, z);

            transform.localPosition += newPosition;
        }
    }
}