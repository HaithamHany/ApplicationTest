using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SceneObject : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI lable;
    [SerializeField] private RawImage image;

    private void OnEnable()
    {
        EventsHandler.Instance.OnActivatingObject += OnObjectActivated;
    }
    public void OnObjectActivated(int id)
    {
        lable.gameObject.SetActive(id == this.GetInstanceID());
        image.color = (id != this.GetInstanceID())? Color.black: Color.white;
    }

    public void OnObjectDeactivated()
    {
        lable.gameObject.SetActive(false);
        image.color = Color.black;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        EventsHandler.Instance.ActivatingObject(GetInstanceID());
    }

    private void OnDestroy()
    {
        EventsHandler.Instance.OnActivatingObject -= OnObjectActivated;
    }
}
