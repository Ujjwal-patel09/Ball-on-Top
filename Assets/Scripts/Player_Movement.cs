
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
  Rigidbody2D rb;
  Animator anim;
  public AudioSource jump_Sound;
  public AudioSource Finish_Sound;
  public AudioSource Background_Sound;
  
  public float Move_speed = 10f;
  Vector2 movement;

  public float jump_force;
  public bool isground;
  bool isjump;
   
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    anim.enabled = false;
  }
  
  void Update()
  {
    //  Getting Movement input //
    float horizontal = Input.GetAxis("Horizontal");
    movement = new Vector2(horizontal,0);
     // Stop ball from Goint Outside the Range//
    transform.position = new Vector2(Mathf.Clamp(transform.position.x,-39f,38f),transform.position.y);
        
    // Getting jump input //
    if(Input.GetKeyDown(KeyCode.Space) /*|| Input.GetKeyDown(KeyCode.Mouse0))*/ && isground == true){
      isjump = true;
    }
           
  }

  private void FixedUpdate() 
  {    
   // Movement Physics control//
    Movement();
   
    // jump physics //
    Jump();

  }
   
  private void OnCollisionEnter2D(Collision2D col)
  {
    // Restart Level when collide with spikes //
    if(col.gameObject.tag == "Obstacles"){
      SceneManager.LoadScene(1);
    }

    if(col.gameObject.CompareTag("cheat")){
      transform.position = new Vector3(3.5f,124.5f,transform.position.z);
    }
    
    // the end //
    if(col.gameObject.CompareTag("the_end")){
      SceneManager.LoadScene(3);
    }
  }

  private void OnCollisionStay2D(Collision2D other) 
  {
    // Checking on Ground //
    if(other.gameObject.tag == "Ground"){
      isground = true;
    }
  }
  
  private void OnCollisionExit2D(Collision2D other) 
  {
    // Checking off Ground // Used for Avoid Multiple Jumps//
    if(other.gameObject.tag == "Ground"){
      isground = false;
    }
  }

  void Movement()
  {
    //rb.velocity = new Vector2(movement.x*Move_speed*Time.deltaTime,rb.velocity.y);
    rb.AddForce( movement*Move_speed*Time.deltaTime);

  }

  void Jump()
  {
    Vector2 jump = new Vector2(rb.velocity.x,jump_force*Time.deltaTime);
    if(isjump == true){
      rb.velocity = jump;
      jump_Sound.Play();// Play Sound on jump//
    }
    isjump = false;
       
  }

 // Mobile controls //
  public void stop(){
    rb.AddForce(Vector2.zero);
  }

  public void right(){
    rb.AddForce( Vector2.right*Move_speed*Time.fixedDeltaTime);
  }
   
  public void left(){
    rb.AddForce( Vector2.left*Move_speed*Time.fixedDeltaTime);
  }
  
  public void jump1(){
    if(isground == true){
      isjump = true;
      Jump();
    }
  }
   
}
