using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    #region Public Variables
    public float speed;
    public GameObject bulletPrefab;
    public GameObject gun;
    #endregion

    #region Private Variables
    private int _health
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.position += new Vector3(h, v, 0) * speed * Time.deltaTime;

        //check spaceship out of bounds
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -9.045f, 9.045f),
            Mathf.Clamp(transform.position.y, -4.21f, 3.23f),
            transform.position.z
        );


        //fire
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(bulletPrefab,gun.transform.position,Quaternion.identity);


    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("happend!");
    }
    #endregion
}
