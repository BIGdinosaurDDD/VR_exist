using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegJump : MonoBehaviour
{
    public Rigidbody myRb;
    public bool ifCanJump;
    float cooldown = 0;

    [Header("Test")]
    public float _forceTest = 0f;
    public bool _Jumptest;

    public void Jump( float _force) {
        if (ifCanJump){

            //forceUp 大小为_force * amp,方向朝上
            float amp = 0.8f;
            Vector3 forceUp = Vector3.up * _force * amp;
            Vector3 forceForward = -1* transform.forward * _force * amp * 0.3f;
            //把向前和向上的力加起来
            myRb.AddForce(forceUp + forceForward);

            //跳完开始跳跃冷却
            ifCanJump = false;
            cooldown = 1f;
        }
        else{
            print("Can not Jump");
        }


    }

    private void Start()
    {

    }

    private void Update(){

        if (cooldown > 0f) {
            //每一秒cooldown会减一
            cooldown -= Time.deltaTime;

            if (cooldown <= 0) {
                cooldown = 0;
                ifCanJump = true;
            }
        }

        // 打开测试跳跃功能
        OpenTest();

    }
    private void OnMouseDown()
    {
        Jump(100f);
        print("Clicked!!!!");
    }

    void OpenTest() {

        //判断开关是否打开，打开则
        if (_forceTest > 0f && _Jumptest) {
            Jump(_forceTest);
            _Jumptest = false;

        }

    }
    
}
