using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour
{
    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // Use this for initialization
    void Start()
    {
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
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

        //マルチタップ対応
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            //画面右半分をタッチしていたら右フリッパー起動
            if (touch.position.x > Screen.width * 0.5f && tag == "RightFripperTag")
            {
                if (touch.phase == TouchPhase.Began)
                {
                    SetAngle(this.flickAngle);
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    SetAngle(this.defaultAngle);
                }
            }
            //画面左半分をタッチしていたら左フリッパー起動
            else if (touch.position.x < Screen.width * 0.5f && tag == "LeftFripperTag")
            {
                if (touch.phase == TouchPhase.Began)
                {
                    SetAngle(this.flickAngle);
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    SetAngle(this.defaultAngle);
                }
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