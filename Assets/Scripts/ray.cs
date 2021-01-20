using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray : MonoBehaviour
{ 
    [Range(0f,5f)]
    public float speed;
    public GameObject impact_partical;
   
    void FixedUpdate()
    {
        transform.Translate(0,0, speed);

    }
   
    private void OnCollisionEnter(Collision collision)
    {
        
        Instantiate(impact_partical, collision.contacts[0].point,Quaternion.identity);
        Destroy(this.gameObject, 0);
    }
}
