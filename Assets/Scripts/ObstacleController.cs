using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour
{
    public float minSpace = 2;

    private BirdController bird;
    private bool passed;

    public void Initialize(float centerPosY)
    {
        Transform topPillar = this.transform.Find("TopPillar");
        Transform bottomPillar = this.transform.Find("BottomPillar");

        float _pillarHalfHeight = topPillar.GetComponent<BoxCollider2D>().size.y * 0.5f;

        topPillar.localPosition = new Vector3(0f, centerPosY + minSpace * 0.5f + _pillarHalfHeight, 0f);
        bottomPillar.localPosition = new Vector3(0f, centerPosY - minSpace * 0.5f - _pillarHalfHeight, 0f);
    }

    // Use this for initialization
    void Start()
    {
        bird = Camera.main.transform.Find("Bird").GetComponent<BirdController>();
        passed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!passed && bird.transform.position.x > this.transform.position.x)
        {
            bird.score += 1;
            passed = true;
        }
    }
}
