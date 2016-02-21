using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DescriptionManager : MonoBehaviour {

    public enum State {
        DESCRIPTION,
        SLIDE,
        NEXT,
    }

    public State state = State.DESCRIPTION;

    private float time = 0;
    private float fin_time = 0;

    public Canvas d_canvas;
    public Canvas s_canvas;

    public Animator animator;

    void Start() {
        SoundManager.Instance.StopBGM();
        SoundManager.Instance.PlayBGM(4);
        Fader.instance.BlackIn(1.0f);

        d_canvas.gameObject.SetActive(true);
        s_canvas.gameObject.SetActive(false);
    }

    void Update() {
        switch(state) {
            case State.DESCRIPTION:
                if (Input.GetButtonDown("Fire1")) {
                    SoundManager.Instance.PlaySE((int)Random.Range(0, 1));
                    d_canvas.gameObject.SetActive(false);
                    s_canvas.gameObject.SetActive(true);
                    Fader.instance.WhiteIn(1.0f);
                    state = State.SLIDE;
                }
                break;
            case State.SLIDE:
                animator.SetTrigger("Start");
                time += Time.deltaTime;
                if (time >= 5.0f) {
                    state = State.NEXT;
                }

                if (Input.GetButtonDown("Fire1")) {
                    SoundManager.Instance.PlaySE((int)Random.Range(0, 1));
                    state = State.NEXT;
                }
                break;
            case State.NEXT:
                Fader.instance.BlackOut(1.0f, "Game");
                break;
        }
    }
}
