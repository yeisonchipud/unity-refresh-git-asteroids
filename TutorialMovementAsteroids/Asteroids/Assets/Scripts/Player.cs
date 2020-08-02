using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rg;
    private float vertical;
    private float horizontal;

    private bool shooting;

    public float acceleration;

    public float maxVelocity;

    public float angularSpeed;

    public float dashForce;

    public float drag;

    private bool turbing;

    public float cdValue;

    public float initialAcceleration;

    public float  initialMaxVelocity;
    // Start is called before the first frame update
    void Start()
    {
     rg = GetComponent<Rigidbody2D>();   
     rg.drag  = drag;

     initialAcceleration = acceleration;
    initialMaxVelocity = maxVelocity;
     
    }

    // Update is called once per frame
    void Update()
    {
        vertical = InputManager.vertical;
        horizontal  = InputManager.horizontal;
        shooting = InputManager.fire;
        
        Rotate();
        if(shooting && turbing == false){


            StartCoroutine(turboCD(cdValue));
            impulso();

            StartCoroutine(TurbingTimeAction());

        }
    }



    void FixedUpdate(){

        float forwardMotor = Mathf.Clamp( vertical,0,1);
   
        rg.AddForce(transform.up * forwardMotor * acceleration);

       
        if(rg.velocity.magnitude > maxVelocity){
            rg.velocity = rg.velocity.normalized * maxVelocity;
    
        }

       
    }

    void Rotate(){
        if(horizontal == 0){
        return;
        }
        transform.Rotate(0,0,-angularSpeed*horizontal*Time.deltaTime);


    }

    void impulso(){

  
        rg.AddForce(transform.up* dashForce);
        acceleration = initialAcceleration * 2f;

        maxVelocity = initialMaxVelocity *2f;
            
    }

    IEnumerator turboCD(float valor){
       
        yield return new WaitForSeconds(valor);


        turbing = false;

    }
    IEnumerator TurbingTimeAction(){
      yield return new WaitForSeconds(0.3f);
        acceleration = initialAcceleration;
        maxVelocity = initialMaxVelocity;
        turbing = true;

    }
}
