using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    Text tm;
    // Start is called before the first frame update
    void Start()
    {
        tm = GetComponent<Text>();
        Debug.Log(tm.text);
            tm.text = "Hi";
    }

    // Update is called once per frame
    void Update()
    {
    }
}
