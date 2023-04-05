using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] GameObject target;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float step = 5 * Time.deltaTime;
        this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position + offset,step);
    }
}
