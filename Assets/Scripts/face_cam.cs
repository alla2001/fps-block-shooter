using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class face_cam : MonoBehaviour
{
   
    void Update()
    {
        this.transform.LookAt(Camera.main.transform.position);
    }
}
