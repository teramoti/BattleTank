using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.1f, 0, 0);
        if (transform.position.x < -15.0f)
        {
            transform.position = new Vector3(15.0f, 1, 105);
        }
    }
}
