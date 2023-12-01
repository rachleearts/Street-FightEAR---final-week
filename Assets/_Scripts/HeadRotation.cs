using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadRotation : MonoBehaviour
{
  private GameObject head;
    float yRotation;

    public static bool zoomedIn;
  
    private void OnMouseDrag()
    {
        if (zoomedIn) return;
        
        yRotation = Input.GetAxis("Mouse X");
        Debug.Log(yRotation);

        //this.transform.rotation = new Quaternion(this.transform.rotation.x ,this.transform.rotation.y + -yRotation * Time.deltaTime * 5f ,this.transform.rotation.z,1);
        transform.Rotate(0.0f,-yRotation *10.0f,0.0f);
    }
}
