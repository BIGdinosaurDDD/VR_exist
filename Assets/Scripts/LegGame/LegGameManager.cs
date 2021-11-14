using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegGameManager : MonoBehaviour
{

    public LegListener2 myLegListener2;
    public WoodBridge myWoodBridge;

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

    void GetArduinoResult() { 
        ArduinoResult = myLegListener2.msgResult;

    }

    void CalculateForce() {
        //��ʽ�����޸�
        forceOut = 1000f * ArduinoResult;
    }

    void SendResult() {
        myWoodBridge.forceUp = forceOut;
        myWoodBridge.angleUp = forceOut;

    }
}
