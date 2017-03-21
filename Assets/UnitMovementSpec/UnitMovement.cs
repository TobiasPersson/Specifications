using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //Using statment to aquire code for the use of a NavMeshAgent. -Tobias

public class UnitMovement : MonoBehaviour {

    Vector3 targetPosition; //Vector3 that will hold the position the unit will move towards. -Tobias
    NavMeshAgent agent; //Reference for the NavMeshAgent component attached to the object. -Tobias
    bool isActivated; //Bool to see if the unit is selected or not. -Tobias
    public Material activeMaterial; //Material for visual feedback when object is active. -Tobias
    Material deactiveMaterial; //Material for visual feedback when object is not active. -Tobias
    MeshRenderer mr; //Reference for MeshRenderer component attached to the object. -Tobias

	// Use this for initialization
	void Start () {
        mr = GetComponent<MeshRenderer>(); //Finds the attached MeshRenderer component. -Tobias
        deactiveMaterial = mr.material; //Sets the starting material to be the material used when the object is not active. -Tobias
        agent = GetComponent<NavMeshAgent>(); //Finds the attached NavMeshAgent component. -Tobias
        isActivated = false; //Starts the object as not active. -Tobias
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit; //Variable to save the info from the collision of the raycast. -Tobias
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //Creates a Ray variable from the camera to the mouse position. -Tobias

        if (Input.GetButtonDown("Fire1") && Physics.Raycast(ray,out hit) && hit.transform.tag == "Selectable") //If the left mouse button is clicked and a raycast hits something with the tag "Selectable". -Tobias
        {
                mr.material = activeMaterial; //Sets the material to the active material. -Tobias
                isActivated = true; //Sets the active bool to true. -Tobias
        }
        else if (Input.GetButtonDown("Fire1") && Physics.Raycast(ray, out hit) && hit.transform.tag != "Selectable") //If the left mouse button is clicked but the raycast hits something that is not tagged as "Selectable". Tobias
        {
            isActivated = false; //Sets the active bool to false. -Tobias
            mr.material = deactiveMaterial; //Sets the material back to the original material. -Tobias
        }

        if (Input.GetButtonDown("Fire2") && Physics.Raycast(ray,out hit) && isActivated) //if the right mouse button is clicked and the raycast hits something and the object is active. -Tobias
        {
            
            targetPosition = hit.point; //Sets the target position to the position at which the raycast hit a object. -Tobias
            agent.SetDestination(targetPosition); //Sets the NavMeshAgents destination to the target position. -Tobias

        }
	}
}
