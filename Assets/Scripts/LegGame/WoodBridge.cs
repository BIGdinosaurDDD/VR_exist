using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBridge : MonoBehaviour
{
    //Force相关
    public float forceDown = -5f;
    public float forceUp = 0f;
    float forceAdded = 0f;

    //玩家进度相关
    float finishAmount = 0;
    bool ifPlaying = false;
    bool ifWinning = false;

    //桥视觉相关
    public float angleUp = 0f;

    private void Start()
    {
        ifPlaying = false;
    }

    private void Update(){

        //先判断游戏是否结束/开始
        if (ifPlaying == true)
        {
            //计算合力
            forceAdded = forceDown + forceUp;
            //进行某种运算得出运算结果 公司可修改
            float riseAmount = forceAdded * 0.5f;

            //目前forceOutput作为BridgeChange的输入值
            BridgeChange(riseAmount);

            //最后判断胜负条件
            if (finishAmount < -100){
                BridgeFailed();
            }
            else if (finishAmount < -100){
                BridgeSucceed();
            
            }
        }
        else {
            //游戏未开始的时候重置结果
            finishAmount = 0f;
        }

        //更新桥的旋转angle
        transform.eulerAngles= new Vector3(angleUp, 0f, 0f);

        //先判断是否在播放Winning Effect
        if (ifWinning == true) {

            //如果还没转到底就继续
            if (angleUp > 0f && angleUp < 90f){
                BridgeUpEffect();
            }

            //如果到底了就停下
            else if (angleUp >= 90){
                angleUp = 90f;
                ifWinning = false;
            }
        }

    }

    void BridgeChange(float _riseAmount){

        //判断增加或减少
        if(_riseAmount > 0){
            print("Bridge Rise !!!");
            //上升然后做些什么呢？
        }
        else if (_riseAmount < 0){
            print("Bridge Down !!!");
            //上升然后做些什么呢？
        }

        //总进度增加RiseAmount
        finishAmount += _riseAmount; 

    }

    void BridgeSucceed() {
        print("Bridge Mission Succeed!!!");
        //胜利了
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
