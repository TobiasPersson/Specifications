using UnityEngine;
using System.Collections;

public class RollingCube : MonoBehaviour
{

    enum Direction { right, left, forward, backward };
    enum RotDirection { right, left, forward, backward, none};
    RotDirection rotDirection = RotDirection.none;

    Transform parent;
    GameObject bottomEdge;
    BoxCollider boxCollider;

    int rotSpeed = 375;
    bool shouldRotate = false;

    void Start()
    {
        parent = transform.parent;
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (!shouldRotate)
        {
            rotDirection = RotDirection.none;
        }
        Vector3 position = transform.position;

        if (Input.GetButton("Horizontal") && shouldRotate == false)
        {

            if (bottomEdge == null)
            {
                bottomEdge = new GameObject("Edge");
            }

            if (Input.GetAxis("Horizontal") > 0)
            {
                bottomEdge.transform.position = new Vector3(position.x + boxCollider.bounds.extents.x, position.y - boxCollider.bounds.extents.y, position.z); // Set pivot point at the bottom right
                transform.parent = bottomEdge.transform;
                rotDirection = RotDirection.right;

            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                bottomEdge.transform.position = new Vector3(position.x - boxCollider.bounds.extents.x, position.y - boxCollider.bounds.extents.y, position.z); // Set pivot point at the bottom left
                transform.parent = bottomEdge.transform;
                rotDirection = RotDirection.left;
            }

        }
        else if (Input.GetButton("Vertical") && shouldRotate == false)
        {

            if (bottomEdge == null)
            {
                bottomEdge = new GameObject("Edge");
            }

            if (Input.GetAxis("Vertical") > 0)
            {
                bottomEdge.transform.position = new Vector3(position.x, position.y - boxCollider.bounds.extents.y, position.z + boxCollider.bounds.extents.z); // Set pivot point at the bottom front
                transform.parent = bottomEdge.transform;
                rotDirection = RotDirection.forward;

            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                bottomEdge.transform.position = new Vector3(position.x, position.y - boxCollider.bounds.extents.y, position.z - boxCollider.bounds.extents.z); // Set pivot point at the bottom back
                transform.parent = bottomEdge.transform;
                rotDirection = RotDirection.backward;
            }
        }

        switch (rotDirection)
        {
            case RotDirection.right:
                Rotate(Direction.right);
                break;
            case RotDirection.left:
                Rotate(Direction.left);
                break;
            case RotDirection.forward:
                Rotate(Direction.forward);
                break;
            case RotDirection.backward:
                Rotate(Direction.backward);
                break;
        }

        
    }

    void Rotate(Direction direction)
    {
        shouldRotate = true;

        switch (direction)
        {
            case Direction.right:
                bottomEdge.transform.Rotate(-Vector3.forward * Time.deltaTime * rotSpeed);
                if (Mathf.RoundToInt(bottomEdge.transform.localEulerAngles.z) <= 275)
                {
                    var angles = bottomEdge.transform.localEulerAngles;
                    angles.z = 270;
                    bottomEdge.transform.localEulerAngles = angles;
                    transform.parent = parent;
                    Destroy(bottomEdge);
                    rotDirection = RotDirection.none;
                    shouldRotate = false;
                }

                break;
            case Direction.left:
                bottomEdge.transform.Rotate(Vector3.forward * Time.deltaTime * rotSpeed);
                if (Mathf.RoundToInt(bottomEdge.transform.localEulerAngles.z) >= 85)
                {
                    var angles = bottomEdge.transform.localEulerAngles;
                    angles.z = 90;
                    bottomEdge.transform.localEulerAngles = angles;
                    transform.parent = parent;
                    Destroy(bottomEdge);
                    rotDirection = RotDirection.none;
                    shouldRotate = false;

                }

                break;
            case Direction.forward:
                bottomEdge.transform.Rotate(Vector3.right * Time.deltaTime * rotSpeed);
                if (Mathf.RoundToInt(bottomEdge.transform.localEulerAngles.x) >= 85)
                {
                    var angles = bottomEdge.transform.localEulerAngles;
                    angles.x = 90;
                    bottomEdge.transform.localEulerAngles = angles;
                    transform.parent = parent;
                    Destroy(bottomEdge);
                    rotDirection = RotDirection.none;
                    shouldRotate = false;

                }

                break;
            case Direction.backward:
                bottomEdge.transform.Rotate(-Vector3.right * Time.deltaTime * rotSpeed);
                if (Mathf.RoundToInt(bottomEdge.transform.localEulerAngles.x) <= 275)
                {
                    var angles = bottomEdge.transform.localEulerAngles;
                    angles.x = 270;
                    bottomEdge.transform.localEulerAngles = angles;
                    transform.parent = parent;
                    Destroy(bottomEdge);
                    rotDirection = RotDirection.none;
                    shouldRotate = false;
                }

                break;
        }
    }
}
