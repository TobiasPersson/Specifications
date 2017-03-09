using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider target)
    {
        print("Hit by sphere " + target.name); //If the attached object collides with a object it will print the message "Hit by sphere " and the name of the object it collides with. -Tobias
    }
}
