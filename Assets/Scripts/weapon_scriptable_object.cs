using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/weapon_scriptable_object", order = 1)]
public class weapon_scriptable_object : ScriptableObject
{
    public GameObject gun;
    public GameObject hit_partical;
    public GameObject shoot_partical;
    public GameObject musole;
    public Animator animator;
    public int max_ammo;
    public float fire_rate;
    
}
