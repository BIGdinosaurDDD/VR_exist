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
        //先得到Arduino结果
        GetArduinoResult();
        //将结果转化成力
        CalculateForce();
        //输出力给Bridge
        SendResult();
    }

    void GetArduinoResult() {
        ArduinoResult = myLegListener.msgResult;

    }

    void CalculateForce() {
        //公式自行修改
        forceOut = 10f * ArduinoResult;
    }

    void SendResult() {
        myWoodBridge.forceUp = forceOut;

    }
}
