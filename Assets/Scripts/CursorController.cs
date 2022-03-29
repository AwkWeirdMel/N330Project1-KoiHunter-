using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class CursorController : MonoBehaviour
{
    public Texture2D cursor;
    public Texture2D cursorClicked;

    private CursorControls controls;

    private Camera mainCamera;

    private void Awake()
    {
        controls = new CursorControls();
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
        mainCamera = Camera.main;
    }

    private void onEnable()
    {
        controls.Enable();
    }
    
    private void onDisable()
    {
        controls.Disable();
    }

    // Start is called before the first frame update
    private void Start()
    {
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();

    }

    private void StartedClick()
    {
        ChangeCursor(cursorClicked);
    }

    private void EndedClick()
    {
        ChangeCursor(cursor);
        DetectObject();
    }

    private void DetectObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                IClicked click = hit.collider.gameObject.GetComponent<IClicked>();
                if (click != null) click.onClickAction();
                Debug.Log("3D Hit: " + hit.collider.tag);
            }
        }
    }

    private void ChangeCursor(Texture2D cursorType)
    {
       // Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }

   
}
