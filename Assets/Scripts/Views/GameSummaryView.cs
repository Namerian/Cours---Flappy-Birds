using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameSummaryView : MonoBehaviour
{
    private BirdController bird;

    private CanvasGroup canvasGroup;
    private Text scoreValueText;

    // Use this for initialization
    void Start()
    {
        bird = Camera.main.transform.Find("Bird").GetComponent<BirdController>();
        canvasGroup = this.GetComponent<CanvasGroup>();
        scoreValueText = this.transform.Find("FinalScorePanel/ScoreValue").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void Activate()
    {
        Debug.Log("game summary activated");

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        scoreValueText.text = bird.score.ToString();
    }

    public void Deactivate()
    {
        Debug.Log("game summary deactivated");

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
