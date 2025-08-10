using Unity.VisualScripting;
using UnityEngine;
using TMPro;
public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public int plantcount = 0;
    public int seedcount = 0;
    public int coincount = 50;
    public TextMeshProUGUI plantCountText;
    public TextMeshProUGUI seedCountText;
    public TextMeshProUGUI coinCountText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }
    void Start()
    {
        UpdateUI();
    }
    public void AddPlant()
    {
        plantcount++;
        UpdateUI();
    }
      public void Addseed()
    {
        seedcount++;
        UpdateUI();
    }
      public void SpendCoins(int amount)
    {
        coincount -= amount;
        UpdateUI();
    }
       public void AddCoins(int amount)
    {
        coincount += amount;
        UpdateUI();
    }
       public void SellPlant()
    {
        plantcount--;
        UpdateUI();
    }

    // Update is called once per frame
    void UpdateUI()
    {
        plantCountText.text = "Plants:" + plantcount.ToString();
        seedCountText.text = "Seeds:" + seedcount.ToString();
        coinCountText.text = "Coins:" + coincount.ToString();
    }
    public bool HasEnoughCoins(int amount)
    {
        return coincount >= amount;
    }
}
