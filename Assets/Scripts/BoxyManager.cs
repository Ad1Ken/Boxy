using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxyManager : MonoBehaviour
{
    public static BoxyManager Instance;
    #region PUBLIC_PROPERTIES
    public List<BoxyParameters> parameters = new List<BoxyParameters>();
    public List<int> indexOfStars;

    public int currentLevel;
    public int starCollected;
    public bool isRoomButton;
    #endregion

    #region PRIVATE_PROPERTIES
    #endregion

    #region UNITY_CALLBACKS
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    #region PUBLIC_METHODS
    public  void Init(int level)
    {
        ResetActivity();
        currentLevel = level;
        SetParameters(currentLevel);
        StartGame();
    }
    public  void StartGame()
    {
        //ResetActivity();
        //BoxyUiManager.Instance.HideAllView();
        BoxyUiManager.Instance.boxyMainView.ShowView();
        Generate();
    }
    public  void Generate()
    {
        BoxyUiManager.Instance.boxyMainView.Generate();
        BoxyUiManager.Instance.boxyMainView.SetStars();
    }


    public  void OnLevelComplete()
    {
        if(starCollected == indexOfStars.Count)
        {
            if (currentLevel > GetTotalNumberOfActivities() - 1)
                currentLevel = 0;
            currentLevel++;
            BoxyUiManager.Instance.panelWinView.ShowView();
        }
        else
        {
            BoxyUiManager.Instance.panelLoseView.ShowView();
            BoxyUiManager.Instance.boxyMainView.SetAllRoomsInitalTransform();
        }
    }

    public void ResetActivity()
    {
        starCollected = 0;
        indexOfStars.Clear();
    }

    //To check the correct answer
    public int GetTotalNumberOfActivities()
    {
        return parameters.Count;
    }
    #endregion

    #region PRIVATE_METHODS
    private void SetParameters(int currentLevel)
    {
        BoxyParameters boxyParameters = GetParameters(currentLevel);
        indexOfStars = boxyParameters.indexForStars;
        isRoomButton = boxyParameters.isRoomButton;
    }
    private BoxyParameters GetParameters(int index)
    {
        if (parameters != null && index < parameters.Count)
            return parameters[index];
        else
            return new BoxyParameters();
    }
    #endregion

    #region DELEGTE_CALLBACKS
    #endregion

    #region Coroutines
    #endregion
}
[System.Serializable]
public class BoxyParameters
{
    public List<int> indexForStars;
    public bool isRoomButton;
    public BoxyParameters()
    {
        indexForStars = new List<int> { 0 };
        isRoomButton = false;
    }
}