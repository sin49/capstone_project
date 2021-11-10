using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDownInventory : MonoBehaviour
{
    public GameObject Inven;
    bool check;
    // Start is called before the first frame update
    void Start()
    {
        Inven.SetActive(false);
        check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!check)
            {
                Inven.SetActive(true);
                check = true;
                Time.timeScale = 0;
            }
            else
            {
                Inven.SetActive(false);
                check = false;
                Time.timeScale = 1;
            }
        }
    }
}
