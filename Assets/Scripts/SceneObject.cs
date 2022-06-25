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
    [SerializeField] private ParticleSystem visualEffect; 

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

        if(id != this.id)
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            visualEffect.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
            visualEffect.Play();
        }
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
