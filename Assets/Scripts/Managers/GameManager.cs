using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // �̱����� �Ҵ��� ���� ����

    public UIManager        uiManager;
    public PoolManager      pool;
    public SelectManager    selectManager;

    public bool isPause = false; // ���� ���� ����

    void Awake()
    {
        instance = this;
        selectManager = GetComponentInChildren<SelectManager>();
        uiManager =     GetComponentInChildren<UIManager>();
        pool =          GetComponentInChildren<PoolManager>();

}
}
