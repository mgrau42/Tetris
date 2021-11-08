using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pieceRotation : MonoBehaviour
{
    public Vector3 rotationPoint;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint),Vector3.forward,90);
            if(!( FindObjectOfType<pieceMovement>().onRange(0)))
                transform.RotateAround(transform.TransformPoint(rotationPoint),Vector3.forward,-90);
        }
    }
}
