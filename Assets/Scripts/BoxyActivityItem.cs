using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoxyActivityItem : MonoBehaviour
{
    #region PUBLIC_PROPERTIES
    public int activityIndex;
    public TextMeshProUGUI levelText;
    #endregion

    #region PRIVATE_PROPERTIES
    #endregion

    #region UNITY_CALLBACKS
    #endregion

    #region PUBLIC_METHODS
    public void OnClickButton()
    {
        BoxyManager.Instance.Init(activityIndex);
    }
    public void SetLevelText()
    {
        levelText.text = (activityIndex + 1).ToString();
    }
    #endregion

    #region PRIVATE_METHODS
    #endregion

    #region DELEGTE_CALLBACKS
    #endregion

    #region Coroutines
    #endregion
}
