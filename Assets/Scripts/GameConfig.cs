using System;
using UnityEngine;
public class ConfigFields:MonoBehaviour{
    
}
public class GameConfig : MonoBehaviour
{
    [SerializeField] public static bool gridMovement = false;
    [SerializeField] public static int mapsize = 4;
    [SerializeField] public static int enemyLevel = 1;

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
        if(Input.GetKeyDown(KeyCode.L)){
            enemyLevel++;
            // if(enemyLevel > 5){
                enemyLevel %= 6;
            // }
            Debug.Log(enemyLevel);
        }
        // toggleGridMovement();
    }
}