using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class gun_entity : MonoBehaviour
{


    public interface gun_entity1 
    {
        void shoot(GameObject p);
        void reload();
    }
}
