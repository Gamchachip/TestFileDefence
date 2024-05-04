using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [SerializeField]

    //윈도우 클릭 드래그등 선택에 사용할 리스트 및 변수
    public List<SelectedMark> selectedUnitList;
    public  List<GameObject> UnitList { private set; get; }
    public bool isSelecting = false;
    public bool isdrag = false;
    
    
    //몬스터 및 파일 상대방 찾기용
    public int fileForderLayer = 0;
    public int monsterLayer = 0;
    


    void Awake()
    {
        selectedUnitList = new List<SelectedMark>();
        
        fileForderLayer = LayerMask.GetMask("Directory") |LayerMask.GetMask("File");
        monsterLayer = LayerMask.GetMask("Monster");
    }
     void Start()
    {
        UnitList = GameManager.instance.pool.fileList;
    }
}
