using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Example : MonoBehaviour , IDragHandler
{
    public Transform mainObject;

    // Drag the selected item.
    public void OnDrag(PointerEventData eventData)
    {
        mainObject.eulerAngles += new Vector3(eventData.delta.y, -eventData.delta.x);
    }
}