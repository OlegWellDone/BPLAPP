using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class AdapterScroll : MonoBehaviour
{
    [Tooltip("айтем списка из префаба")]
    [SerializeField] RectTransform prefabItem;
    [SerializeField] int counterItems; //будем брать исходя из элементов 3д модели
    [SerializeField] RectTransform content;

    [Tooltip("Это просто пример итогового объекта с которым мы пока что работаем")]
    [SerializeField] GameObject sampleobject;


//эту штуку мы типо должны с сервера заполнить (хз какой там тип будет)
    public class ItemModel
    {
        public string NameOfDetail;
        public RawImage ImageDetail;
    }
//это элемент отображения
    public class ViewItem
    {
        public Text NameOnScene;
        public RawImage ImageOnScene;

        public ViewItem(Transform root)
        {
            NameOnScene = root.Find("ItemText").GetComponent<Text>();
            ImageOnScene = root.Find("ImageDetail").GetComponent<RawImage>();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //запрашиваем данные тут с сервера в теории и должны получить модель ( или список моделей (или картинок с моделями))
        List<string> AllTags = new List<string>();
        foreach (Transform child in sampleobject.GetComponentsInChildren<Transform>(true))
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
        var ListItems = new ItemModel[AllTags.Count];
        for (int i = 0; i < AllTags.Count; i++)
        {
            ListItems[i] = new ItemModel();
            ListItems[i].NameOfDetail = AllTags[i];
        }

        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach (var model in ListItems)
        {
            var instance = GameObject.Instantiate(prefabItem.gameObject) as GameObject;
            instance.transform.SetParent(content, false);
            InitializeItemView(instance, model);
        }
    }

    private void InitializeItemView(GameObject viewGB, ItemModel model)
    {
        ViewItem view = new ViewItem(viewGB.transform);
        view.NameOnScene.text = model.NameOfDetail;
        view.ImageOnScene = model.ImageDetail;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
