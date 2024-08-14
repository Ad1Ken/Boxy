using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoxyRoomMovementNew : MonoBehaviour, IPointerClickHandler

{
    // Start is called before the first frame update
    public float doubleClickTime = 0.3f; // Time threshold for double click detection
    private float lastClickTime = 0f;
    private int clickCount = 0;

    public Transform keyItem;
    public Transform instantiatePoint;

    public Quaternion initialTransform;
    public Vector3 initialScale;

    public bool isEntered = false;

    void Start()
    {
        //if (uiButton == null)
        //{
        //    uiButton = GetComponent<Button>();
        //}
        initialTransform = transform.rotation;
        initialScale = transform.localScale;
        //Debug.Log("Previous Transform rotation: " + transform.rotation.z);
        Debug.Log("Previous Transform rotation: " + initialTransform.eulerAngles.z);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clickCount++;

        if (clickCount == 1)
        {
            lastClickTime = Time.time;
            Invoke("HandleSingleClick", doubleClickTime);
        }
        else if (clickCount > 1 && Time.time - lastClickTime < doubleClickTime)
        {
            CancelInvoke("HandleSingleClick");
            HandleDoubleClick();
            clickCount = 0;
        }
    }

    void HandleSingleClick()
    {
        if (clickCount == 1)
        {
            Debug.Log("Single Click");
            // Add your single click task here
            SingleClickTask();
        }
        clickCount = 0;
    }

    void HandleDoubleClick()
    {
        Debug.Log("Double Click");
        // Add your double click task here
        DoubleClickTask();
    }

    void SingleClickTask()
    {
        // Your single click task logic here
        Debug.Log("Single click task executed.");
        transform.Rotate(0, 0, -90);
        BoxyUiManager.Instance.boxyMainView.player.rb.gravityScale = 10;
        if (isEntered)
            BoxyUiManager.Instance.boxyMainView.ResetInstantiate(instantiatePoint);
    }

    void DoubleClickTask()
    {
        // Your double click task logic here
        //Debug.Log("Double click task executed.");
        //if (transform.localRotation.y == 0)
        //    transform.localRotation = Quaternion.Euler(0, 0, 180);
        //else
        //    transform.localRotation = Quaternion.Euler(0, 0, 0);

        Vector3 scale = transform.localScale;
        scale.x = -scale.x; // Flip the X scale
        transform.localScale = scale;
        BoxyUiManager.Instance.boxyMainView.player.rb.gravityScale = 10;
        if(isEntered)
            BoxyUiManager.Instance.boxyMainView.ResetInstantiate(instantiatePoint);
    }
    public void ShowStar()
    {
        keyItem.gameObject.SetActive(true);
    }
    public void HideStar()
    {
        keyItem.gameObject.SetActive(false);
    }

    public void SetPreviousTransform()
    {
        //initialTransform.rotation = Quaternion.Euler(0, 0, );
        transform.localScale = initialScale;
        transform.rotation = initialTransform;
        Debug.Log("Previous Transform rotation: " + transform.rotation);
    }
}
