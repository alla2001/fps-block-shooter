using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour ,gun_entity.gun_entity1
{
    public Camera c;
    [Range(0f,0.1f)]
    public float recoil_range;
    float x=0;
    Ray r;
    public void reload()
    {

        
    }
    private void FixedUpdate()
    {
        if (x > 0)
        {
            x -= 0.01f;
        }
        if (x<0)
        {
            x = 0;
        }
        
    }
    private void Update()
    {
        r = new Ray(c.transform.position, c.transform.forward+new Vector3(Random.Range(-recoil_range, recoil_range)*x, Random.Range(-recoil_range, recoil_range)*x, Random.Range(-recoil_range, recoil_range)*x));
    }
    public void shoot(GameObject partical)
    {
        RaycastHit hit;

        x += 0.25f;
        if (Physics.Raycast(r,out hit))
        {
            Instantiate(partical, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            print("hit");

        }
       

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(r);
    }

}