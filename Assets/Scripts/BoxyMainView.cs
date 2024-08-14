using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxyMainView : BaseView
{
    #region PUBLIC_PROPERTIES
    public List<BoxyLevelLayout> boxyLevels = new List<BoxyLevelLayout>();
    public BoxyCharacterMovement playerPrefab;
    public Transform turnButton;

    public BoxyCharacterMovement player;
    public BoxyRoomMovementNew prevRoom;
    #endregion

    #region PRIVATE_PROPERTIES
    private Transform startingPos;
    #endregion

    #region UNITY_CALLBACKS
    #endregion

    #region PUBLIC_METHODS
    public void Generate()
    {
        ResetUI();
        SetLayout();
        SetStartingPoint();
        EnableTurnButton();
    }
    public void OnClickTurn()
    {
        //player.rb.constraints = RigidbodyConstraints2D.None;
        player.rb.gravityScale = 10;
        boxyLevels[BoxyManager.Instance.currentLevel].gridLayout.transform.Rotate(0, 0, -90);
    }

    public void SetStartingPoint()
    {
        startingPos = boxyLevels[BoxyManager.Instance.currentLevel].startingPoint.transform;
        InstantiatePlayer(startingPos);
        //player.transform.SetParent(boxyLevels[BoxyManager.Instance.currentLevel].transform);
        //player.gameObject.transform.position = boxyLevels[BoxyManager.Instance.currentLevel].startingPoint.transform.position;
    }
    public void SetLayout()
    {
        HideAllLayouts();
        boxyLevels[BoxyManager.Instance.currentLevel].ShowView();
    }

    public void InstantiatePlayer(Transform position)
    {
        //startingPos = boxyLevels[BoxyManager.Instance.currentLevel].startingPoint.transform;
        player = Instantiate(playerPrefab);
        player.gameObject.transform.position = position.position;
    }
    
    public void SetStars()
    {
        HideAllStars();
        Debug.Log("Entered in SetStars");
        int currentLevel = BoxyManager.Instance.currentLevel;
        Debug.Log("currentLevel:  " + currentLevel);
        List<int> starIndex = BoxyManager.Instance.indexOfStars;
        Debug.Log("Entered in SetStars " + BoxyManager.Instance.indexOfStars.Count);

        for (int i = 0; i < starIndex.Count; i++)
        {
            Debug.Log("Value of i: " + i);
            Debug.Log("Entered in SetStars 2");
            Debug.Log("BoxyManager.Instance.indexOfStars: " + starIndex[i]);
            Debug.Log("BoxyManager.Instance.indexOfStars nos: " + boxyLevels[currentLevel].boxyMovementnew[starIndex[i]]);
            boxyLevels[currentLevel].boxyMovementnew[starIndex[i]].ShowStar();
        }
    }

    public void ResetUI()
    {
        if(player != null)
        {
            Destroy(player.gameObject);
        }
    }
    public void ResetInstantiate(Transform roomPos)
    {
        ResetUI();
        InstantiatePlayer(roomPos);
    }
    #endregion

    #region PRIVATE_METHODS
    public void EnableTurnButton()
    {
        if(BoxyManager.Instance.isRoomButton)
            turnButton.gameObject.SetActive(true);
        else
            turnButton.gameObject.SetActive(false);
    }
    private void HideAllStars()
    {
        int currentLevel = BoxyManager.Instance.currentLevel;
        for (int i = 0; i < boxyLevels[currentLevel].boxyMovementnew.Count; i++)
        {
            boxyLevels[currentLevel].boxyMovementnew[i].HideStar();
        }
    }
    public void HideAllLayouts()
    {
        for (int i = 0; i < boxyLevels.Count; i++)
        {
            boxyLevels[i].HideView();
        }
    }
    public void SetAllRoomsInitalTransform()
    {
        int currentLevel = BoxyManager.Instance.currentLevel;
        for (int i = 0; i < boxyLevels[currentLevel].boxyMovementnew.Count; i++)
        {
            boxyLevels[currentLevel].boxyMovementnew[i].SetPreviousTransform();
        }
    }
    #endregion

    #region DELEGTE_CALLBACKS
    #endregion

    #region Coroutines
    #endregion
}
