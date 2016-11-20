using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour {


    public GameObject slotPrefab;
    public SlotHandler slotHandler;
    public KeyCode slotKey1;
    public KeyCode slotKey2;
    public KeyCode slotKey3;
    public KeyCode slotKey4;
    public KeyCode slotKey5;
    public KeyCode slotKey6;

    [HideInInspector]
    public List<SlotScipt> itemSlots = new List<SlotScipt>();
    private float xOffset;
    private float yOffset;
    private int slotRows;
    private int slotCols;


    void Awake()
    {
        RectTransform inventoryRt = gameObject.GetComponent<Image>().GetComponent<RectTransform>();
        RectTransform slotRt = slotPrefab.GetComponent<Image>().GetComponent<RectTransform>();

        //Calculates how many rows and cols of slots can fit, based on the size of the inventory "image".
        slotRows = (int)(inventoryRt.rect.width / slotRt.rect.width) - 1;
        slotCols = (int)(inventoryRt.rect.height / slotRt.rect.height) - 1;
        //Calculates balanced offsets for the slots.
        xOffset = (inventoryRt.rect.width - (slotRt.rect.width * slotRows)) / (slotRows + 1);
        yOffset = (inventoryRt.rect.height - (slotRt.rect.height * slotCols)) / (slotCols + 1);


        if (slotCols == 0)
        {
            slotCols = 1;
        }

        CreateSlots(inventoryRt.rect.width, inventoryRt.rect.height, slotRt.rect.width, slotRt.rect.height);

        GameManager.Instance.OnStartGame += OnStart;
        gameObject.SetActive(false);

    }

    void CreateSlots(float invWidth, float invHeight, float slotWidth, float slotHeight)
    {
        Vector3 pos = new Vector3(invWidth * -1 + slotWidth, invHeight, 0);
        Vector3 origPos = pos;
        pos.y = pos.y - yOffset;
        pos.x = pos.x + xOffset;

        for (int i = 0; i < slotCols; i++)
        {
            for (int k = 0; k < slotRows; k++)
            {
                if (k != 0)
                    pos.x = pos.x + slotWidth + xOffset;
                GameObject o = (GameObject)Instantiate(slotPrefab, pos, Quaternion.identity);
                o.transform.SetParent(gameObject.transform, false);
                SlotScipt s = o.GetComponent<SlotScipt>();
                s.slotNumber = i + k;
                itemSlots.Add(s);
            }

            pos.y = pos.y - slotHeight - yOffset;
            pos.x = origPos.x + xOffset;
        }

        SetKeys();
    }

    void SetKeys()
    {
        itemSlots[0].inputKey = slotKey1;
        itemSlots[1].inputKey = slotKey2;
        itemSlots[2].inputKey = slotKey3;
        itemSlots[3].inputKey = slotKey4;
        itemSlots[4].inputKey = slotKey5;
        itemSlots[5].inputKey = slotKey6;
    }

    void OnStart()
    {
        if(this != null)
            gameObject.SetActive(true);
    }
}
