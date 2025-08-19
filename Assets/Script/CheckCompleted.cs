using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckCompleted : MonoBehaviour
{

    [SerializeField] GameObject contentViewer;
    [SerializeField] TMP_Text button;

    [SerializeField] GameObject buttonOnScene;

    [SerializeField] GameObject buttonToNext;
    private List<Toggle> ToggleGroup = new List<Toggle>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FillForChecked()
    {
        
    }

    public void OnClickChecked()
    {

        foreach (RectTransform child in contentViewer.GetComponentsInChildren<RectTransform>(true))
        {
            if (child.name == "Checkbox(Clone)")
            {
                ToggleGroup.Add(child.GetComponent<Toggle>());
            }
            
        }
        //Debug.Log(ToggleGroup.Count);

        bool needOpenButton = true;
        for (int i = 0; i < ToggleGroup.Count; i++)
        {
            if (ToggleGroup[i].isOn == false)
            {
                needOpenButton = false;
            }
        }
        if (needOpenButton)
        {
            //button.enabled = true;
            buttonOnScene.SetActive(false);
            buttonToNext.SetActive(true);

        }
        else
        {
            //button.enabled = false;
            button.color = Color.red;
            button.text = "Проверьте все составляющие";
        }
    }
}
