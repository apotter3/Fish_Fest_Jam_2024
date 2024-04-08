using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(GameObject))]

public class UI_Interaction : MonoBehaviour
{
    
    [field:SerializeField] private GameObject UI_Canvas { get; set; }
    public GraphicRaycaster UI_Raycaster { get; set; }

    PointerEventData click;
    List<RaycastResult> click_res;

    void Start()
    {
        UI_Raycaster = UI_Canvas.GetComponent<GraphicRaycaster> ();
        click = new PointerEventData (EventSystem.current);
        click_res = new List<RaycastResult> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.current.leftButton.wasReleasedThisFrame)
        {
            UIClicked();
        }
    }

    void UIClicked()
    {
        click.position = Mouse.current.position.ReadValue();
        click_res.Clear();

        UI_Raycaster.Raycast(click,click_res);
    }
}
