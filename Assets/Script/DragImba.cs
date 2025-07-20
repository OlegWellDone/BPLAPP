using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DragMe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool dragOnSurfaces = true;

    private GameObject m_DraggingIcon;
    private RectTransform m_DraggingPlane;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Lol");
    }

    public void OnDrag(PointerEventData data)
    {
        Debug.Log("Lol");
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Lol");
    }
}