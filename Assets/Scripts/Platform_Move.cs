using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Move : MonoBehaviour
{
    public float Patrol_speed;
    bool ismove_right;
    bool ismove_left;
    bool ismove_up;
    bool ismove_Down;

    void Update()
    {
        //For Rigth-Left Movement//
        if(ismove_right == true){
            transform.position = new Vector2(transform.position.x + Patrol_speed*Time.deltaTime,transform.position.y);
        }
        if(ismove_left == true){
            transform.position =  new Vector2(transform.position.x - Patrol_speed*Time.deltaTime,transform.position.y);
        }

        //For UP-Down Movement//
        if(ismove_up == true){
            transform.position = new Vector2(transform.position.x ,transform.position.y + Patrol_speed*Time.deltaTime);
        }
        if(ismove_Down == true){
            transform.position = new Vector2(transform.position.x ,transform.position.y - Patrol_speed*Time.deltaTime);
        }

       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "PatrolPoint_Left"){
            ismove_left = false;
            ismove_right = true;
        }
         if(other.gameObject.tag == "PatrolPoint_Right"){
            ismove_right = false;
            ismove_left = true;
        }
        if(other.gameObject.tag == "PatrolPoint_Up"){
            ismove_up = false;
            ismove_Down = true;
        }
         if(other.gameObject.tag == "PatrolPoint_Down"){
            ismove_Down = false;
            ismove_up = true;
        }
    }
}
