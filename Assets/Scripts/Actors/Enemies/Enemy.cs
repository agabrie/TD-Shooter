using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{  
    // Start is called before the first frame update
    void Start(){
        speed = 0.5f;
        state = State.None;
        List<State> states = getStateByLevel(spawner.enemyLevel);
        // List<State> states = new List<State>{State.Move};
        config = new ActorConfig(states, Directions.getAllDirections());
    }
    public List<State> getStateByLevel(int level){
        Debug.Log(level);
        switch(level){
            case 1:{
                return new List<State>{State.None,State.Move};
            }
            case 2:{
                return new List<State>{State.None,State.Move, State.Search};
            }
            case 3:{
                return new List<State>{State.None,State.Move, State.Search, State.Shoot};
            }
            case 4:{
                return new List<State>{State.None,State.Move, State.Search, State.Shoot, State.RandomShoot};
            }
            case 5:{
                return new List<State>{State.None,State.Move, State.Search, State.Shoot, State.RandomShoot, State.Chase};
            }
            default:{
                return new List<State>{State.None};
            }
        }
    }
    public void Update()
    {
        updateState();
        base.Update();
        // checkBeyondBoundary();
        // this.updateRotation();
    }

    public void configureStates(List<State> states){
        Debug.Log(states);
        config.validStates = states;
    }
    public void selectNewState(){
        animator.SetBool("isSearching", false);
        this.setState(this.getRandomState(config.validStates));
            // this.setDirection(this.getRandomDirection(enemyConfig.moveableDirections));
            // stateUpdate = 0;
        config.resetStateUpdateLimit();
    }
    public void updateState(){
        if(stateUpdate < config.maxStateUpdateLimit){
            stateUpdate += Time.deltaTime;
        }
        if(shootUpdate < config.projectileReloadTime){
            shootUpdate +=Time.deltaTime;
        }
        int boundaryLimit = (GameConfig.mapsize*5-1);
        if(isBeyondBoundary){
            this.setDirection(this.getRandomDirection(config.moveableDirections));
            // MovePlayer();
            movementUpdate = 0;
            // stateUpdate = 0;
        }
        if(stateUpdate > config.stateUpdateLimit){
            // this.setState(this.getRandomState());
            this.setDirection(this.getRandomDirection(config.moveableDirections));
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
                if(shootUpdate >= config.projectileReloadTime){

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
               
                if(shootUpdate >= config.projectileReloadTime){
                    this.setDirection(this.getRandomDirection(config.moveableDirections));
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
                // Debug.Log("distance to player"+distance);
                if( distance<= 3f){
                    selectNewState();
                    stateUpdate = 0;
                }else{
                    this.moveObject(p.transform.position);
                }
                // enemyConfig.setStateUpdateLimit(2f);
                break;
            }
            case State.Search:{
                // if(Input.GetKey(KeyCode.S)){
                    animator.SetBool("isSearching", true);
                // }
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
        if (collision.gameObject.layer == 6 /* Floor */)
        {
                //If the GameObject's name matches the one you suggest, output this message in the console
            // Debug.Log("Collided with floor");
            selectNewState();
        }
        // if(!isPlayer){
            // this.setDirection(this.getRandomDirection(enemyConfig.moveableDirections));
        if (collision.gameObject.layer == 8 /* Player */)
        {
            selectNewState();
            this.hp--;
        }
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
