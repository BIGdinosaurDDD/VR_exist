using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpManager : MonoBehaviour
{
    public LegListener2 myLegListener2;
    public LegJump myLegJump;

    public bool ifGatherMode = true;
    public float forceGathered;
    [Header("Test")]
    public bool testGather;
    [Header("PowerUI")]
    public Slider powerSlider;

    float ArduinoResult;
    float forceOut;

    void Update(){

        //先得到Arduino结果
        GetArduinoResult();


        //将结果转化成力
        if (ifGatherMode){
            GatherForce(ArduinoResult);
            //如果中断蓄力，则自动发射
            if (ArduinoResult < 0f && forceGathered > 50f) {
                SendForce(forceGathered);
            }
        }
        else {
            DetectForce(ArduinoResult);
            //输出力给Bridge
            SendForce(forceOut);
        }

        //Test
        TestGather();

        //Update UI
        UpdateUI();
    }

    void GetArduinoResult(){
        ArduinoResult = myLegListener2.msgResult;

    }

    void TestGather() {

        if (testGather){
            GatherForce(300f);
        }
        else {
            SendForce(forceGathered);
            forceGathered = 0f;
        }

    }

    void DetectForce(float _force){
        //公式自行修改
        forceOut = _force;

    }

    void GatherForce(float _force) {

        forceGathered += (_force * 0.12f + _force * forceGathered * 0.002f)* Time.deltaTime;

        if (!ifGatherMode)
        {
             forceGathered -= 30f * Time.deltaTime;
        }

    }

    void SendForce(float _force) {

        if (_force > 50f) {
            myLegJump.Jump(_force);
        }

        // Clear forceGathered
        if (ifGatherMode){
            forceGathered = 0f;
        }

    }

    void UpdateUI() {
        float _max = 800f;
        float _min = 0f;
        powerSlider.value = Remap(forceGathered, _min, _max, 0f, 1f);

    }

    float Remap(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
}
