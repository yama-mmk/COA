using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    // ゲームの進行管理
    public enum State {
        NONE = -1,     // 初期状態
        READY = 0,     // 開始状態
        PLAYING,       // プレイ中
        FINISH,        // 終了状態
    };

    public State state = State.NONE;

    // ゲームの難しさ
    public enum LEVEL {
        NONE = -1,     // 初期状態
        EASY = 0,      // 簡単
        NORMAL,        // 普通
        HARD,          // 難しい
        VERYHARD,      // 超難しい
    };

    public LEVEL level = LEVEL.NONE;

    // 時間
    public float time = 0.0f;

    private VegetableGenerator generator;

	void Start () {
        // 初期化
        state = State.READY;
        level = LEVEL.EASY;
        
        time = 0.0f;

        generator = GameObject.Find("VegetableGenerator").GetComponent<VegetableGenerator>();
	}

	void Update () {
        time += Time.deltaTime;

        switch(state) {
            case State.READY:

                if (time >= 3.0f) {
                    time = 0.0f;
                    state = State.PLAYING;
                    generator.level = LEVEL.EASY;
                }
                break;
            case State.PLAYING:

                if (time >= 4.0f) {
                    time = 0.0f;
                    if ((int)level == 3) {
                        level = 0;
                        generator.UpdateLevel(level);
                    } else {
                        level++;
                        generator.UpdateLevel(level);
                    }
                }
                break;
            case State.FINISH:
				time += Time.deltaTime;
				if(time > 4.0f) {
					Application.LoadLevel("Result");
				}
                break;
            default:
                break;
        }
	}

    public void GameOver() {
        Debug.Log("Game Over");
		state = State.FINISH;
		time = 0;
    }
}
