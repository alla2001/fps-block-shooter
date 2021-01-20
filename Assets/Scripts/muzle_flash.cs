using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muzle_flash : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (this.gameObject.active == false)
        {
            this.transform.Rotate(0, 0, 10);
        }
    }
    private void OnEnable()
    {
        StartCoroutine( i());
    }
    IEnumerator i()
    {
        yield return new WaitForSeconds(0.05f);
        this.gameObject.SetActive(false);
    }
}
