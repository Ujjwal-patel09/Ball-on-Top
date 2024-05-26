using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{
    public Transform player;
    public float follow_speed;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        Vector3 target_pos =  new Vector3(player.position.x,player.position.y) + offset;   
        transform.position = Vector2.Lerp(transform.position,target_pos,follow_speed);
       // transform.position = new Vector3(Mathf.Clamp(transform.position.x,0,74.5f),Mathf.Clamp(transform.position.y,0,1.5f),offset.z);
        transform.position = new Vector3(transform.position.x,transform.position.y + offset.y,offset.z);
        
       
    }
}
