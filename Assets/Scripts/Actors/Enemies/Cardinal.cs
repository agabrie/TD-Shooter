using System.Collections.Generic;
using UnityEngine;

public class Cardinal:Enemy{
    void Start(){
        speed = 0.5f;
        state = State.None;
        List<State> states = getStateByLevel(GameConfig.enemyLevel);

        config = new ActorConfig(states, Directions.getCardinalDirections());
    }

    public void Update()
    {
        updateState();
        base.Update();
        // checkBeyondBoundary();
        // this.updateRotation();
    }

}