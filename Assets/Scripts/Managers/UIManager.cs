using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    public GameObject createUI;
    void Start()
    {
    }

    void Update()
    {

        //우클릭 시 만들기UI 생성
        if (Input.GetMouseButtonDown(1) && !GameManager.instance.isPause)
        {
            Vector3 scrrenToWolrd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            scrrenToWolrd.z = 0;
            createUI.GetComponent<RectTransform>().position = scrrenToWolrd;
            createUI.gameObject.SetActive(true);    
        }

        else if (Input.GetMouseButtonUp(0) && !GameManager.instance.isPause)
        {
            createUI.SetActive(false);
        }

    }
}
