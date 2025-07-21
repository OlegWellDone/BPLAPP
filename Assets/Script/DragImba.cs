using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Example : MonoBehaviour, IBeginDragHandler , IDragHandler, IEndDragHandler
{
    private Vector3 position;
    private float timeCount = 0.0f;
    public Transform mainObject;
    public void OnBeginDrag(PointerEventData eventData)
    {
        position = transform.position;
        Debug.Log("OnBeginDrag: " + position);
    }

    // Drag the selected item.
    public void OnDrag(PointerEventData eventData)
    {
        mainObject.eulerAngles += new Vector3(eventData.delta.y, eventData.delta.x);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = position;
        Debug.Log("OnEndDrag: " + position);
    }
}