using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    #region Public Variables
    public float speed;
    public float rotationSpeed;
    public int health;
    public GameObject explosionPrefab;
    #endregion

    #region Private Variables
    private const string ANIMATION_NAME = "health";
    private Animator anim; 
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, 1) * rotationSpeed * Time.deltaTime);

        anim.SetInteger(ANIMATION_NAME, health);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        health = health - col.gameObject.GetComponent<BulletController>().power;
        CheckHealth();
    }
     
    private void CheckHealth()
    {
        if (health <= 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity); 
            Destroy(gameObject);
        }
        
    }
    #endregion
}
