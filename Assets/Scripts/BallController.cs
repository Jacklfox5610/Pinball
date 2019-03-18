using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが外にいく最大値
    float zvalue=-7.0f;
    int score = 0;
    GameObject gameOverText;
    GameObject scoreText;
    // Start is called before the first frame update
    void Start()
    {
        this.gameOverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {


        if(this.transform.position.z < zvalue)
        {
            this.gameOverText.GetComponent<Text>().text = "GameOver";
        }
        this.scoreText.GetComponent<Text>().text = "スコア："+ score.ToString();

    }
    void OnCollisionEnter(Collision other)
    {
        // タグによって光らせる色を変える
        if (other.gameObject.tag == "SmallStarTag")
        {
            score += 10;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            score += 20;
        }
        else if (other.gameObject.tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            score += 30;
        }

    }
}
