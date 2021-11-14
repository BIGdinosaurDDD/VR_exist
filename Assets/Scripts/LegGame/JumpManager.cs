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
        //先得到Arduino结果
        GetArduinoResult();
        //将结果转化成力
        CalculateForce();
        //输出力给Bridge
        SendResult();
    }

    void GetArduinoResult()
    {
        ArduinoResult = myLegListener2.msgResult;

    }

    void CalculateForce()
    {
        //公式自行修改
        forceOut =  ArduinoResult;
    }

    void SendResult()
    {
        if (forceOut >= 700f) {
            myLegJump.Jump(forceOut);

        }


    }
}
