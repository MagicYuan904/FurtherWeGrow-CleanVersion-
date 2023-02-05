using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when press button "s", trigger the animation "handUp" of the hand

    private void OnMouseDown()
    {
        Debug.Log("click");
        GetComponent<Animator>().SetTrigger("handUp");
        Invoke("handDown", 2.0f);
    }

    void handDown()
    {
        GetComponent<Animator>().SetTrigger("handDown");
    }
}
