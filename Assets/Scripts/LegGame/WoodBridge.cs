using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBridge : MonoBehaviour
{
    //Force���
    public float forceDown = -5f;
    public float forceUp = 0f;
    float forceAdded = 0f;

    //��ҽ������
    float finishAmount = 0;
    bool ifPlaying = false;
    bool ifWinning = false;

    //���Ӿ����
    public float angleUp = 0f;

    private void Start()
    {
        ifPlaying = false;
    }

    private void Update(){

        //���ж���Ϸ�Ƿ����/��ʼ
        if (ifPlaying == true)
        {
            //�������
            forceAdded = forceDown + forceUp;
            //����ĳ������ó������� ��˾���޸�
            float riseAmount = forceAdded * 0.5f;

            //ĿǰforceOutput��ΪBridgeChange������ֵ
            BridgeChange(riseAmount);

            //����ж�ʤ������
            if (finishAmount < -100){
                BridgeFailed();
            }
            else if (finishAmount < -100){
                BridgeSucceed();
            
            }
        }
        else {
            //��Ϸδ��ʼ��ʱ�����ý��
            finishAmount = 0f;
        }

        //�����ŵ���תangle
        transform.eulerAngles= new Vector3(angleUp, 0f, 0f);

        //���ж��Ƿ��ڲ���Winning Effect
        if (ifWinning == true) {

            //�����ûת���׾ͼ���
            if (angleUp > 0f && angleUp < 90f){
                BridgeUpEffect();
            }

            //��������˾�ͣ��
            else if (angleUp >= 90){
                angleUp = 90f;
                ifWinning = false;
            }
        }

    }

    void BridgeChange(float _riseAmount){

        //�ж����ӻ����
        if(_riseAmount > 0){
            print("Bridge Rise !!!");
            //����Ȼ����Щʲô�أ�
        }
        else if (_riseAmount < 0){
            print("Bridge Down !!!");
            //����Ȼ����Щʲô�أ�
        }

        //�ܽ�������RiseAmount
        finishAmount += _riseAmount; 

    }

    void BridgeSucceed() {
        print("Bridge Mission Succeed!!!");
        //ʤ����
        ifWinning = true;
        ifPlaying = false;

    }

    void BridgeFailed()
    {
        print("Bridge Mission Failed!!!");
        ifPlaying = false;

    }

    void BridgeUpEffect() {
        float upSpeed = 1f;
        angleUp += upSpeed;

    }

}
