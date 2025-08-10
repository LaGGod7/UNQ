using UnityEngine;

public class Shop : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void BuySeed()
    {
        int seedPrice = 10;
        if (InventoryManager.instance.HasEnoughCoins(seedPrice))
        {
            InventoryManager.instance.SpendCoins(seedPrice);
            InventoryManager.instance.Addseed();
        }
        else
        {
            Debug.Log("Not Enough Coins");
        }
    }
    public void SellPlant()
    {
        if (InventoryManager.instance.plantcount > 0)
        {
            InventoryManager.instance.SellPlant();
            InventoryManager.instance.AddCoins(10);
        }
        else
        {
            Debug.Log("Not Enough Plants");
        }
    
   }
}
