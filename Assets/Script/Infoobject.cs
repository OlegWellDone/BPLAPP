using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Infoobject : MonoBehaviour
{
    public GameObject infoObject;
    public GameObject infoRawImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        infoRawImage.SetActive(false);
    }
    public void showInfoObject()
    {
        infoRawImage.SetActive(!infoRawImage.activeSelf);
    }
    public void hideInfoObject()
    {
        infoRawImage.SetActive(false);
    }
    public void setInfoObject(GameObject newInfoObject)
    {
        infoObject.GetComponent<MeshFilter>().mesh = newInfoObject.GetComponent<MeshFilter>().mesh;
        //infoObject = Instantiate(newInfoObject, new Vector3(1000, 1000, 1000), Quaternion.identity);
        infoObject.transform.localScale = new Vector3(1000, 1000, 1000);
    }
}
