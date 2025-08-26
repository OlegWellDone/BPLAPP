using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class DragImba : MonoBehaviour , IDragHandler, IEndDragHandler 
{
    public Transform mainObject;
    public TextMeshProUGUI testText;
    private float touchDistance = 0;
    private bool kostil = false;
    private float modScale = 0.2F;
    private Vector2 swipeDelta;
    public bool ScaleTrue;

    // Drag the selected item.
    public void OnDrag(PointerEventData eventData)
    {
        //по факту не очень нужен именно свитчь но похрен
        switch (Input.touchCount)
        {
            case 2:
                if (ScaleTrue)
                {
                float delthaTouchDistance = touchDistance - Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                testText.text = Input.GetTouch(0).position.ToString() + " " + Input.GetTouch(1).position.ToString();
                touchDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                if (kostil)
                {
                    //ограничения
                    if (mainObject.localScale.x+(delthaTouchDistance * modScale) >= 10F && mainObject.localScale.x+(delthaTouchDistance * modScale) <= 200F){
                        mainObject.localScale += new Vector3(delthaTouchDistance * modScale, delthaTouchDistance * modScale, delthaTouchDistance * modScale);
                    }
                }
                else
                {
                    kostil = true;
                }
                }
                break;
            default:
                mainObject.eulerAngles += new Vector3(eventData.delta.y / 2, -eventData.delta.x / 2);
                kostil = false;
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
    public void OnEndDrag(PointerEventData eventData) 
    {
        kostil = false;
        //Vector2 swipeDelta = endPosition - startPosition;
    }
}