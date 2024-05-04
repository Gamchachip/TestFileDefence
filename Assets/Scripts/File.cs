using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class File : MonoBehaviour
{

    //일단은 public
    [Header("status")]
    public float hp;

    void Start()
    {
        //일단 테스트용
        GetComponent<Scanner>().InitLayer();
    }
    
    public void Init(FileData data)
    {
        hp = data.HP;

        Debug.Log(hp);
    }




}
