using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    #region Public Variables
    public float speed;
    public GameObject bulletPrefab;
    public GameObject[] guns;
    public int Health { get { return _health; } }
    public float fireRate;
    public Animator flameAnimator;
    #endregion

    #region Private Variables
    [SerializeField]
    private int _health;
    private float lastShot = 0;
    private const string FLAME_ANIMATOR = "speed"; 
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
        Vector3 move = new Vector3(h, v, 0) * speed * Time.deltaTime;
        transform.position += move;

        flameAnimator.SetFloat(FLAME_ANIMATOR, move.sqrMagnitude);

        //check spaceship out of bounds
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -9.045f, 9.045f),
            Mathf.Clamp(transform.position.y, -4.21f, 3.23f),
            transform.position.z
        );


        //fire
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
            

    }

    private void Fire()
    {
        //meghdar zamani k az bazi gozashte  
        if (Time.time > fireRate + lastShot)
        {
            for (int i = 0; i < guns.Length; i++)
            {
                Instantiate(bulletPrefab, guns[i].transform.position, Quaternion.identity);
            }

            //zamane shelike akharin tir
            lastShot = Time.time;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bullet_enemy")
        {
            _health -= col.gameObject.GetComponent<BulletController>().power;
            CheckHealth();
        }

        else if (col.gameObject.tag == "asteroid")
        {
            _health -= col.gameObject.GetComponent<AsteroidController>().health;
            CheckHealth(); 
        }

        else if (col.gameObject.tag == "ship_enemy")
        {
            _health -= col.gameObject.GetComponent<EnemyShipController>().power;
            CheckHealth();
        }
    }

    private void CheckHealth()
    {
        if (_health <= 0)
        {
            //TODO : 
            Destroy(gameObject);
        }
    }
    #endregion
}
 