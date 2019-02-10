using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointDisplyController : MonoBehaviour
{

    //ポイントを表示するテキスト
    private GameObject pointText;

    // 合計ポイントの取得
    public PointController pointController;

    // Use this for initialization
    void Start()
    {
        //シーン中のPointTextオブジェクトを取得
        this.pointText = GameObject.Find("PointText");

        //PointTextを表示
        //this.pointText.GetComponent<Text>().text = pointController.SumPoint + "pt";

    }

    // Update is called once per frame
    void Update()
    {
        //合計ポイントを都度更新
        //this.pointText.GetComponent<Text>().text = pointController.SumPoint + "pt";
    }
}
