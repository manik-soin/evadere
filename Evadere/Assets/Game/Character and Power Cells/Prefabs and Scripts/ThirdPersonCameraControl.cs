using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraControl : MonoBehaviour
{
    float rotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;

    public Transform Obstruction;
    float zoomSpeed = 2f;
    public new Material Transparent;
    
    void Start()
    {
        Obstruction = Target;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        CamControl();
        ViewObstructed();
    }
    

    void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -12, 20);

        transform.LookAt(Target);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }
    public GameObject objec;
    public Material oldMaterial;

    void ViewObstructed()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Target.position - transform.position, out hit, 64f))
        {

            if (hit.collider.gameObject.tag != "Alien" || hit.collider.gameObject.tag != "item")
            {
                if (objec != hit.collider.gameObject)
                {
                    if (objec != null)
                    {
                        objec.GetComponent<MeshRenderer>().material = oldMaterial;
                    }
                }
                if(hit.collider.gameObject.GetComponent<MeshRenderer>())
                {
                    hit.collider.gameObject.GetComponent<MeshRenderer>().material = Transparent;

                    objec = hit.collider.gameObject;
                    objec.GetComponent<MeshRenderer>().material = Transparent;
                }
            }
        }
        else
        {
            if (objec != null)
            {
                objec.GetComponent<MeshRenderer>().material = oldMaterial;//Reset targets material
                objec = null;//Clear reference
            }
        }
    }
}