using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] List<Enemy> prefabs;
    [SerializeField] List<Enemy> enemies = new List<Enemy>();
    [SerializeField] int numEnemies = 0;
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
        Enemy e = Instantiate(prefabs[(int)UnityEngine.Random.Range(0, prefabs.Count)], new Vector3(randX, transform.position.y, randZ), Quaternion.identity, this.transform);
        e.configureStates(new List<State>{State.Move, State.Search, State.Shoot});
        enemies.Add(e);
    }
    void Spawn(int numEnemies){
        for (int i = 0; i < numEnemies; i++)
        {
            Spawn();
                // cubes.Add(Instantiate(prefab, transform.position, Quaternion.identity));
        }
    }
    void KeyController(){
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
