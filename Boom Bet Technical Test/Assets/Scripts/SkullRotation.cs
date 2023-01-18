using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullRotation : Rotation
{
    private int speed = 15;
    void Update() 
    {
        RotateObject();
    }

    public override void RotateObject()
    {
        this.transform.Rotate(Vector3.forward * (speed * 5) * Time.deltaTime);
    }
}
