using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_script : MonoBehaviour
{
    public weapon_scriptable_object fps;
    public bool firing;
    public bool aiming;
    public player_controler player;
    public Camera c;
    public GameObject shoot_muzl_vfx;
    [HideInInspector]
    public Vector3 hit_point;
    public GameObject target;
    public GameObject gun;
    public GameObject parent;
    public GameObject aimpoint;
    [HideInInspector]
    public bool hit;
    Vector3 pos;
    int x;
    [Range(0f,0.5f)]
    public float knockback_lerp;
    [Range(0f, 0.5f)]
    public float knockback_recovery;
    [Range(0f, 5f)]
    public float knockback_distance;
    [Range(0f, 0.25f)]
    public float knockback_recoil_randomnes;
    GameObject a;
    // Start is called before the first frame update
    void Start()
    {
        pos = parent.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        gun.transform.LookAt(target.transform.position, gun.transform.up);
        gun.transform.localRotation = Quaternion.Euler(gun.transform.localRotation.eulerAngles.x, gun.transform.localRotation.eulerAngles.y, 0);
        if (GetComponent<Animator>().GetBool("fire"))
        {
            GetComponent<Animator>().SetBool("fire", false);
        }
        if (firing)
        {
            this.GetComponent<shooting>().shoot(fps.hit_partical);
            x += 100;
            //this.GetComponent<Rigidbody>().AddForce(0,-10,0);

            if (hit == true)
            {

            }
            GetComponent<Animator>().SetBool("fire", true);

            shoot_muzl_vfx.SetActive(true);

            target.transform.Translate(Random.Range(-knockback_recoil_randomnes, knockback_recoil_randomnes), Random.Range(-knockback_recoil_randomnes, knockback_recoil_randomnes), 0);
            firing = false;
        }
        if (aiming)
        {
            print("aim");

            aimpoint.transform.position = c.transform.position;

        }

    }
    private void FixedUpdate()
    {
        if (x>0)
        {

            parent.transform.localPosition = Vector3.Lerp(parent.transform.localPosition, new Vector3(pos.x,pos.y,pos.z+ -knockback_distance), knockback_lerp);
            
            x -= 20;
        }else
        {
            parent.transform.localPosition = Vector3.Lerp(parent.transform.localPosition, pos, knockback_recovery);

        }
        if (x < 0)
        {
            x = 0;
        }
        
        //this.transform.localRotation = Quaternion.LookRotation(this.transform.position+new Vector3(10,10,10));

        //this.transform.localRotation = Quaternion.EulerAngles(0,Quaternion.Lerp(Quaternion.identity, Quaternion.LookRotation(new Vector3(this.transform.position.x, this.transform.position.y+10, this.transform.position.z+10)), player.delta.x).eulerAngles.y,0);
        //this.transform.rotation = Quaternion.EulerAngles(0, 0, Quaternion.Lerp(Quaternion.identity, Quaternion.LookRotation(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z)), player.delta.y).eulerAngles.z);

    }
}
