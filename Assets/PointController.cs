using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour {

    //ゲームオーバを表示するテキスト
    private GameObject pointText;

    // 合計ポイント
    private int sumPoint;
    //プロパティー
    //public int SumPoint
    //{
    //    get { return this.sumPoint; }  //取得用
    //    private set { this.sumPoint = value; } //値入力用
    //}
       

    // Use this for initialization
    void Start()
    {
        //シーン中のPointTextオブジェクトを取得
        this.pointText = GameObject.Find("PointText");

        //PointTextを表示
        this.pointText.GetComponent<Text>().text = sumPoint + "pt";

        
    }

    // Update is called once per frame
    void Update ()
    {
        

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
