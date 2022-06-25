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
    [SerializeField] private ObjectDisplay objectDisplay;
    private int id;

    private void OnEnable()
    {
        id = GetInstanceID();
        EventsHandler.Instance.OnActivatingObject += OnObjectActivated;
        objectDisplay.Init(id);
    }

    public void OnObjectActivated(int id)
    {
        lable.gameObject.SetActive(id == this.id);
        image.color = (id != this.id)? Color.black: Color.white;
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
