using System.Collections.Generic;
using UnityEngine;

public class CrossCutter:Enemy{
    void Start(){
        speed = 0.5f;
        state = State.None;
        List<State> states = new List<State>{
            State.Move
        };
        config = new ActorConfig(states, Directions.getDiagonalDirections());

    }

    public void Update()
    {
        updateState();
        base.Update();
        // checkBeyondBoundary();
        // this.updateRotation();
    }

}