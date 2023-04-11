using System;
using System.Collections.Generic;
using UnityEngine;
public enum Direction{
    Up=1,/*1*/
    Down=2,/*2*/
    Right=4,/*4*/
    Left=8,/*8*/
    /* Figure out how to add directions */
    UpRight = 5,/*5*/
    UpLeft=9,/*9*/
    DownRight=6,/*6*/
    DownLeft=10,/*10*/
    Zero=0/*0*/
}


public class Directions{
    public static  Vector3 Up = new Vector3(0,0,1);
     public static  Vector3 Down =   new Vector3(0,0,-1);
     public static  Vector3 Right =   new Vector3(1,0,0);
     public static Vector3 Left =   new Vector3(-1,0,0);

     public static  Vector3 UpRight =   new Vector3(1,0,1);
     public static  Vector3 UpLeft =   new Vector3(-1,0,1);
     public static  Vector3 DownRight =   new Vector3(1,0,-1);
     public static  Vector3 DownLeft =   new Vector3(-1,0,-1);
     

    public static  Vector3 Zero = new Vector3(0,0,0);

    public static  Vector3[] directions = new Vector3[]{
        Up,
        Down,
        Right,
        Left,
        
        UpRight,
        UpLeft,
        DownRight,
        DownLeft,
        Zero
    };
    public static Direction getRandomDirection(Direction direction){
        Direction dir = direction;
        while(dir == direction){
            Array values = Enum.GetValues(typeof(Direction));
            System.Random random = new System.Random();
            dir = (Direction)values.GetValue(random.Next(values.Length));
            // dir = (Direction) UnityEngine.Random.Range(0,directions.Length);
        }
        return dir;
    }
    public static Direction getRandomDirection(List<Direction> selectableDirections, Direction direction){
        Direction dir = direction;
        while(dir == direction){
            dir = (Direction) selectableDirections[UnityEngine.Random.Range(0,selectableDirections.Count)];
        }
        return dir;
    }

    public static Vector3 get(Direction dir){
        return directions[getVectorIndex(dir)];
    }
    public static Direction getDirectionFromVector(Vector3 vector){
       Direction d=getEnumIndex(Array.FindIndex(directions, direction=>isSameDirection(direction, vector)));
       return d;
    }
    public static int getVectorIndex(Direction dir){
        switch (dir){
            case Direction.Up:return 0;
            case Direction.Down:return 1;
            case Direction.Right:return 2;
            case Direction.Left:return 3;
            case Direction.UpRight:return 4;
            case Direction.UpLeft:return 5;
            case Direction.DownRight:return 6;
            case Direction.DownLeft:return 7;
            default: return 8;
        }
    }
    public static Direction getEnumIndex(int index){
        switch (index){
            case 0:return Direction.Up;
            case 1:return Direction.Down;
            case 2:return Direction.Right;
            case 3:return Direction.Left;
            case 4:return Direction.UpRight;
            case 5:return Direction.UpLeft;
            case 6:return Direction.DownRight;
            case 7:return Direction.DownLeft;
            default: return Direction.Zero;
        }
    }
    public static bool isSameDirection(Vector3 v1,Vector3 v2 ){
        v1.Normalize();
        v2.Normalize();
        float result = (float)Math.Round(Vector3.Dot(v1,v2), 2) ;
        // Debug.Log("v1["+v1+"] => v2["+v2+"] : "+result);
        return result == 1;
        // return true;
    }
    public static List<Direction> getCardinalDirections(){
        return new List<Direction>{
            Direction.Up,
            Direction.Down,
            Direction.Left,
            Direction.Right,
        };
    }
    public static List<Direction> getDiagonalDirections(){
        return new List<Direction>{
            Direction.UpRight,
            Direction.UpLeft,
            Direction.DownRight,
            Direction.DownLeft
        };
    }
    public static List<Direction> getAllDirections(){
        List<Direction> allDirections =  new List<Direction>();
        allDirections.AddRange(getCardinalDirections());
        allDirections.AddRange( getDiagonalDirections());
        return allDirections;
    }
    public static Vector3 clampComponents(Vector3 v){
        Vector3 vResult =new Vector3(
            (int) Math.Clamp(v.x, -1, 1),
            (int) Math.Clamp(v.y, -1, 1),
            (int) Math.Clamp(v.z, -1, 1)
        );
        return vResult;
    }

    public static Vector3 clampComponents(Vector3 v, Vector3 min, Vector3 max){
        Vector3 vResult = v;
        v.x = Mathf.Clamp(v.x, min.x, max.x);
        v.y = Mathf.Clamp(v.y, min.y, max.y);
        v.z = Mathf.Clamp(v.z, min.z, max.z);
        return vResult;
    }
    

}

