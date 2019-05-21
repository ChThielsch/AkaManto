using Assets.Scripts.PhoneScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneController : MonoBehaviour
{
    public InventoryManager m_playerInventory;
    public GameObject TestItemPrefab;

    ButtonType m_selectedButton;
    GameObject m_mainMenuGrid, m_inventoryGrid, SceneLight, Flashlight;
    // Start is called before the first frame update
    void Start()
    {
        m_mainMenuGrid = GameObject.Find("MainMenuGrid");
        // I would rather start the scene with inventoryGrid as false, but then gameobject.find wont work, so this is a temp workaround
        m_inventoryGrid = GameObject.Find("InventoryGrid");
        m_inventoryGrid.SetActive(false);
        SceneLight = GameObject.Find("Directional Light");
        //Same thing as with the InventoryGrid
        Flashlight = GameObject.Find("Flashlight");
        Flashlight.SetActive(false);
        m_selectedButton = 0;
        GameObject button = m_mainMenuGrid.transform.GetChild((int)m_selectedButton).gameObject;
        button.GetComponent<Image>().color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            //TODO: Make the selection work with all Grid no matter wich one is selected
            if (m_inventoryGrid.activeSelf == false) {
                GameObject button = m_mainMenuGrid.transform.GetChild((int)m_selectedButton).gameObject;
                button.GetComponent<Image>().color = Color.white;
                m_selectedButton += 1;
                button = m_mainMenuGrid.transform.GetChild((int)m_selectedButton).gameObject;
                button.GetComponent<Image>().color = Color.red;
            } else {
                GameObject button = m_inventoryGrid.transform.GetChild((int)m_selectedButton).gameObject;
                button.GetComponent<Image>().color = Color.white;
                m_selectedButton += 1;
                button = m_inventoryGrid.transform.GetChild((int)m_selectedButton).gameObject;
                button.GetComponent<Image>().color = Color.red;
            }
        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {

            if (m_inventoryGrid.activeSelf == false) {
                GameObject button = m_mainMenuGrid.transform.GetChild((int)m_selectedButton).gameObject;
                button.GetComponent<Image>().color = Color.white;
                m_selectedButton -= 1;
                button = m_mainMenuGrid.transform.GetChild((int)m_selectedButton).gameObject;
                button.GetComponent<Image>().color = Color.red;
            } else {
                GameObject button = m_inventoryGrid.transform.GetChild((int)m_selectedButton).gameObject;
                button.GetComponent<Image>().color = Color.white;
                m_selectedButton -= 1;
                button = m_inventoryGrid.transform.GetChild((int)m_selectedButton).gameObject;
                button.GetComponent<Image>().color = Color.red;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return)) {

            if (m_selectedButton == ButtonType.Inventory) {

                m_mainMenuGrid.SetActive(false);
                m_inventoryGrid.SetActive(true);

                GameObject button = m_inventoryGrid.transform.GetChild((int)m_selectedButton).gameObject;
                button.GetComponent<Image>().color = Color.red;
            }
        }

        if (Input.GetKeyDown(KeyCode.Backspace)) {

            if (m_inventoryGrid.activeSelf == true) {

                m_mainMenuGrid.SetActive(true);
                m_inventoryGrid.SetActive(false);

                GameObject button = m_mainMenuGrid.transform.GetChild((int)m_selectedButton).gameObject;
                button.GetComponent<Image>().color = Color.red;
            }
        }

        //TODO: Use event System based on size Change in Inventory
        if (Input.GetKeyDown(KeyCode.P)) {

            m_playerInventory.m_PickedUpItems.Add(new Item());
            GameObject newItem = Instantiate(TestItemPrefab, m_inventoryGrid.transform.position, m_inventoryGrid.transform.rotation);
            newItem.transform.SetParent(m_inventoryGrid.transform);
        }

        if (Input.GetKeyDown(KeyCode.F)) {

            SceneLight.SetActive(!SceneLight.activeSelf);
            Flashlight.SetActive(!SceneLight.activeSelf);
        }
    }
}
