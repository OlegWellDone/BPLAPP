using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class BuilderScript : MonoBehaviour
{

    private Dictionary<int, List<GameObject>> stagesOfBuild = new Dictionary<int, List<GameObject>>();
    [SerializeField] private GameObject meObject;
    [SerializeField] private GameObject BPLAModel;
    [SerializeField] private Material NewMaterial;
    [SerializeField] private Material OldMaterial;
    [SerializeField] private TextMeshProUGUI textObject;

    //[SerializeField] string[] TagsInModel;//можем так задавать используемые тэги
    private Infoobject InfoScript;

    private int stage = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<string> AllTags = new List<string>();
        foreach (Transform child in BPLAModel.GetComponentsInChildren<Transform>(true))
        {
            if (child.gameObject.tag == "Base")
            {
                continue;
            }
            AllTags.Add(child.gameObject.name);
        }
        //просто вычитываем уникальные тэги
        HashSet<string> uniqueTags = new HashSet<string>(AllTags);
        AllTags.Clear();
        AllTags = uniqueTags.ToList();

        //заполняем модели в мапу
        for (int i = 0; i < AllTags.Count; i++)
        {
            List<GameObject> Temp = new List<GameObject>();
            foreach (Transform child in BPLAModel.GetComponentsInChildren<Transform>(true))
            {
                if (child.gameObject.name == AllTags[i])
                {
                    Temp.Add(child.gameObject);
                    child.gameObject.SetActive(false);
                }
            }
            stagesOfBuild.Add(i + 1, new List<GameObject>(Temp));
            Temp.Clear();
        }
        BPLAModel.SetActive(true);
        Debug.Log(stagesOfBuild.Count);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetOldModel(int oldStage)
    {
        //Debug.Log("А мы ставим материал для прошлой детали");
        for (int i = 0; i < stagesOfBuild[oldStage].Count; i++)
        {
            stagesOfBuild[oldStage][i].GetComponent<MeshRenderer>().material = OldMaterial;
        }
    }


    private void DeactivateButton()
    {
        gameObject.SetActive(false);
    }
    public void BuildBPLA(bool next)
    {
        if (next && stage <= stagesOfBuild.Count)
        {
            //типо делаем следующий шаг
            for (int i = 0; i < stagesOfBuild[stage].Count; i++)
            {
                stagesOfBuild[stage][i].SetActive(true);
                //stagesOfBuild[stage][i].GetComponent<MeshRenderer>().material = NewMaterial;
                textObject.text = stagesOfBuild[stage][i].name;
                //Артём нахуевертил тута
                //meObject.GetComponent<Infoobject>().setInfoObject(stagesOfBuild[stage][i]);
            }
            if (stage > 1)
            {
                SetOldModel(stage - 1);
            }
            stage++;
        }
        else if ((next == false) && (stage > 2))
        {
            //очевидно делаем предыдущий шаг
            for (int i = 0; i < stagesOfBuild[stage - 1].Count; i++)
            {
                stagesOfBuild[stage - 1][i].SetActive(false);
            }
            for (int i = 0; i < stagesOfBuild[stage - 2].Count; i++)
            {
                //stagesOfBuild[stage - 2][i].GetComponent<MeshRenderer>().material = NewMaterial;
                textObject.text = stagesOfBuild[stage- 2][i].name;
                meObject.GetComponent<Infoobject>().setInfoObject(stagesOfBuild[stage - 2][i]);
            }
            
            stage--;
        }
    }
}

