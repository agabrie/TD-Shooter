using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] GameObject wallPrefab;
    [SerializeField] List<GameObject> walls= new List<GameObject>();
    Vector3[] boundaryPositions = new Vector3[]{
        new Vector3(0,0,1),
        new Vector3(1,0,0),
        new Vector3(0,0,-1),
        new Vector3(-1,0,0),
    };
    // Start is called before the first frame update
    void Start()
    {
       for (int i = 0; i < 4; i++)
        {
            GameObject wall = Instantiate(wallPrefab, this.transform.position+boundaryPositions[i]*GameConfig.mapsize*5, Quaternion.identity, this.transform);
            wall.transform.localScale = new Vector3(GameConfig.mapsize*10-1,2 ,1);
            wall.transform.rotation = Quaternion.LookRotation(boundaryPositions[i]);
            walls.Add(wall);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
