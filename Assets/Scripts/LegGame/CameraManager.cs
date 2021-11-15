using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float offsetDistance = 10f;
    public GameObject myLeg;
    Vector3 offsetVector;
    Vector3 targetLastPosition;


    private void Awake()
    {
        targetLastPosition = myLeg.transform.position;
    }
    private void Update(){

        offsetVector = myLeg.transform.right * -1f * offsetDistance +Vector3.up *1.2f;
        Vector3 targetPosition = Vector3.Lerp(targetLastPosition,myLeg.transform.position, 0.01f);

        LookAtLeg(offsetVector,targetPosition);
        targetLastPosition = targetPosition;


    }

    void LookAtLeg(Vector3 _offsetVector, Vector3 _targetPosition ) {

        Vector3 finalPos = _targetPosition + _offsetVector;
        transform.position = Vector3.Lerp(transform.position, finalPos, 0.01f);
        transform.LookAt(_targetPosition, Vector3.up);



    }


}
