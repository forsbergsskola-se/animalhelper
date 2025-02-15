﻿using System.Collections.Generic;
using UnityEngine;

public class DisplayInventory : MonoBehaviour {
    private Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    
    public InventoryObject inventory;
    public GameObject ItemViewPrefab;

    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEM;

    private void Start() {
        CreateDisplay();
    }

    private void Update() {
        UpdateDisplay();
    }

    private void CreateDisplay() {
        for (int i = 0; i < inventory.Container.Count; i++) {
            var obj = Instantiate(ItemViewPrefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponent<ItemView>().Display(inventory.Container[i]);
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }

    public Vector3 GetPosition(int i) {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BETWEEN_ITEM * (i / NUMBER_OF_COLUMN)), 0f);
    }

    public void UpdateDisplay() {
        for (int i = 0; i < inventory.Container.Count; i++) {
            if (itemsDisplayed.ContainsKey(inventory.Container[i])) {
                itemsDisplayed[inventory.Container[i]].GetComponent<ItemView>().Display(inventory.Container[i]);
            }
            else {
                var obj = Instantiate(ItemViewPrefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponent<ItemView>().Display(inventory.Container[i]);
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
            if (inventory.Container[i].amount == 0) {
                Destroy(itemsDisplayed[inventory.Container[i]]);
                itemsDisplayed.Remove(inventory.Container[i]);
            }
        }
    }
}
