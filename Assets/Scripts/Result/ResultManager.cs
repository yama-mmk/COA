using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultManager : MonoBehaviour {

    int score = 0;

    public Sprite bad;
    public Sprite normal;
    public Sprite good;

    public Image img;
    public Text comment_text;
    public Text score_text;
    public Text highscore_text;

    private bool isUpdate = false;

    void Start() {
        Time.timeScale = 1.0f;
        Fader.instance.WhiteIn(2.0f);
        score = GameManager.final_value;

        comment_text.text = "";
        score_text.text = "スコア : " + score.ToString();
        highscore_text.text = "";
        isUpdate = false;

        // ハイスコア更新確認
        int r = PlayerPrefs.GetInt("High");
        if (score >= r) {
            PlayerPrefs.SetInt("High", score);
            isUpdate = true;
        }

        if (score <= 3000) {
            img.sprite = bad;
            comment_text.text = "なんか微妙ブヒ～";
            if (isUpdate) {
                highscore_text.text = "ハイスコア更新！";
            }
        }
        else if (score <= 6000) {
            img.sprite = normal;
            comment_text.text = "普通だなブヒ～";
            if (isUpdate) {
                highscore_text.text = "ハイスコア更新！";
            }
        }
        else {
            img.sprite = good;
            comment_text.text = "カレーになっても本望だブヒ～";
            if (isUpdate) {
                highscore_text.text = "ハイスコア更新！";
            }
        }
    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            // Application.LoadLevel("Game");
            Fader.instance.WhiteOut(1.0f, "Title");
        }
    }
}
