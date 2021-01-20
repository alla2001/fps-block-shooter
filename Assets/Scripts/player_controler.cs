using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
public class player_controler : MonoBehaviour
{
    [Range(10f,200f)]
    public float Sensitivity;
    [Range(0f, 0.5f)]
    public float speed;
    [Range(0f, 0.5f)]
    public float speed_lerp=0.1f;
    public Camera cam;
    public float cam_hight;
    public InputAction look;
    public InputAction move;
    public InputAction shift;
    public Vector2 delta;
    public Vector2 force;
    
    float speed1;
    float s;
    Vector3 lastpos;
    Vector3 x = new Vector3(0, 0, 0);
    float i=0;



    void Start()
    {
        lastpos = this.transform.position;
        look.Enable();
        move.Enable();
        shift.Enable();
        cam.transform.localPosition=new Vector3(0,cam_hight,0);

    }

   
    void Update()
    {
        
        
        
        delta = look.ReadValue<Vector2>();
        force = move.ReadValue<Vector2>();
        
        if (cam.transform.eulerAngles.x <= 320 && cam.transform.eulerAngles.x > 100)
        {
            if (delta.y < 0)
            {
                cam.transform.Rotate(-delta.y * Sensitivity*Time.deltaTime, 0, 0);
            }
        }
        else if (cam.transform.eulerAngles.x < 40 || cam.transform.eulerAngles.x > 320)
        {
            cam.transform.Rotate(-delta.y * Sensitivity * Time.deltaTime, 0, 0);


        }
        else if (cam.transform.eulerAngles.x >= 40 && cam.transform.eulerAngles.x < 320)
        {
            if (delta.y > 0)
            {
                cam.transform.Rotate(-delta.y * Sensitivity * Time.deltaTime, 0, 0);
            }


        }
       
        transform.Rotate(0, delta.x * Sensitivity * Time.deltaTime, 0);
        cam.transform.rotation = Quaternion.Euler(cam.transform.eulerAngles.x, cam.transform.eulerAngles.y, 0);
    }
    private void FixedUpdate()
    {
        speed1 = Vector3.Magnitude(lastpos - this.transform.position)*4;
        lastpos = this.transform.position;
        this.transform.Translate(Vector3.Lerp(x, new Vector3( force.x*s, 0,force.y * s), speed_lerp));
        x = Vector3.Lerp(x, new Vector3(force.x * s, 0, force.y * s), speed_lerp);
        //this.GetComponent<Rigidbody>().AddRelativeForce(force.x * Mathf.Lerp(0, speed,0.8f)*100, 0, force.y * Mathf.Lerp(0, speed, 0.1f) * 100);

    }
}
