using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Camera camera;

    private Transform SelectedBase;
    private Transform HoverBase;
    private Transform NextBase;
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CheckMouseInput(SelectBeh);
        } 
        else if(Input.GetMouseButton(0))
        {
            CheckMouseInput(HoverBeh);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            CheckMouseInput(ReleaseBeh);
        }
    }

    private void SelectBeh(Transform obj){
        SelectedBase = obj;
        new Vector3(1.1f, 1.1f, 1f);
    }

    private void HoverBeh(Transform obj){
        if(HoverBase == null) HoverBase = obj;
        
        if(HoverBase != obj)
        {
            HoverBase.localScale = new Vector3(1f, 1f, 1f);
            HoverBase = obj;
        }

        obj.localScale = new Vector3(0.9f, 0.9f, 1f);
    }

    private void ReleaseBeh(Transform obj){
        var SelectedBasePos = SelectedBase.position;
        SelectedBase.position = obj.position;
        obj.position = SelectedBasePos;
        
        SelectedBase.localScale = new Vector3(1f, 1f, 1f);
        obj.localScale = new Vector3(1f, 1f, 1f);
    }

    private void CheckMouseInput(Action<Transform> behavior)
    {
         RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit)) {
            Transform objectHit = hit.transform;
            
            // Do something with the object that was hit by the raycast.
            behavior(objectHit);
        }
    }
}
