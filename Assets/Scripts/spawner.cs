using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] List<Enemy> prefabs;
    [SerializeField] List<Enemy> enemies = new List<Enemy>();
    [SerializeField] int numEnemies = 0;
    [SerializeField] public static int enemyLevel = 1;
    // public bool spaceKeyPressed = false;
    // public bool keyPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(this.transform.position);
        Spawn(numEnemies);
    }
    void Spawn(){
        int boundary = (GameConfig.mapsize*5)-2;
        int randX = (int)UnityEngine.Random.Range(-(boundary), boundary);
        int randZ = (int)UnityEngine.Random.Range(-(boundary), boundary);
        EnemyTypes type=  (EnemyTypes)UnityEngine.Random.Range(0, prefabs.Count);

        switch(type){
            case EnemyTypes.Hori:{
                Hori e = (Hori) Instantiate(prefabs[(int)type], new Vector3(randX, transform.position.y, randZ), Quaternion.identity, this.transform);
                e.configureStates(new List<State>{State.Move, State.Search, State.Shoot});
                break;
            }
            case EnemyTypes.Vert:{
                Vert e = (Vert) Instantiate(prefabs[(int)type], new Vector3(randX, transform.position.y, randZ), Quaternion.identity, this.transform);
                e.configureStates(new List<State>{State.Move, State.Search, State.Shoot});
                break;
            }
            case EnemyTypes.Cardinal:{
                Cardinal e = (Cardinal) Instantiate(prefabs[(int)type], new Vector3(randX, transform.position.y, randZ), Quaternion.identity, this.transform);
                e.configureStates(new List<State>{State.Move, State.Search, State.Shoot});
                break;
            }
            case EnemyTypes.CrossCutter:{
                CrossCutter e = (CrossCutter) Instantiate(prefabs[(int)type], new Vector3(randX, transform.position.y, randZ), Quaternion.identity, this.transform);
                e.configureStates(new List<State>{State.Move, State.Search, State.Shoot});
                break;
            }
            default:{
                Enemy e = (Enemy) Instantiate(prefabs[(int)type], new Vector3(randX, transform.position.y, randZ), Quaternion.identity, this.transform);
                e.configureStates(new List<State>{State.Move, State.Search, State.Shoot});
                break;
            }
        }
        // enemies.Add(e);
    }
    void Spawn(int numEnemies){
        for (int i = 0; i < numEnemies; i++)
        {
            Spawn();
                // cubes.Add(Instantiate(prefab, transform.position, Quaternion.identity));
        }
    }
    void KeyController(){
        if(Input.GetKeyDown(KeyCode.L)){
            enemyLevel++;
            Debug.Log(enemyLevel);
        }
        if(Input.GetKeyDown(KeyCode.K) /*&& !spaceKeyPressed*/){
            // spaceKeyPressed = true;
            // cubes.Add(
            //     );
                
                Spawn();
                
        }

        // else if(Input.GetKeyUp(KeyCode.Space)){
        //     spaceKeyPressed = false;
        // }
    }
    // Update is called once per frame
    void Update()
    {
        KeyController(); 
    }
}
