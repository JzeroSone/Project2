using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerate : MonoBehaviour
{
    public GameObject enemyPerfab;
    public Renderer boundaryRenderer;
    public int maxCount = 20;
    public float timer = 0.1f;

    public List<Transform> enemyTransformList = new List<Transform>();

    void Start()
    {
        InvokeRepeating("Generate", 0f, timer);
    }

    void Generate()
    {
        if(enemyTransformList.Count >= maxCount)
        {
            return;
        }
        GameObject enemy = Instantiate(enemyPerfab, RandomPosition(), Quaternion.Euler(Vector3.zero));
        AddEnemy(enemy.transform);
    }

    void AddEnemy(Transform enemy)
    {
        enemyTransformList.Add(enemy);
    }

    public void RemoveEnemy(Transform enemy)
    {
        enemyTransformList.Remove(enemy);
    }

    Vector3 RandomPosition()
    {
        Vector3 _position = Vector3.zero;
        _position.x = Random.Range(boundaryRenderer.bounds.min.x, boundaryRenderer.bounds.max.x);
        _position.y = Random.Range(boundaryRenderer.bounds.min.y, boundaryRenderer.bounds.max.y);
        return _position;
    }
}
