using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegGameManager : MonoBehaviour
{

    public LegListener myLegListener;
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
        ArduinoResult = myLegListener.msgResult;

    }

    void CalculateForce() {
        //��ʽ�����޸�
        forceOut = 10f * ArduinoResult;
    }

    void SendResult() {
        myWoodBridge.forceUp = forceOut;

    }
}