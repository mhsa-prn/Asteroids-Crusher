using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawner : MonoBehaviour
{
    #region Public Variables
    public GameObject[] asteroidsPrefab;
    public Vector2 timeToSpawn;
    public Vector2 xAxisLimitToSpawn;
    #endregion

    #region Private Variables
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(timeToSpawn.x, timeToSpawn.y));
        Vector3 pos = transform.position;
        pos.x = Random.Range(xAxisLimitToSpawn.x, xAxisLimitToSpawn.y);
        int rnd = Random.Range(0, asteroidsPrefab.Length);
        Instantiate(asteroidsPrefab[rnd], pos, Quaternion.identity);
        StartCoroutine(Spawn());
    }
    #endregion
}
