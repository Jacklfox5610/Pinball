using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{

    float defaultAngle = 20.0f;
    private float flickAngle = -20;
    HingeJoint myHingeJoint;
    // Start is called before the first frame update
    void Start()
    {
        this.myHingeJoint = this.GetComponent<HingeJoint>();
        SetAngle(this.defaultAngle);


    }

    // Update is called once per frame
    void Update()
    {
        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

//        Touch mytouch = Input.GetTouch(0);
        Touch[] myTouches = Input.touches;

        for (int i = 0; i < Input.touchCount; i++)
        {
            switch (myTouches[i].phase)
            {
                //タッチされた場所が右/左画面かつ右/左フリッパーであれば、右/左フリッパーをあげる。）
                case TouchPhase.Began:

                    if (myTouches[i].position.x > Screen.width / 2&&tag == "RightFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }
                    if (myTouches[i].position.x < Screen.width / 2 && tag == "LeftFripperTag")
                    {
                        SetAngle(this.flickAngle);
                    }
                    break;

                //タッチ画面が別の画面に移動したら、フリッパーを下げる。
                case TouchPhase.Moved:
                    if (myTouches[i].position.x < Screen.width / 2 && tag == "RightFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                    if (myTouches[i].position.x > Screen.width / 2 && tag == "LeftFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                    break;
                //タッチし終わったとき、タッチを離した場所 （positionでよい)かつ右/左フリッパーであれば、右/左フリッパーを下げる。
                case TouchPhase.Ended:

                    if (myTouches[i].position.x < Screen.width / 2 && tag == "LeftFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                    

                    if (myTouches[i].position.x > Screen.width / 2 && tag == "RightFripperTag")
                    {
                        SetAngle(this.defaultAngle);
                    }
                    break;

            }

                

        }
    }
    
    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
