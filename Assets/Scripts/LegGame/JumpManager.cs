using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpManager : MonoBehaviour
{
    public LegListener2 myLegListener2;
    public LegJump myLegJump;

    float ArduinoResult;
    float forceOut;


    void Update()
    {
        //�ȵõ�Arduino���
        GetArduinoResult();
        //�����ת������
        CalculateForce();
        //�������Bridge
        SendResult();
    }

    void GetArduinoResult()
    {
        ArduinoResult = myLegListener2.msgResult;

    }

    void CalculateForce()
    {
        //��ʽ�����޸�
        forceOut =  ArduinoResult;
    }

    void SendResult()
    {
        if (forceOut >= 700f) {
            myLegJump.Jump(forceOut);

        }


    }
}
