using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapRenderer : MonoBehaviour
{
    [SerializeField] GameObject mapPrefab;
    [SerializeField] GameObject map;
    
    [SerializeField] BoxCollider floorCollider; 

    
    // MeshFilter mf = map.AddComponent(typeof(MeshFilter)) as MeshFilter;
    // MeshRenderer mr = map.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        map = Instantiate(mapPrefab, this.transform.position, Quaternion.identity);
        floorCollider.size = new Vector3(GameConfig.mapsize*10,0 , GameConfig.mapsize*10);
        map.transform.localScale = new Vector3(GameConfig.mapsize,1 , GameConfig.mapsize);   
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}