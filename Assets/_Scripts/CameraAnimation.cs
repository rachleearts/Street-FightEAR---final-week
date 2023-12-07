using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    public Animator cameraZoom;
    public float lerpValue;
    public bool doAnimation;

    public Transform head;

    void Update() 
    {
        if (!doAnimation) return;

        float yRot = head.eulerAngles.y;

        if (yRot < 0.01f) {
            cameraZoom.SetTrigger("EarZoomTrigger");
            //head rotates back to origin before animation to zoom is triggered
            doAnimation = false;
        } else {
            lerpValue += Time.deltaTime;
            head.eulerAngles = Vector3.Lerp(head.eulerAngles, Vector3.zero, lerpValue * .1f); 
        }

    }

    void OnMouseDown()
    {
        doAnimation = true;
        HeadRotation.zoomedIn = true; //select ear to trigger zoom animation
    }
}
