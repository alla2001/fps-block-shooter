using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class wepon_manger : MonoBehaviour
{
   public gun_script current_gun;
    public InputAction shoot_bind;
    public InputAction aim_bind;
    public bool firing = false;
    public bool aiming = false;
    void Start()
    {
        shoot_bind.Enable();
        aim_bind.Enable();
    }


    void Update()
    {
        if (shoot_bind.ReadValue<float>() > 0)
        {

            Event fire1;

            if (firing == false)
            {
                StartCoroutine(Fire());
                firing = true;
            }

        }
        if (aim_bind.ReadValue<float>() > 0)
        { 
            current_gun.aiming = true;
            aiming = true;
        }
        else
        {
            current_gun.aiming = false;
            aiming = false;
        }
    }
    IEnumerator Fire()
    {
        shoot();
        yield return new WaitForSeconds(1/ current_gun.fps.fire_rate);
       
        firing = false;
    }

    public void shoot()
    {

        print("fire");
        RaycastHit hit;
        current_gun.firing = true;
        if (Physics.Raycast(transform.position,Vector3.forward,out hit))
        {
           
            
           

        }

    }
}
