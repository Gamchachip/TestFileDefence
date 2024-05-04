using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class BoxCollision : MonoBehaviour
{

    //�巡�� �� �ڽ� �ݶ��̴��� �浹�ϸ� selectedUnitList �ش� collision�߰�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SelectedMark SU = collision.gameObject.GetComponent<SelectedMark>();
        if (SU != null)
        {
            if (!GameManager.instance.selectManager.selectedUnitList.Contains(SU))
            {
                GameManager.instance.selectManager.selectedUnitList.Add(SU);
                SU.SelectMe();
                Debug.Log(GameManager.instance.selectManager.selectedUnitList.Count);
            }
            else
            {
                GameManager.instance.selectManager.selectedUnitList.Remove(SU);
                SU.DeSelectMe();
                Debug.Log(GameManager.instance.selectManager.selectedUnitList.Count);
            }
        }
    }
    //�巡�� �� �ڽ� �ݶ��̴��� �������ö� selectedUnitList�� �ش� collision����
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!transform.gameObject.activeSelf)
            return;

        SelectedMark SU = collision.gameObject.GetComponent<SelectedMark>();
        if (SU != null)
        {
            if (GameManager.instance.selectManager.selectedUnitList.Contains(SU))
            {
                SU.DeSelectMe();
                GameManager.instance.selectManager.selectedUnitList.Remove(SU);
                Debug.Log(GameManager.instance.selectManager.selectedUnitList.Count);
            }
        }
    }


    private void Update()
    {




    }
}
