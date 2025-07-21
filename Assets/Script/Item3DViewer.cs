using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
public class Item3DViewer : MonoBehaviour, IDragHandler
{
    //тут новая модель(копия)
    private Transform itemPrefab;
    //Сюда существующую модель
    public Transform prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartVisual();
    }
    private void StartVisual()
    {
        if (itemPrefab != null)
        {
            //удаляет если такое уже есть
            Destroy(itemPrefab.gameObject);
        }
        //Шалупонь создающая новую модельку
        //itemPrefab = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        Debug.Log("Start");
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrag(PointerEventData data)
    {
        Debug.Log("123");
    }
}
