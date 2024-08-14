using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxyUiManager : MonoBehaviour
{
    public static BoxyUiManager Instance;

    #region PUBLIC_PROPERTIES
    public BoxyMainView boxyMainView;
    public BoxyActivitySelectionView sphinxActivitySelectionView;
    public BoxyWinPanel panelWinView;
    public BoxyLosePanel panelLoseView;
    public BoxyRulesView panelRulesView;
    #endregion

    #region PRIVATE_PROPERTIES
    #endregion

    #region UNITY_CALLBACKS
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    #region PUBLIC_METHODS
    public void HideAllView()
    {
        boxyMainView.HideView();
        sphinxActivitySelectionView.HideView();
        panelWinView.HideView();
        panelLoseView.HideView();
        panelRulesView.HideView();
    }
    #endregion

    #region PRIVATE_METHODS
    #endregion

    #region DELEGTE_CALLBACKS
    #endregion

    #region Coroutines
    #endregion
}
