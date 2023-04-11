using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ActorConfig{
    public bool canShoot=false;
    public List<Direction> moveableDirections = new List<Direction>();
    public List<State> validStates = new List<State>();
    
    [SerializeField] public float stateUpdateLimit = 5;

    public float maxStateUpdateLimit = 5;
    public float movementUpdateLimit = 0.2f;
    public float projectileReloadTime = 1f;
    public float shootAnimationTime = 0.4f;
    public float animationTime = 0f;

    public ActorConfig(){
        moveableDirections.AddRange(Directions.getAllDirections());
    }
    public ActorConfig(List<State> states){
        validStates.AddRange(states);
    }
    public ActorConfig(List<Direction> directions){
        moveableDirections.AddRange(directions);
    }
    public ActorConfig(List<State> states, List<Direction> directions){
        validStates.AddRange(states);
        moveableDirections.AddRange(directions);
    }
    public void setStateUpdateLimit(float limit){
        stateUpdateLimit = limit;
    }
    public void resetStateUpdateLimit(){
            this.setStateUpdateLimit( (int) UnityEngine.Random.Range(0,this.maxStateUpdateLimit));
    }
}