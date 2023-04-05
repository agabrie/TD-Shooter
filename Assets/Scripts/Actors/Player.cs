using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{  
    
    [SerializeField] Vector3 inputVector;
    [SerializeField] ActorConfig config;
    // Start is called before the first frame update
    void Start(){
        config = new ActorConfig();
    }

    void cardinalDirectionsController(){
        GameConfig.checkMovementType();
        
        float horizontalInput = 0f;
        float verticalInput = 0f;
        verticalInput = Convert.ToInt32(GameConfig.movementType(KeyCode.UpArrow))-Convert.ToInt32(GameConfig.movementType(KeyCode.DownArrow));
        horizontalInput = Convert.ToInt32(GameConfig.movementType(KeyCode.RightArrow))-Convert.ToInt32(GameConfig.movementType(KeyCode.LeftArrow));

        inputVector = new Vector3(horizontalInput,0, verticalInput);
        float step = 10 * Time.deltaTime;
        if(inputVector != Vector3.zero){
            this.setDirection(Directions.getDirectionFromVector(inputVector));
            MoveActor();
        }
    }
    public void Update()
    {
        if(shootUpdate < config.projectileReloadTime){
            shootUpdate +=Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.P)){
            moveObject(new Vector3(0,0.5f,0));
        }
            if(shootUpdate>=config.projectileReloadTime && Input.GetKeyDown(KeyCode.Space)){
                fireProjectile(this.direction, this.projectileMultiplier);
                shootUpdate = 0;
            }
            cardinalDirectionsController();
            base.Update();

        // checkBeyondBoundary();
        // this.updateRotation();
        // if(isPlayer){
        // }
    }
   

    void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
}
