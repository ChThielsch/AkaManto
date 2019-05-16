using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneController : MonoBehaviour
{
    public InventoryManager m_playerInventory;

    int m_selectedButton;
    GameObject m_buttonGrid;
    // Start is called before the first frame update
    void Start()
    {
        m_buttonGrid = GameObject.Find("MainMenu");
        m_selectedButton = 0;
        GameObject button = m_buttonGrid.transform.GetChild(m_selectedButton).gameObject;
        button.GetComponent<Image>().color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {

            GameObject button = m_buttonGrid.transform.GetChild(m_selectedButton).gameObject;
            button.GetComponent<Image>().color = Color.white;
            m_selectedButton += 1;
            button = m_buttonGrid.transform.GetChild(m_selectedButton).gameObject;
            button.GetComponent<Image>().color = Color.red;
        }else if (Input.GetKeyDown(KeyCode.LeftArrow)) {

            GameObject button = m_buttonGrid.transform.GetChild(m_selectedButton).gameObject;
            button.GetComponent<Image>().color = Color.white;
            m_selectedButton -= 1;
            button = m_buttonGrid.transform.GetChild(m_selectedButton).gameObject;
            button.GetComponent<Image>().color = Color.red;
        }

        if()
    }
}
