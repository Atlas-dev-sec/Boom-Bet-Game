using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombRotation : Rotation
{
    private int speed = 15;
    void Update() 
    {
        RotateObject();
    }

    public override void RotateObject()
    {
        this.transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }


}
