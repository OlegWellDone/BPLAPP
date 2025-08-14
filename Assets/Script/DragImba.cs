using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Example : MonoBehaviour , IDragHandler
{
    public Transform mainObject;
    // Drag the selected item.
    public void OnDrag(PointerEventData eventData)
    {
        //mainObject.transform.rotation *=  Quaternion.Euler(-eventData.delta.y, eventData.delta.x, 0);
        //mainObject.transform.rotation = new  Vector3(mainObject.eulerAngles.x,-eventData.delta.y, 0);
        mainObject.eulerAngles += new Vector3(-eventData.delta.y, eventData.delta.x);
        //Debug.Log(mainObject.eulerAngles );
    }
}