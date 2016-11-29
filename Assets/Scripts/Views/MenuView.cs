using UnityEngine;
using System.Collections;

public class MenuView : MonoBehaviour {

    private CanvasGroup canvasGroup;

	// Use this for initialization
	void Start () {
        canvasGroup = this.GetComponent<CanvasGroup>();

        this.Deactivate();
	}
	
	// Update is called once per frame
	/*void Update () {
	
	}*/

    public void Activate()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void Deactivate()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
