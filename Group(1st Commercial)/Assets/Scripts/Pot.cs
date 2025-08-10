
using UnityEngine;
using TMPro;

public class Pot : MonoBehaviour
{
    enum Potstate { Empty, Planted, Grown }
    private Potstate currentState = Potstate.Empty;
    public Sprite plantedSprite;
    public Sprite grownSprite;
    public Sprite emptySprite;
    private float growthTime = 2f;
    private float timer = 0f;
    private SpriteRenderer sr;
    public bool isPlNear = false;
    public bool isWatered = false;
    public TextMeshProUGUI pressKey;
    public TextMeshProUGUI CollectKey;
    public TextMeshProUGUI WaterKey;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = emptySprite;

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlNear && Input.GetKeyDown(KeyCode.E) && InventoryManager.instance.seedcount > 0)
        {
            if (currentState == Potstate.Empty)
            {
                Plant();
            }

            else if (currentState == Potstate.Grown)
            {

                CollectPlant();
            }

        }
        if (Input.GetKeyDown(KeyCode.P)&&isPlNear &&currentState == Potstate.Planted){
            Invoke("Grow", 5f);isWatered = true;WaterKey.gameObject.SetActive(false);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && currentState == Potstate.Empty)
        {
            isPlNear = true;
            pressKey.gameObject.SetActive(true);
        }
        else if (collision.CompareTag("Player")&& currentState == Potstate.Planted && !isWatered)
        { WaterKey.gameObject.SetActive(true);isPlNear = true;}

        else if (collision.CompareTag("Player") && currentState == Potstate.Grown)
        {
            isPlNear = true;
            CollectKey.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && currentState == Potstate.Empty)
        {
            isPlNear = false;
            pressKey.gameObject.SetActive(false);
        }
        else if (collision.CompareTag("Player") && currentState == Potstate.Planted) {
            isPlNear = false;WaterKey.gameObject.SetActive(false);
        }
        
        else if (collision.CompareTag("Player") && currentState == Potstate.Grown)
        {
            isPlNear = false;
            CollectKey.gameObject.SetActive(false);
        }
    }

    void Plant()
    {

        currentState = Potstate.Planted;
        sr.sprite = plantedSprite;
        pressKey.gameObject.SetActive(false);
        


    }
    void Grow()
    {
        sr.sprite = grownSprite;
        currentState = Potstate.Grown;
        isWatered = false;
    }

    void CollectPlant()
    { InventoryManager.instance.AddPlant();
               currentState = Potstate.Empty;
            sr.sprite = emptySprite;CollectKey.gameObject.SetActive(false);
           
    }
   
    
    
   
}
