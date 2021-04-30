using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Animation>();
        if(Input.GetKeyDown(KeyCode.Alpha1))
            GetComponent<Animator>().Play("move");
    }
}
