using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxyActivitySelectionManager : MonoBehaviour
{
    #region PUBLIC_PROPERTIES
    #endregion

    #region PRIVATE_PROPERTIES
    #endregion

    #region UNITY_CALLBACKS
    private void Start()
    {
        BoxyUiManager.Instance.sphinxActivitySelectionView.Generate();
    }
    #endregion

    #region PUBLIC_METHODS
    #endregion

    #region PRIVATE_METHODS
    #endregion

    #region DELEGTE_CALLBACKS
    #endregion
}
