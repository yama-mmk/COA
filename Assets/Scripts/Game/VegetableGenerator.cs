﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VegetableGenerator : MonoBehaviour {

    public List<GameObject> vegetables;

    private GameManager manager;
    public GameManager.LEVEL level;

    float generate_time = 0.0f;

	void Start () {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        level = GameManager.LEVEL.NONE;

        generate_time = 0.0f;
	}

	void Update () {
		generate_time += Time.deltaTime;
        switch(level) {
            case GameManager.LEVEL.EASY:
                if (generate_time >= 3.0f) {
                    GenerateVegetable();
                    generate_time = 0.0f;
                }
                break;
            case GameManager.LEVEL.NORMAL:
                if (generate_time >= 2.5f) {
                    GenerateVegetable();
                    generate_time = 0.0f;
                }
                break;
            case GameManager.LEVEL.HARD:
                if (generate_time >= 1.5f) {
                    GenerateVegetable();
                    generate_time = 0.0f;
                }
                break;
            case GameManager.LEVEL.VERYHARD:
                if (generate_time >= 1.0f) {
                    GenerateVegetable();
                    generate_time = 0.0f;
                }
                break;
            default:
                break;
        }
	}

    void GenerateVegetable() {
        int num = Random.Range(0, vegetables.Count);
        if (num == 4) {
			Instantiate (vegetables [num], new Vector2 (12.0f, -3.0f), Quaternion.Euler (new Vector3 (0, 0, 90)));
		} else {
			Instantiate (vegetables [num], new Vector2 (12.0f, -3.0f), Quaternion.identity);
		}
    }

    // レベル更新
    public void UpdateLevel(GameManager.LEVEL l) {
        level = l;
    }
}
