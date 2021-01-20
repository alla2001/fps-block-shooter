using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_mvmnt : MonoBehaviour
{
    [Range(0f,0.5f)]
    public float follow=0.01f;
    [Range(0f, 0.5f)]
    public float recovery = 0.05f;
    [Range(0f,5f)]
    public float distance = 2f;
    public player_controler player;
    Vector3 pos;
    private void Start()
    {
        pos = this.transform.localPosition;
    }
   
   
    void FixedUpdate()
    {
        if (player.delta != Vector2.zero)
        {
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(pos.x + distance  * Mathf.Clamp( player.delta.x,-2,2), pos.y + distance * Mathf.Clamp(player.delta.y, -2, 2) , this.transform.localPosition.z), follow );
            //this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, new Vector3(this.transform.localPosition.x, pos.y + 5 * Mathf.Sign(player.delta.y), this.transform.localPosition.z), follow);
        }
        else
        {
            this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, pos, recovery);
        }

    }
}
