using System;
using System.Collections.Generic;
using UnityEngine;

public enum State{
    Move,
    Search,
    Shoot,
    RandomShoot,
    Chase,
    None
}

public class States{
    public static State getRandomState(){
        State state;
        // while(dir == direction){
            state = (State) UnityEngine.Random.Range(0,Enum.GetNames(typeof(State)).Length);
        // }
        return state;
    }
    public static State getRandomState(List<State> selectableStates){
        State state;
        // while(dir == direction){
            state = (State) selectableStates[UnityEngine.Random.Range(0,selectableStates.Count)];
        // }
        return state;
    }
}