using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_rotation : MonoBehaviour
{
   
    void Start()
    {
        this.transform.Rotate(Random.Range(-100,100), Random.Range(-100, 100), Random.Range(-100, 100));
        
    }
    private void OnEnable()
    {
        this.transform.Rotate(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100));
    }
    private void Update()
    {
      

    }

}
