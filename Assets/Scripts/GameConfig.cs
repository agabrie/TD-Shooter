using System;
using UnityEngine;
public class ConfigFields:MonoBehaviour{
    
}
public class GameConfig : MonoBehaviour
{
    [SerializeField] public static bool gridMovement = false;
    [SerializeField] public static int mapsize = 3;
    public static Func<KeyCode, bool> movementType = Input.GetKey;

    public static void checkMovementType(){
        if(gridMovement){
            movementType = Input.GetKeyDown;
        }else{
            movementType = Input.GetKey;
        }
    }

    void toggleGridMovement(){
        if(Input.GetKeyDown(KeyCode.Tab)){
        // Debug.Log("Tab Pressed!");

            gridMovement = !gridMovement;
        }
    }
    void Update()
    {
        // toggleGridMovement();
    }
}