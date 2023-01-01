using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    #region Public Variables
    #endregion

    #region Private Variables
    [SerializeField]
    private Animator anim;
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    private void Start()
    {
        StartCoroutine(DestroyThis());
    }

    private IEnumerator DestroyThis()
    {
        //Toole animation ro bar migardoone 
        yield return new WaitForSeconds(anim.GetCurrentAnimatorInfo(0).length);
        Destroy(gameObject);
    }

    private void Update()
    {

    }

    #endregion
}
