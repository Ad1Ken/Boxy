using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BoxyActivitySelectionView : BaseView
{
    #region PUBLIC_PROPERTIES
    public BoxyActivityItem activityItemPrefab;
    public GameObject content;
    #endregion

    #region PRIVATE_PROPERTIES
    [SerializeField] private Sprite[] activityFeatureImages;
    #endregion

    #region UNITY_CALLBACKS
    #endregion

    #region PUBLIC_METHODS
    public void Generate()
    {
        StartCoroutine(InstantiateActivities());
    }
    #endregion

    #region PRIVATE_METHODS
    #endregion

    #region DELEGTE_CALLBACKS
    #endregion

    #region Coroutines
    private IEnumerator InstantiateActivities()
    {
        int activityCount = BoxyManager.Instance.GetTotalNumberOfActivities();
        for (int i = 0; i < activityCount; i++)
        {
            BoxyActivityItem item = Instantiate(activityItemPrefab, content.transform);
            item.transform.localScale = Vector2.zero;
            item.GetComponent<RectTransform>().DOScale(1f, 0.2f);
            //Image temp = item.GetComponent<Image>();
            //temp.sprite = activityFeatureImages[i];
            item.activityIndex = i;
            item.SetLevelText();
            yield return new WaitForSeconds(0.5f);
        }
        BoxyUiManager.Instance.panelRulesView.ShowView();
    }
    #endregion
}
    