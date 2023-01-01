using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletDirection
{
    UP,
    DOWN
}

public class BulletController : MonoBehaviour
{
    #region Public Variables
    public float speed;
    public BulletDirection direction;
    public GameObject explosionPrefab;
    public int power;
    #endregion

    #region Private Variables
    private Vector3 move = Vector3.down;
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Start()
    {
        if(direction == BulletDirection.DOWN)
        {
            move = Vector3.down;
        }
        else
        {
            move = Vector3.up;
        }
    }

    private void Update()
    {
        //transform.position += Vector3.up * speed * Time.deltaTime;
        transform.Translate(move * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(explosionPrefab, col.contacts[0].point, Quaternion.identity);
        //Destroy(col.gameObject);
        Destroy(gameObject);
    }
    #endregion
}
