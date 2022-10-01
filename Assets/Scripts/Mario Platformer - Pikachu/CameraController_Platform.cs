// using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController_Platform : MonoBehaviour
{
    // [SyncVar]
    public Transform target;

    //[SyncVar]
    public Vector3 offset;

    //[SyncVar]
    public bool useOffsetValues;

    //[SyncVar]
    public float rotateSpeed;

    // [SyncVar]
    public Transform pivot;

    //[SyncVar]
    public float maxViewAngle;
   // [SyncVar]
    public float minViewAngle;

   // [SyncVar]
    public bool invertY;
    public Vector2 viewInput2 = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        if(!useOffsetValues)
        {
            offset = target.position - transform.position;
        }

        pivot.transform.position = target.transform.position;
        //pivot.transform.parent = target.transform;
        pivot.transform.parent = null;
    }


    // Update is called once per frame
    // [Client]
    void Update()
    {
       // if (!hasAuthority) { return; }

        pivot.transform.position = target.transform.position;
        //pivot.transform.parent = target.transform;
        pivot.transform.parent = null;

        //Get the X position of the mouse & rotate the target
        // float horizontal = Input.GetAxis("Mouse X Pika") * rotateSpeed;
        float horizontal = viewInput2.x * rotateSpeed;
        pivot.Rotate(0.0f, horizontal, 0.0f);

        //Get the Y position of the mouse and rotate the pivot
        // float vertical = Input.GetAxis("Mouse Y Pika") * rotateSpeed;
        float vertical = viewInput2.y * rotateSpeed;
        if (invertY)
        {
            pivot.Rotate(vertical, 0.0f, 0.0f);
        }
        else
        {
            pivot.Rotate(-vertical, 0.0f, 0.0f);

        }


        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180.0f)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, pivot.eulerAngles.y, 0.0f);
        }

        if (pivot.rotation.eulerAngles.x > 180.0f && pivot.rotation.eulerAngles.x < 360f + minViewAngle)
        {
            pivot.rotation = Quaternion.Euler(360.0f + minViewAngle, pivot.eulerAngles.y, 0.0f);
        }

        //Move the camera based on the current rotation of the target and the original offset
        float desiredYAngle = pivot.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
        transform.position = target.position - (rotation * offset);

        //  transform.position = target.position - offset;

        if (transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x, target.position.y - 0.5f, transform.position.z);
        }

        transform.LookAt(target);
    }

    // [Command]
    // void CmdLook()
    // {
    //     RpcLook();
    // }

    // // [ClientRpc]
    // void RpcLook()
    // {
    //     //if (!hasAuthority) { return; }

    //     pivot.transform.position = target.transform.position;

    //     //Get the X position of the mouse & rotate the target
    //     float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
    //     pivot.Rotate(0.0f, horizontal, 0.0f);

    //     //Get the Y position of the mouse and rotate the pivot
    //     float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
    //     //pivot.Rotate(-vertical, 0.0f, 0.0f);
    //     if (invertY)
    //     {
    //         pivot.Rotate(vertical, 0.0f, 0.0f);
    //     }
    //     else
    //     {
    //         pivot.Rotate(-vertical, 0.0f, 0.0f);

    //     }

    //     //Limit up/down camera rotation
    //     //if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
    //     //{
    //     //    pivot.rotation = Quaternion.Euler(maxViewAngle, 0f, 0f);
    //     //}

    //     //if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minViewAngle)
    //     //{
    //     //    pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0f, 0f);
    //     //}

    //     if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180.0f)
    //     {
    //         pivot.rotation = Quaternion.Euler(maxViewAngle, pivot.eulerAngles.y, 0.0f);
    //     }

    //     if (pivot.rotation.eulerAngles.x > 180.0f && pivot.rotation.eulerAngles.x < 360f + minViewAngle)
    //     {
    //         pivot.rotation = Quaternion.Euler(360.0f + minViewAngle, pivot.eulerAngles.y, 0.0f);
    //     }

    //     //Move the camera based on the current rotation of the target and the original offset
    //     float desiredYAngle = pivot.eulerAngles.y;
    //     float desiredXAngle = pivot.eulerAngles.x;

    //     Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);
    //     transform.position = target.position - (rotation * offset);

    //     //  transform.position = target.position - offset;

    //     if (transform.position.y < target.position.y)
    //     {
    //         transform.position = new Vector3(transform.position.x, target.position.y - 0.5f, transform.position.z);
    //     }

    //     transform.LookAt(target);
    // }
}
