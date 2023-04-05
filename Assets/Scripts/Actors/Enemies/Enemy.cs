using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{  
    ActorConfig enemyConfig;
    // Start is called before the first frame update
    void Start(){
        List<State> states = new List<State>{State.RandomShoot, State.Shoot, State.Chase};
        enemyConfig = new ActorConfig(states, Directions.getDiagonalDirections());
    }
    
    public void Update()
    {
        updateState();
        base.Update();
        // checkBeyondBoundary();
        // this.updateRotation();
    }
    void selectNewState(){
         this.setState(this.getRandomState(enemyConfig.validStates));
            // this.setDirection(this.getRandomDirection(enemyConfig.moveableDirections));
            // stateUpdate = 0;
            enemyConfig.resetStateUpdateLimit();
    }
    void updateState(){
        if(stateUpdate < enemyConfig.maxStateUpdateLimit){
            stateUpdate += Time.deltaTime;
        }
        if(shootUpdate < enemyConfig.projectileReloadTime){
            shootUpdate +=Time.deltaTime;
        }
        int boundaryLimit = (GameConfig.mapsize*5-1);
        if(isBeyondBoundary){
            this.setDirection(this.getRandomDirection(enemyConfig.moveableDirections));
            // MovePlayer();
            movementUpdate = 0;
            // stateUpdate = 0;
        }
        if(stateUpdate > enemyConfig.stateUpdateLimit){
            // this.setState(this.getRandomState());
            this.setDirection(this.getRandomDirection(enemyConfig.moveableDirections));
            selectNewState();
            stateUpdate = 0;
            // enemyConfig.resetStateUpdateLimit();
            // enemyConfig.setStateUpdateLimit( (int) UnityEngine.Random.Range(0,enemyConfig.maxStateUpdateLimit));
        }
        
        switch(state){
            case State.Move:
            {
            // this.setDirection(this.getRandomDirection(enemyConfig.moveableDirections));

                // if(!GameConfig.gridMovement){
                    MoveActor();
                    // movementUpdate = 0;
                // }else{
                    // movementUpdate += Time.deltaTime;
                    // if(movementUpdate > enemyConfig.movementUpdateLimit){
                        // MoveActor();
                        // movementUpdate = 0;
                    // }
                // }
                break;
            }
            case State.Shoot:
            {
                if(shootUpdate >= enemyConfig.projectileReloadTime){

                // if(!GameConfig.gridMovement){
                    // MoveActor();
                    fireProjectile(this.direction, this.projectileMultiplier);
                    shootUpdate = 0;
                    // stateUpdate = 0;
                    // enemyConfig.setStateUpdateLimit(0.1f);
                    // selectNewState();
                    setState(State.Move);
                }else{
                    moveObject();
                }

                    // movementUpdate = 0;
                // }else{
                    // movementUpdate += Time.deltaTime;
                    // if(movementUpdate > enemyConfig.movementUpdateLimit){
                        // MoveActor();
                        // movementUpdate = 0;
                    // }
                // }
                break;
            }
            case State.RandomShoot:
            {
               
                if(shootUpdate >= enemyConfig.projectileReloadTime){
                    this.setDirection(this.getRandomDirection(enemyConfig.moveableDirections));
                    shootUpdate = 0;
                // if(!GameConfig.gridMovement){
                    // MoveActor();
                    fireProjectile(this.direction, this.projectileMultiplier);
                    // stateUpdate = 0;
                    // enemyConfig.setStateUpdateLimit(0.5f);
                    // selectNewState();
                }
                    // movementUpdate = 0;
                // }else{
                    // movementUpdate += Time.deltaTime;
                    // if(movementUpdate > enemyConfig.movementUpdateLimit){
                        // MoveActor();
                        // movementUpdate = 0;
                    // }
                // }
                break;
            }
            case State.Chase:{
                Player p = (Player)FindObjectOfType<Player>();
                float distance = Vector3.Distance(p.transform.position,this.transform.position);
                Debug.Log("distance to player"+distance);
                if( distance<= 3f){
                    selectNewState();
                    stateUpdate = 0;
                }else{
                    this.moveObject(p.transform.position);
                }
                // enemyConfig.setStateUpdateLimit(2f);
                break;
            }
            default:{
                break;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        // if(!isPlayer){
            // this.setDirection(this.getRandomDirection(enemyConfig.moveableDirections));
            selectNewState();
            //Check for a match with the specified name on any GameObject that collides with your GameObject
           
        // }else{
        //     isBeyondBoundary = true;
        // }
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        // if (collision.gameObject.tag == "MyGameObjectTag")
        // {
        //     //If the GameObject has the same tag as specified, output this message in the console
        //     Debug.Log("Do something else here");
        // }
    }
}
