using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleManager : MonoBehaviour
{
    public float minObstacleOffset = 2f;
    public float maxObstacleOffset = 5f;
    public float maxCenterPosYOffset = 3f;

    private const float spawnPosX = 8f;

    private GameObject obstaclePrefab;
    private float obstacleHalfWidth;

    private List<GameObject> obstacles;

    private float nextObstacleSpawnPosX;
    private float nextCenterPosY;

    // Use this for initialization
    void Start()
    {
        obstaclePrefab = Resources.Load<GameObject>("Prefabs/Obstacle");
        obstacleHalfWidth = obstaclePrefab.GetComponentInChildren<BoxCollider2D>().size.x * 0.5f;

        obstacles = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.transform.position.x + spawnPosX >= nextObstacleSpawnPosX)
        {
            GameObject _newObstacle = (GameObject)Instantiate(obstaclePrefab, this.transform, false);
            _newObstacle.transform.position = new Vector3(nextObstacleSpawnPosX, 0f, 0f);
            _newObstacle.GetComponent<ObstacleController>().Initialize(nextCenterPosY);

            nextObstacleSpawnPosX = nextObstacleSpawnPosX + Random.Range(minObstacleOffset, maxObstacleOffset);
            nextCenterPosY += Random.Range(-maxCenterPosYOffset, maxCenterPosYOffset);

            float _maxCenterPosY = Camera.main.orthographicSize - obstaclePrefab.GetComponent<ObstacleController>().minSpace * 0.5f;
            if (nextCenterPosY > _maxCenterPosY)
            {
                nextCenterPosY = _maxCenterPosY;
            }
            else if (nextCenterPosY < _maxCenterPosY)
            {
                nextCenterPosY = -_maxCenterPosY;
            }
        }
    }

    public void OnStartGame()
    {
        foreach(GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }
        obstacles.Clear();

        GameObject _newObstacle = (GameObject)Instantiate(obstaclePrefab, this.transform, false);
        _newObstacle.transform.position = new Vector3(spawnPosX, 0f, 0f);
        _newObstacle.GetComponent<ObstacleController>().Initialize(nextCenterPosY);

        nextObstacleSpawnPosX = spawnPosX + Random.Range(minObstacleOffset, maxObstacleOffset);
        nextCenterPosY += Random.Range(-maxCenterPosYOffset, maxCenterPosYOffset);
    }
}
