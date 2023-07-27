using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class gamemanager : MonoBehaviour
{
    public static gamemanager Instance { get; private set; }
    public int totaldeliveries = 0;


    public event EventHandler OnStateChanged;
    private enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
    }
    private State state;
    private float waitingToStartTimer = 1f;
    private float countdownToStartTimer = 3.9f;
    private float gamePlayingTimer = 35f;
    float timeupdate = 35f;

    private void Awake()
    {
        Instance = this;
        state = State.WaitingToStart;
    }

    public void delivered()
    {
        totaldeliveries++;
        settimer();
    }

        private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if (waitingToStartTimer < 0f)
                {
                    state = State.CountdownToStart;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if (countdownToStartTimer < 0f) {
                    state = State.GamePlaying;
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0f)
                {
                    state = State.GameOver;
                }
                break;
            case State.GameOver:
                break;
        }
        Debug.Log(state);

    }

    public void settimer()
    {
        gamePlayingTimer = gamePlayingTimer +  35f;
        timeupdate = gamePlayingTimer;
    }
    public int gameplayingtimer()
    {
        return (int)countdownToStartTimer;
    }
    public bool iscountdownstartactive()
    {
        return state == State.CountdownToStart;
    }
    public float gameplaytimegetter()
    {
        return gamePlayingTimer / timeupdate;
    }
    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }
    public bool IsGameOver()
    {
        return state == State.GameOver;
    }
}
