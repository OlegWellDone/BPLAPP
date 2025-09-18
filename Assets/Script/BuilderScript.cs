using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
//Firebase base
using Firebase.Extensions;
using Firebase.Database;
using System.Numerics;



public class BuilderScript : MonoBehaviour
{

    private Dictionary<int, List<GameObject>> stagesOfBuild = new Dictionary<int, List<GameObject>>();
    private Dictionary<int, string> ExplanationGuide = new Dictionary<int, string>();
    [SerializeField] private GameObject meObject;
    [SerializeField] private GameObject BPLAModel;
    [SerializeField] private Material NewMaterial;
    [SerializeField] private Material OldMaterial;
    [SerializeField] private TextMeshProUGUI textObject;

    private Infoobject InfoScript;

    private DatabaseReference dbReference;
    private int stage = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dbReference = FirebaseDatabase.DefaultInstance.RootReference;
        FirebaseDatabase.DefaultInstance.GoOnline();
        FirebaseDatabase.DefaultInstance
            .GetReference("/")                    
            .GetValueAsync().ContinueWithOnMainThread(task => {
                if (task.IsFaulted)
                {
                    Debug.Log("Ошибка подключения к базе данных или доступа к ней");
                    // Handle the error...
                }
                else if (task.IsCompleted)
                {
                    DataSnapshot snapshot = task.Result;
                    foreach (DataSnapshot child in snapshot.Children)
                    {
                        int key = int.Parse(child.Key);
                        string value = child.Value?.ToString();
                        //добавить третье значение в мапу для описания и туда вставить собственно нашу последовательность сборки
                        ExplanationGuide.Add(key, value);
                    }
                }
        });



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

        //BuildBPLA(true);
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

    private void SetStartModel(int oldStage)
    {
        //Debug.Log("А мы ставим материал для прошлой детали");
        for (int i = 0; i < stagesOfBuild[oldStage].Count; i++)
        {
            stagesOfBuild[oldStage][i].GetComponent<materialClassCool>().setCollor();
        }
    }
    public void BuildBPLA(bool next)
    {
        if (next && stage <= stagesOfBuild.Count)
        {
            if (stage <= ExplanationGuide.Count)
            {
                textObject.text = ExplanationGuide[stage];
            }
            //типо делаем следующий шаг
            for (int i = 0; i < stagesOfBuild[stage].Count; i++)
            {
                stagesOfBuild[stage][i].SetActive(true);
                //stagesOfBuild[stage][i].GetComponent<MeshRenderer>().material = NewMaterial;
                //Артём нахуевертил тута
                meObject.GetComponent<Infoobject>().setInfoObject(stagesOfBuild[stage][i]);
            }
            if (stage > 1)
            {
                SetOldModel(stage - 1);
            }
            stage++;
        }
        else if ((next == false) && (stage > 2))
        {
            textObject.text = ExplanationGuide[stage-2];
            //очевидно делаем предыдущий шаг
            for (int i = 0; i < stagesOfBuild[stage - 1].Count; i++)
            {
                stagesOfBuild[stage - 1][i].SetActive(false);
            }
            for (int i = 0; i < stagesOfBuild[stage - 2].Count; i++)
            {
                SetStartModel(stage - 2);
                //stagesOfBuild[stage - 2][i].GetComponent<MeshRenderer>().material = NewMaterial;
                meObject.GetComponent<Infoobject>().setInfoObject(stagesOfBuild[stage - 2][i]);
            }

            stage--;
        }
    }
}

