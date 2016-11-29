using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScoreView : MonoBehaviour
{
    private BirdController bird;

    private CanvasGroup canvasGroup;
    private Text scoreValueText;

    private bool isActive;

    // Use this for initialization
    void Start()
    {
        bird = Camera.main.transform.Find("Bird").GetComponent<BirdController>();

        canvasGroup = this.GetComponent<CanvasGroup>();
        scoreValueText = this.transform.Find("ScoreValue").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            scoreValueText.text = bird.score.ToString();
        }
    }

    public void Activate()
    {
        canvasGroup.alpha = 1;
        isActive = true;

        scoreValueText.text = bird.score.ToString();
    }

    public void Deactivate()
    {
        canvasGroup.alpha = 0;
        isActive = false;
    }
}
