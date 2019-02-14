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

    //右フリッパーのID
    private int rightFingerId = 5;

    //左フリッパーのID
    private int leftFingerId = 5;

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
            for (int i = 0; i < Input.touchCount; i++)
            {
                //画面タッチの左右でIDを割り振る
                if (Input.GetTouch(i).position.x > Screen.width * 0.5f && tag == "RightFripperTag")
                {
                    rightFingerId = Input.GetTouch(i).fingerId;
                }
                else if (Input.GetTouch(i).position.x < Screen.width * 0.5f && tag == "LeftFripperTag")
                {
                    leftFingerId = Input.GetTouch(i).fingerId;
                }



                //タッチによって、上げ下げを指定
                if (Input.GetTouch(i).fingerId == rightFingerId && tag == "RightFripperTag")
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        SetAngle(this.flickAngle);
                    }
                    else if (Input.GetTouch(i).phase == TouchPhase.Ended)
                    {
                        SetAngle(this.defaultAngle);
                        rightFingerId = 5;
                    }
                }
                else if (Input.GetTouch(i).fingerId == leftFingerId && tag == "LeftFripperTag")
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        SetAngle(this.flickAngle);
                    }
                    else if (Input.GetTouch(i).phase == TouchPhase.Ended)
                    {
                        SetAngle(this.defaultAngle);
                        leftFingerId = 5;
                    }
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