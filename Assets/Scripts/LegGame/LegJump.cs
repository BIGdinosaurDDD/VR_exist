using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegJump : MonoBehaviour {
    public Rigidbody footRb;
    public Rigidbody myLegRb;
    public bool ifCanJump;
    float cooldown = 0;

    [Header("Test")]
    public float _forceTest = 0f;
    public bool _Jumptest;

    public void Jump(float _force)
    {
        if (ifCanJump)
        {
            //forceUp 大小为_force * amp,方向朝上
            float amp = 2.5f;
            Vector3 forceUp = Vector3.up * _force * amp;
            Vector3 forceForward = -1 * myLegRb.transform.forward * _force * amp * 0.3f;
            //把向前和向上的力加起来
            myLegRb.AddForce(forceUp + forceForward);

            //跳完开始跳跃冷却
            ifCanJump = false;
            cooldown = 1f;
        }
        else
        {
            print("Can not Jump");
        }
    }

    private void Update()
    {
        DetectInAir();

        // 打开测试跳跃功能
        OpenTest();
    }
    void DetectInAir()
    {
        // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries

        Vector3 down = -1f * myLegRb.transform.up;
        RaycastHit _hit;

        if (Physics.Raycast(myLegRb.transform.position, down, out _hit, 0.15f))
        {
            Debug.DrawRay(myLegRb.transform.position, down * _hit.distance, Color.green);
            ifCanJump = true;
        }
        else
        {
            Debug.DrawRay(myLegRb.transform.position, down * _hit.distance, Color.red);
            ifCanJump = false;
        }
    }

    void OpenTest()
    {

        //判断开关是否打开，打开则
        if (_forceTest > 0f && _Jumptest)
        {
            Jump(_forceTest);
            _Jumptest = false;

        }
    }
}

