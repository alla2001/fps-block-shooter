using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill : MonoBehaviour
{
    [Range(0f,10f)]
    public float wait_time;
    private void OnEnable()
    {
        Destroy(this.gameObject, wait_time);
    }


}
