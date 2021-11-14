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
        //先得到Arduino结果
        GetArduinoResult();
        //将结果转化成力
        CalculateForce();
        //输出力给Bridge
        SendResult();
    }

    void GetArduinoResult() { 
        ArduinoResult = myLegListener2.msgResult;

    }

    void CalculateForce() {
        //公式自行修改
        forceOut = 1000f * ArduinoResult;
    }

    void SendResult() {
        myWoodBridge.forceUp = forceOut;
        myWoodBridge.angleUp = forceOut;

    }
}
