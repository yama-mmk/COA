using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VegetableGenerator : MonoBehaviour {

    public List<GameObject> vegetables;

    private GameManager manager;
    private GameManager.LEVEL level;

	void Start () {
        // Level初期化
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        level = manager.level;
	}

	void Update () {
        switch(level) {
            case GameManager.LEVEL.EASY:
                GenerateVegetable(7.0f);
                break;
            case GameManager.LEVEL.NORMAL:
                GenerateVegetable(5.0f);
                break;
            case GameManager.LEVEL.HARD:
                GenerateVegetable(4.0f);
                break;
            case GameManager.LEVEL.VERYHARD:
                GenerateVegetable(3.0f);
                break;
        }
	}

    private IEnumerator GenerateVegetable(float time) {
        yield return new WaitForSeconds(time);

        int num = (int)Random.Range(0, vegetables.Count);
        Instantiate(vegetables[num], new Vector2(12.0f, -2.0f), Quaternion.identity);
    }

    // レベル更新
    public void UpdateLevel(GameManager.LEVEL l) {
        this.level = l;
    }
}
