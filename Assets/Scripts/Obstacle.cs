using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float _timer;
    public float MaxTime;
    public List<GameObject> Obstacles;
    
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= MaxTime)
        {
            GenerateObstacle();
            _timer = 0;
        }
    }

    void GenerateObstacle()
    {
        int obstacleIndex = Random.Range(1, Obstacles.Count);
        Instantiate(Obstacles[obstacleIndex], new Vector3(12,Obstacles[obstacleIndex].transform.position.y,0), Quaternion.identity);
    }
}
