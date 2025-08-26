using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class DragImba : MonoBehaviour , IDragHandler
{
    public Transform mainObject;
    public TextMeshProUGUI testText;
    // Drag the selected item.
    public void OnDrag(PointerEventData eventData)
    {
        switch (Input.touchCount)
        {
            case 2:
                testText.text = Input.GetTouch(0).position.ToString() + " " + Input.GetTouch(1).position.ToString();
                break;
            default:
                mainObject.eulerAngles += new Vector3(eventData.delta.y / 2, -eventData.delta.x / 2);
                break;
        }
            
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Debug.Log(touch.position.ToString());
            }

            //testText.text = SystemInfo.deviceType.ToString();
            //mainObject.transform.rotation *=  Quaternion.Euler(-eventData.delta.y, eventData.delta.x, 0);
            //mainObject.transform.rotation = new  Vector3(mainObject.eulerAngles.x,-eventData.delta.y, 0);
            //mainObject.eulerAngles += new Vector3(eventData.delta.y / 2, -eventData.delta.x / 2);
            //Debug.Log(mainObject.eulerAngles );
        }
}