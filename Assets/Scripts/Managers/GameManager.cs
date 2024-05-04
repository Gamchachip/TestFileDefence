using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글톤을 할당할 전역 변수

    public UIManager        uiManager;
    public PoolManager      pool;
    public SelectManager    selectManager;

    public bool isPause = false; // 게임 중지 상태

    void Awake()
    {
        instance = this;
        selectManager = GetComponentInChildren<SelectManager>();
        uiManager =     GetComponentInChildren<UIManager>();
        pool =          GetComponentInChildren<PoolManager>();

}
}
