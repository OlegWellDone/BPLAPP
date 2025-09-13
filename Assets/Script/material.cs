using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class materialClassCool : MonoBehaviour
{

    private Material oldMaterial;

    void Start()
    {
        oldMaterial = gameObject.GetComponent<MeshRenderer>().material;
    }
    public void setCollor()
    {
        gameObject.GetComponent<MeshRenderer>().material = oldMaterial;
    }
}
