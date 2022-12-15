using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    #region Public Variables
    public float speed;
    Transform myTransform;
    #endregion

    #region Private Variables
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = myTransform.position.x;
        Debug.Log(x);
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        myTransform.position += new Vector3(h, v, 0) * speed * Time.deltaTime;

        myTransform.position = new Vector3(
            Mathf.Clamp(myTransform.position.x, -9.045f, 9.045f),
            Mathf.Clamp(myTransform.position.y, -4.21f, 3.23f),
            myTransform.position.z
    );

    }
    #endregion
}
