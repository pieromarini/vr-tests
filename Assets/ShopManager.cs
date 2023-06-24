using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    public Item(int _id, string _name, int _price)
    {
        id = _id;
        name = _name;
        price = _price;
    }

    public int id;
    public string name;
    public int price;
    public Sprite image;
    [HideInInspector]
    public int quantity;
    [HideInInspector]
    public GameObject itemRef;
}

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public int coins = 10000;

    public TextMeshProUGUI coinText;
    public GameObject shopUI;
    public Transform shopContent;
    public GameObject itemPrefab;   

    public List<Item> items;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void toggleShop()
    {
        shopUI.SetActive(!shopUI.activeSelf);
    }

    void Start()
    {
        foreach (Item item in items)
        {
            GameObject itemGO = Instantiate(itemPrefab, shopContent);
            item.itemRef = itemGO;

            foreach (Transform child in itemGO.transform)
            {
                if (child.gameObject.name == "Quantity")
                {
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = item.quantity.ToString();
                }
                else if (child.gameObject.name == "Cost")
                {
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = item.price.ToString();
                }
                else if (child.gameObject.name == "Name")
                {
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = item.name.ToString();
                }
                else if (child.gameObject.name == "Image")
                {
                    child.gameObject.GetComponent<Image>().sprite = item.image;
                }
            }

            itemGO.GetComponent<Button>().onClick.AddListener(() => {
                BuyItem(item);
            });
        }
    }

    private void OnGUI()
    {
        coinText.text = coins.ToString();
    }

    void BuyItem(Item item)
    {
        if (coins >= item.price)
        {
            coins -= item.price;
            item.quantity++;
            item.itemRef.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = item.quantity.ToString();
            coinText.text = coins.ToString();
        }
       
    }

    void createStoreButtons()
    {

    }

    void Update()
    {
        
    }
}
