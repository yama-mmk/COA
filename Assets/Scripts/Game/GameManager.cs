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
    private float time = 0.0f;

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

                if (time >= 5.0f) {
                    time = 0.0f;
                    state = State.PLAYING;
                }
                break;
            case State.PLAYING:

                if (time >= 15.0f) {
                    time = 0.0f;
                    switch(level) {
                        case LEVEL.EASY:
                            generator.UpdateLevel(LEVEL.NORMAL);
                            break;
                        case LEVEL.NORMAL:
                            generator.UpdateLevel(LEVEL.HARD);
                            break;
                        case LEVEL.HARD:
                            generator.UpdateLevel(LEVEL.VERYHARD);
                            break;
                    }
                }
                break;
            case State.FINISH:
                break;
            default:
                break;
        }
	}
}
