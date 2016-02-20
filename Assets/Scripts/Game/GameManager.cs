using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    // ゲームの進行管理
    public enum State {
        NONE = -1,     // 初期状態
        READY = 0,     // 
        PLAYING,
        FINISH,
    };

    // ゲームの難しさ
    public enum LEVEL {
        NONE = -1,
        EASY = 0,
        NORMAL,
        HARD,
        VERYHARD,
    };

    public LEVEL level = LEVEL.NONE;

	void Start () {

	}

	void Update () {
	
	}
}
