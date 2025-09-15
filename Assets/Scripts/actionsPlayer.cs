using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionsPlayer : MonoBehaviour
{
    private int i;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            print(1);
        }
    }
}
