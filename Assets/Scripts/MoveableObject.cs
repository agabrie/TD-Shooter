using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class MoveableObject:MonoBehaviour{
    // GameObject gameObject; 
    [SerializeField] public Direction direction;
    [SerializeField] public float speed = 1f;
    public bool isBeyondBoundary = false;


    public MoveableObject(){
        // this.gameObject = go;
        this.direction = Direction.Up;
    }
    public MoveableObject( float speed){
        // this.gameObject = go;
        this.speed = speed;
        this.direction = Direction.Up;
    }
    public MoveableObject(float speed, Direction direction){
        // this.gameObject = go;
        this.speed = speed;
        this.direction = direction;
    }
    public Vector3 getDirection (){
        // try{

            // Debug.Log(direction);
            return Directions.get(direction);
        // }catch(Exception e){
            // return Vector3.zero;
        // }
    }
    public void setDirection(Direction direction){
        this.direction = direction;
        // Debug.Log(this.direction);

    }
    public void setSpeed(float speed){
        this.speed = speed;
    }
    public void updateRotation(){
        float step = 20f * speed * Time.deltaTime;
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), step);
        Vector3 dir = this.getDirection();
        if(dir != Vector3.zero){
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation,Quaternion.LookRotation(dir), step);
        }
    }
    public void updateRotation(float rotSpeed){
        float step = rotSpeed * Time.deltaTime;
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), step);
        gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation,Quaternion.LookRotation(this.getDirection()), step);
    }
    public bool checkBeyondBoundary(){
        float boundaryLimit = (GameConfig.mapsize*5)-0.5f;
        Vector3 inputVector = getDirection();
        isBeyondBoundary= ((this.transform.position + inputVector).x <= -boundaryLimit
            ||(this.transform.position + inputVector).x >= boundaryLimit
                ||(this.transform.position + inputVector).z <= -boundaryLimit
                    || (this.transform.position + inputVector).z >= boundaryLimit );
        return isBeyondBoundary;
    }
    public bool hasBreachedBoundary(){
        float boundaryLimit = (GameConfig.mapsize*5);
        // Vector3 inputVector = getDirection();
        bool hasBreachedBoundary= ((this.transform.position).x < -boundaryLimit
            ||(this.transform.position).x > boundaryLimit
                ||(this.transform.position).z < -boundaryLimit
                    || (this.transform.position).z > boundaryLimit );
        return hasBreachedBoundary;
    }
    public Direction getRandomDirection(){
        return Directions.getRandomDirection(direction);
    }
    public Direction getRandomDirection(List<Direction> selectableDirections){
        return Directions.getRandomDirection(selectableDirections,direction);
    }
    public void reflect(Vector3 normal){
        Vector3 newDir = Vector3.Reflect(getDirection(), normal);
        setDirection(Directions.getDirectionFromVector(newDir));
        // setDirection(getRandomDirection());
        // switch(direction){
        //     case Direction.Up:{
        //         setDirection(Direction.Down);
        //         break;
        //     }
        //     case Direction.Down:{
        //         setDirection(Direction.Up);
        //         break;
        //     }
        //     case Direction.Left:{
        //         setDirection(Direction.Right);
        //         break;
        //     }
        //     case Direction.Right:{
        //         setDirection(Direction.Left);
        //         break;
        //     }
        // }
    }
    public void moveObject(){
        float distance = speed;
        if(GameConfig.gridMovement){
            distance = speed;
        }else{
            distance = speed * 10 * Time.deltaTime;
        }
        Vector3 vDirection = getDirection();
        // Vector3 vDirection =gameObject.transform.rotation*Vector3.forward;
        gameObject.transform.position += vDirection * distance;
    }
    
    public void moveObject(Vector3 destination){
        // Debug.Log("destination =>"+destination);
        Vector3 dir = Directions.clampComponents(destination - this.transform.position); 
        // Debug.Log("direction to destination =>"+dir);
        float distance = speed * 10 * Time.deltaTime;

        setDirection(Directions.getDirectionFromVector(dir));
        gameObject.transform.position += dir * distance;

    }

    
}