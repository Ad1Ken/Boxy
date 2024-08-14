using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxyLevelLayout : BaseView
{
    #region PUBLIC_PROPERTIES
    public List<BoxyRoomMovementNew> boxyMovementnew = new List<BoxyRoomMovementNew>();
    public Transform startingPoint;
    public Transform gridLayout;
    #endregion

    #region PRIVATE_PROPERTIES
    #endregion

    #region UNITY_CALLBACKS
    #endregion

    #region PUBLIC_METHODS
    public void OnClickTurn()
    {
        transform.Rotate(0, 0, -90);
    }

    #endregion

    #region PRIVATE_METHODS
    #endregion
                

    #region DELEGTE_CALLBACKS
    #endregion

    #region Coroutines
    #endregion
}
