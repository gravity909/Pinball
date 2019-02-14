using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //ゲームオーバを表示するテキスト
    private GameObject pointText;

    // 合計ポイント
    private int sumPoint;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のPointTextオブジェクトを取得
        this.pointText = GameObject.Find("PointText");

        //PointTextを表示
        this.pointText.GetComponent<Text>().text = sumPoint + "pt";
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        // ターゲットそれぞれの持ち点を決定
        if (other.gameObject.tag == "SmallStarTag")
        {
            //合計ポイントへ追加する
            sumPoint += 10;

        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            //合計ポイントへ追加する
            sumPoint += 30;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            //合計ポイントへ追加する
            sumPoint += 50;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            //合計ポイントへ追加する
            sumPoint += 100;
        }

        //合計ポイントを都度更新
        this.pointText.GetComponent<Text>().text = sumPoint.ToString() + "pt";

    }
}

