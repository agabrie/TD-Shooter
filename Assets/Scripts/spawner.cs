using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] List<GameObject> cubes = new List<GameObject>();
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
        cubes.Add(Instantiate(prefab, new Vector3(randX, transform.position.y, randZ), Quaternion.identity, this.transform));
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
