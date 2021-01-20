using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Mesh m;
    Vector3 fwd;
    void Start()
    {
        StartCoroutine(i());

    }

    Vector3 last_postion;
    private void FixedUpdate()
    {

        last_postion = this.transform.position;
        this.transform.Translate(0, 0, 1f);




    }
    public GameObject hit_effect;
    private void LateUpdate()
    {
        fwd = this.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(last_postion, fwd, out hit, Vector3.Distance(last_postion, this.transform.position)))
        {
            Instantiate(hit_effect,hit.point,Quaternion.FromToRotation(Vector3.forward, hit.normal));
            Destroy(this.gameObject);
        }
    }

    IEnumerator i()
    {
        
        
        yield return new WaitForSeconds(5);
        
        StartCoroutine(i());

    }
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {

        Gizmos.DrawRay(last_postion, fwd * Vector3.Distance(last_postion, this.transform.position));
        /*Gizmos.color = Color.green;
        
        Color translucentColor = Color.blue;
        
        Gizmos.DrawWireMesh(m, this.transform.position, Quaternion.identity, new Vector3(100, 100, 100));*/
    }
}
