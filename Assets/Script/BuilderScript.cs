using System.Collections.Generic;
using UnityEngine;

public class BuilderScript : MonoBehaviour
{
    [SerializeField] private GameObject BPLAModel;

    [SerializeField] private Material NewMaterial;

    [SerializeField] private Material OldMaterial;
    //[SerializeField] string[] TagsInModel;//можем так задавать используемые тэги
    //private GameObject[] motor; //nu ty ponyal

    private List<GameObject> propeller = new List<GameObject>(); //propeller

    private List<GameObject> krepezh = new List<GameObject>(); //krepezh

    private List<GameObject> poletstack = new List<GameObject>(); //holder

    private List<GameObject> core = new List<GameObject>(); //core

    private List<GameObject> furniture = new List<GameObject>(); //base

    private int stage = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        foreach (Transform child in BPLAModel.GetComponentsInChildren<Transform>(true))
        {
            switch (child.gameObject.tag)
            {
                case "Krepezh":
                    {
                        krepezh.Add(child.gameObject);
                    }
                    break;
                case "Propeller":
                    {
                        propeller.Add(child.gameObject);
                    }
                    break;
                case "Holder":
                    {
                        poletstack.Add(child.gameObject);
                    }
                    break;
                case "Core":
                    {
                        core.Add(child.gameObject);
                    }
                    break;
                case "Base":
                    {
                        furniture.Add(child.gameObject);
                    }
                    break;
                default:
                    {
                    
                    } break;
            }
            child.gameObject.SetActive(false);
        }
        BPLAModel.SetActive(true);
        //BPLAModel.GetComponentInChildren<GameObject>().CompareTag("Krepezh")
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetOldModel(string previousTag)
    {
        foreach (Transform child in BPLAModel.GetComponentsInChildren<Transform>(true))
        {
            if (child.gameObject.tag == previousTag)
            {
            child.GetComponent<MeshRenderer>().material = OldMaterial;    
            }
        }
    }

    public void BuildBPLA()
    {
        switch (stage)
        {
            case 1:
                {
                    for (int i = 0; i < furniture.Count; i++)
                    {
                        furniture[i].SetActive(true);
                        furniture[i].GetComponent<MeshRenderer>().material = NewMaterial;
                    }
                }
                break;
            case 2:
                {
                    SetOldModel(furniture[0].tag);
                    for (int i = 0; i < core.Count; i++)
                    {
                        core[i].SetActive(true);
                        core[i].GetComponent<MeshRenderer>().material = NewMaterial;
                    }
                }
                break;
            case 3:
                {
                    SetOldModel(core[0].tag);
                    for (int i = 0; i < poletstack.Count; i++)
                    {
                        poletstack[i].SetActive(true);
                        poletstack[i].GetComponent<MeshRenderer>().material = NewMaterial;
                    }
                }
                break;
            case 4:
                {
                    SetOldModel(poletstack[0].tag);
                    for (int i = 0; i < krepezh.Count; i++)
                    {
                        krepezh[i].SetActive(true);
                        krepezh[i].GetComponent<MeshRenderer>().material = NewMaterial;
                    }
                }
                break;
            case 5:
                {
                    SetOldModel(krepezh[0].tag);
                    for (int i = 0; i < propeller.Count; i++)
                    {
                        propeller[i].SetActive(true);
                        propeller[i].GetComponent<MeshRenderer>().material = NewMaterial;
                    }
                }
                break;
            case 6:
                {
                    SetOldModel(propeller[0].tag);
                }
                break;
        }
        stage++;
    }
}
