// using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKHandler : MonoBehaviour
{
    public Animator anim;
    // [SyncVar]
    StateManager states;

 //   [SyncVar]
    public float lookWeight = 1;
   // [SyncVar]
    public float bodyWeight = 0.8f;
   // [SyncVar]
    public float headWeight = 1;
   // [SyncVar]
    public float clampWeight = 1;

   // [SyncVar]
    float targetWeight;

   // [SyncVar] //KEEP OFF
    public Transform weaponHolder;
  //  [SyncVar]// KEEP OFF
    public Transform rightShoulder;

    // [SyncVar]
    public Transform overrideLookTarget; //this works - makes server stable (ONLY TRANSFORM THAT WORKS)


 //   [SyncVar] 
    public Transform rightHandIkTarget; //KEEP OFF
  //  [SyncVar]
    public float rightHandIkWeight;

   // [SyncVar]// KEEP OFF - ROTATES BODY
    public Transform leftHandIkTarget;
   //[SyncVar]
    public float leftHandIKweight; //spelt with captial K

    // [SyncVar]
    Transform aimHelper;


    //DUNO
    public FreeCameraLook camProperties;
    // [SyncVar]
    public Transform camPivot;
    // [SyncVar]
    public Transform camTrans;
    Vector3 lookPosition;

    void Start()
    {
        aimHelper = new GameObject().transform;

       // anim = GetComponent<Animator>();
        states = GetComponent<StateManager>();


        //DUNO
       // camProperties = FreeCameraLook.GetInstance();
      //  camPivot = camProperties.transform.GetChild(0);
       // camTrans = camPivot.GetChild(0);
    }
    

    // [Client]
    void FixedUpdate()
    {
        if (aimHelper == null)
        {
            aimHelper = new GameObject().transform;
        }
        //if (camPivot == null)
        //{
        //    //camPivot = camProperties.transform.GetChild(0);
        //}

        // if (!hasAuthority) { return; }

        if (rightShoulder == null) //IT DOESNT IN INSPECTOR
        {
            rightShoulder = anim.GetBoneTransform(HumanBodyBones.RightShoulder);
        }
        else
        {
            weaponHolder.position = rightShoulder.position;
        }

    //2
        if (states.aiming && !states.reloading)
        {
            Vector3 directionTowardsTarget = aimHelper.position - transform.position;
            float angle = Vector3.Angle(transform.forward, directionTowardsTarget);

            if (angle < 90)
            {
                targetWeight = 1;
            }
            else
            {
                targetWeight = 0;
            }
        }
        else
        {
            targetWeight = 0;
        }

        float multiplier = (states.aiming) ? 5 : 30;

        lookWeight = Mathf.Lerp(lookWeight, targetWeight, Time.deltaTime * multiplier);

        rightHandIkWeight = lookWeight;

        leftHandIKweight = 1 - anim.GetFloat("LeftHandIKWeightOverride");

        //CmdHandleShoulderRotation();

        aimHelper.position = Vector3.Lerp(aimHelper.position, states.lookPosition, Time.deltaTime * 5);
        weaponHolder.LookAt(aimHelper.position);
        rightHandIkTarget.parent.transform.LookAt(aimHelper.position);

    }

    void OnAnimatorIK()
    {
        //Ray ray = new Ray(camTrans.position, camTrans.forward);
        //lookPosition = ray.GetPoint(20);

        ////S if (!hasAuthority) { return; }
        //anim.SetLookAtWeight(lookWeight, bodyWeight, headWeight, headWeight, clampWeight);

        //Vector3 filterDirection = lookPosition; //I need states.lookPosition;
        ////filterDirecStion.y = offsetY; if needed
        //anim.SetLookAtPosition((overrideLookTarget != null) ? overrideLookTarget.position : filterDirection);

        //if (leftHandIkTarget)
        //{
        //    anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandIKweight);
        //    anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandIkTarget.position);
        //    anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandIKweight);
        //    anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHandIkTarget.rotation);
        //}

        //if (rightHandIkTarget)
        //{
        //    anim.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandIkWeight);
        //    anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandIkTarget.position);
        //    anim.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandIkWeight);
        //    anim.SetIKRotation(AvatarIKGoal.RightHand, rightHandIkTarget.rotation);
        //}


        //anim.SetLookAtWeight(lookWeight, bodyWeight, headWeight, headWeight, clampWeight);

        //Vector3 filterDirection = states.lookPosition;
        ////filterDirecStion.y = offsetY; if needed
        //anim.SetLookAtPosition((overrideLookTarget != null) ? overrideLookTarget.position : filterDirection);

        //if (leftHandIkTarget)
        //{
        //    anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandIKweight);
        //    anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandIkTarget.position);
        //    anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandIKweight);
        //    anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHandIkTarget.rotation);
        //}

        //if (rightHandIkTarget)
        //{
        //    anim.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandIkWeight);
        //    anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandIkTarget.position);
        //    anim.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandIkWeight);
        //    anim.SetIKRotation(AvatarIKGoal.RightHand, rightHandIkTarget.rotation);
        //}

        // if (!hasAuthority) { return; }
        anim.SetLookAtWeight(lookWeight, bodyWeight, headWeight, headWeight, clampWeight);

         Vector3 filterDirection2 = states.lookPosition;
        //filterDirecStion.y = offsetY; if needed
        anim.SetLookAtPosition((overrideLookTarget != null) ? overrideLookTarget.position : filterDirection2);

       if (leftHandIkTarget)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandIKweight);
            anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandIkTarget.position);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandIKweight);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHandIkTarget.rotation);
        }

        if (rightHandIkTarget)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandIkWeight);
            anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandIkTarget.position);
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandIkWeight);
            anim.SetIKRotation(AvatarIKGoal.RightHand, rightHandIkTarget.rotation);
        }

    }
}
