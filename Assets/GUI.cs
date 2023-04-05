using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI : MonoBehaviour
{
    TextMesh tm;
    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<TextMesh>();
        Debug.Log(tm.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
