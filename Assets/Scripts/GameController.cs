using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public bool isRunning { get; private set; }

    private MenuView menu;
    private ScoreView scorePanel;
    private GameSummaryView gameSummary;

    private BirdController bird;
    private ObstacleManager obstacleManager;
    private BackgroundController backgroundController;

    // Use this for initialization
    void Start()
    {
        isRunning = false;

        menu = GameObject.Find("Canvas/StartMenu").GetComponent<MenuView>();
        scorePanel = GameObject.Find("Canvas/ScorePanel").GetComponent<ScoreView>();
        gameSummary = GameObject.Find("Canvas/GameSummary").GetComponent<GameSummaryView>();

        bird = Camera.main.transform.Find("Bird").GetComponent<BirdController>();
        obstacleManager = GameObject.Find("ObstacleManager").GetComponent<ObstacleManager>();
        backgroundController = GameObject.Find("Background").GetComponent<BackgroundController>();

        menu.Activate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //========================================================================

    public void OnBirdDied()
    {
        isRunning = false;

        scorePanel.Deactivate();
        gameSummary.Activate();
    }

    //========================================================================

    public void OnStartGameButtonPressed()
    {
        menu.Deactivate();
        scorePanel.Activate();

        bird.OnStartGame();
        obstacleManager.OnStartGame();
        backgroundController.OnStartGame();

        isRunning = true;
    }

    public void OnExitGameButtonPressed()
    {
        Application.Quit();
    }

    public void OnBackToMenuButtonPressed()
    {
        gameSummary.Deactivate();
        menu.Activate();
    }

    //========================================================================

    
}
