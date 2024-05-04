using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [SerializeField]

    //������ Ŭ�� �巡�׵� ���ÿ� ����� ����Ʈ �� ����
    public List<SelectedMark> selectedUnitList;
    public  List<GameObject> UnitList { private set; get; }
    public bool isSelecting = false;
    public bool isdrag = false;
    
    
    //���� �� ���� ���� ã���
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
