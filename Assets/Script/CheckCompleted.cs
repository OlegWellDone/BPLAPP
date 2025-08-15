using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class CheckCompleted : MonoBehaviour
{

    [SerializeField] GameObject contentViewer;
    [SerializeField] Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform child in contentViewer.GetComponentsInChildren<Transform>(true))
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
