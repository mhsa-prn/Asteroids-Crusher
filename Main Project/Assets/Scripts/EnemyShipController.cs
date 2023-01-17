using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    #region Public Variables
    public float vSpeed; //vertical speed
    public float hSpeed; //Horizontal speed
    public GameObject bulletPrefab;
    public Vector2 timeToFire;
    public GameObject gun;
    public int power;

    #endregion

    #region Private Variables
    private int direction = 0; //1=> right   -1=> left    0=> no left no right
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Start()
    {
        InvokeRepeating("ChangeDirection", 1, 0.5f);
        InvokeRepeating("Fire", timeToFire.x, timeToFire.y);
    }

    private void Update()
    {
        Vector3 move = Vector3.down;
        move.x = direction * hSpeed;
        move.y = direction * vSpeed;
        transform.position += move * Time.deltaTime;

        //check spaceship out of bounds
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -8.48f, 8.48f);
        transform.position = pos;
    }

    private void ChangeDirection()
    {
        direction = Random.Range(-1, 2);
    }
    #endregion

    private void Fire()
    {
        Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
    }
}
