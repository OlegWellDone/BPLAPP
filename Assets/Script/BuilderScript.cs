using System.Collections.Generic;
using UnityEngine;

public class BuilderScript : MonoBehaviour
{
    [SerializeField] private GameObject BPLAModel;

    //private GameObject[] motor; //nu ty ponyal
    private GameObject[] propeller; //propeller
    private List<GameObject> krepezh = new List<GameObject>(); //krepezh
    private GameObject[] poletstack; //holder
    private GameObject[] core; //core
    private GameObject[] furniture; //base
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        foreach (Transform child in BPLAModel.GetComponentsInChildren<Transform>(true))
        {
            if (child.gameObject.CompareTag("Krepezh"))
            {
                krepezh.Add(child.gameObject);
            }
        }

        Debug.Log(krepezh.Capacity);
        //BPLAModel.GetComponentInChildren<GameObject>().CompareTag("Krepezh")
    }

    // Update is called once per frame
    void Update()
    {

    }
    

}
