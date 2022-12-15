using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    #region Public Variables
    public float speed;
    #endregion

    #region Private Variables
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Update()
    {
        //transform.position += Vector3.up * speed * Time.deltaTime;
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    #endregion
}
