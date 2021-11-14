using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegJump : MonoBehaviour
{
    public Rigidbody myRb;
    public bool ifCanJump;
    float cooldown = 0;

    public void Jump( float _force) {
        if (ifCanJump){

            //forceUp ��СΪ_force * amp,������
            float amp = 0.8f;
            Vector3 forceUp = Vector3.up * _force * amp;
            Vector3 forceForward = -1* transform.forward * _force * amp * 0.3f;
            //����ǰ�����ϵ���������
            myRb.AddForce(forceUp + forceForward);

            //���꿪ʼ��Ծ��ȴ
            ifCanJump = false;
            cooldown = 1f;
        }
        else{
            print("Can not Jump");
        }


    }

    private void Start()
    {
        Jump(300f);
    }

    private void Update(){

        if (cooldown > 0f) {
            //ÿһ��cooldown���һ
            cooldown -= Time.deltaTime;

            if (cooldown <= 0) {
                cooldown = 0;
                ifCanJump = true;
            }
        }


    }
    private void OnMouseDown()
    {
        Jump(100f);
        print("Clicked!!!!");
    }
}
