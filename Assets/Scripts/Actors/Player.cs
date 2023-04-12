using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{  
    
    [SerializeField] Vector3 inputVector;
    // Start is called before the first frame update
    public void Start(){
        base.Start();
        config = new ActorConfig();
    }

    void cardinalDirectionsController(){
        GameConfig.checkMovementType();
        
        float horizontalInput = 0f;
        float verticalInput = 0f;
        verticalInput = Convert.ToInt32(Input.GetAxis("Vertical"));
        horizontalInput = Convert.ToInt32(Input.GetAxis("Horizontal"));
        // verticalInput = Convert.ToInt32(GameConfig.movementType(KeyCode.UpArrow))-Convert.ToInt32(GameConfig.movementType(KeyCode.DownArrow));
        // horizontalInput = Convert.ToInt32(GameConfig.movementType(KeyCode.RightArrow))-Convert.ToInt32(GameConfig.movementType(KeyCode.LeftArrow));

        inputVector = new Vector3(horizontalInput,0, verticalInput);
        // float step = 10 * Time.deltaTime;
        if(inputVector != Vector3.zero){
            this.setDirection(Directions.getDirectionFromVector(inputVector));
            if(state != State.Move){
                setState(State.Move);
            }
            MoveActor();
        }else{
            if(state != State.None){
                setState(State.None);
            }
            // animator.SetBool("isWalking", false);
        }
    }
    public void Update()
    {
        if(shootUpdate < config.projectileReloadTime){
            shootUpdate +=Time.deltaTime;
        }
        // if(Input.GetKey(KeyCode.S)){
        //     animator.SetBool("isSearching", true);
        // }else{
        //     animator.SetBool("isSearching", false);
        // }

        if(Input.GetKeyDown(KeyCode.P)){
            moveObject(new Vector3(0,0.5f,0));
        }
            if(shootUpdate>=config.projectileReloadTime && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))){
                fireProjectile(this.direction, this.projectileMultiplier);
                shootUpdate = 0;
            }
            cardinalDirectionsController();
            base.Update();
        /*
            Button0 => Square
        */
    }
   

    void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
}
