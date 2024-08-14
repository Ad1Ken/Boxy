using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxyWinPanel : BaseView
{
    #region PUBLIC_PROPERTIES
    #endregion

    #region PRIVATE_PROPERTIES
    #endregion

    #region UNITY_CALLBACKS
    #endregion

    #region PUBLIC_METHODS
    public void OnClickHome()
    {
        BoxyUiManager.Instance.HideAllView();
        BoxyUiManager.Instance.sphinxActivitySelectionView.ShowView();
    }
    public void OnClickPlay()
    {
        BoxyUiManager.Instance.HideAllView();
        BoxyManager.Instance.Init(BoxyManager.Instance.currentLevel);
    }
    #endregion

    #region PRIVATE_METHODS
    #endregion

    #region DELEGTE_CALLBACKS
    #endregion
}
