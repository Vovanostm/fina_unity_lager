using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject inventaryUI;
    public bool isInventaryActive = false;
    public Inventary inventary;
    public InventaryItem itemToAdd;

    public GameObject pickableItem;
    void Start()
    {
        inventary = gameObject.GetComponent<Inventary>();
        inventaryUI.GetComponent<InventaryController>().inventary = inventary;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) {
            isInventaryActive = !isInventaryActive;
            inventaryUI.SetActive(isInventaryActive);
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            if (pickableItem) {
                itemToAdd = pickableItem.GetComponent<PickableController>().item;
                inventary.AddItem(itemToAdd);
                Destroy(pickableItem);
            }
        }
        float moveX = Input.GetAxis("Horizontal");
        transform.Translate(moveX * Time.deltaTime, 0, 0);
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("Pickable"))
            pickableItem = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other) {
        pickableItem = null;
    }
}
