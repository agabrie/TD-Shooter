using System.Collections.Generic;
using UnityEngine;

public class Vert:Enemy{
    void Start(){
        speed = 0.5f;
        state = State.None;
        List<State> states = getStateByLevel(GameConfig.enemyLevel);

        List<Direction> directions = new List<Direction>{
            Direction.Up,
            Direction.Down
        };
        config = new ActorConfig(states, directions);
    }

    public void Update()
    {
        updateState();
        base.Update();
        // checkBeyondBoundary();
        // this.updateRotation();
    }

}