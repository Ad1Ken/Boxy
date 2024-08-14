using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoxyRoomMovement : MonoBehaviour, IPointerDownHandler
{
    #region PUBLIC_PROPERTIES
    float clicked = 0;
    float clicktime = 0;
    float clickdelay = 0.5f;
    #endregion

    #region PRIVATE_PROPERTIES
    bool clickedTwice = false;
    bool isButton = false;
    #endregion

    #region UNITY_CALLBACKS
    private void Update()
    {
        //if (Input.GetKeyDown("q")){
        //    transform.Rotate(0, 0, -90);
        //}
        //if (Input.GetKeyDown("w"))
        //{
        //    if(transform.localRotation.y == 0)
        //        transform.localRotation = Quaternion.Euler(0, 180, 0);
        //    else
        //        transform.localRotation = Quaternion.Euler(0, 0, 0);
        //}
    }
    #endregion

    #region PUBLIC_METHODS
    public void OnCLickButtonDouble()
    {
        if (transform.localRotation.y == 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        else
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        clickedTwice = false;
    }
    public void OnCLickButton()
    {
        if (clickedTwice)
            OnCLickButtonDouble();
        else
            transform.Rotate(0, 0, -90);
    }

    //public virtual void OnPointerClick(PointerEventData eventData)
    //{
    //    if (eventData.clickCount == 2)
    //    {
    //        Debug.Log("ClickedTwice");
    //        clickedTwice = true;
    //    }
    //}
    public void OnPointerDown(PointerEventData data)
    {
        clicked++;
        if (clicked == 1) clicktime = Time.time;

        if (clicked > 1 && Time.time - clicktime < clickdelay)
        {
            clicked = 0;
            clicktime = 0;
            Debug.Log("Double CLick: " + this.GetComponent<RectTransform>().name);

        }
        else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;
    }

    public void ResetOnClick()
    {
        isButton = false;
    }

    #endregion

    #region PRIVATE_METHODS
    #endregion

    #region DELEGTE_CALLBACKS
    #endregion

    #region Coroutines
    #endregion
}
