using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "File Data", menuName = "Scriptable Object/File Data")]


//๋ชฌ์ค?ฐ, ??ผ? ?ฐ?ด?ฐ
//??ฌ? ๋ชฌ์ค?ฐ? ??ผ? ?ด ?ฐ?ด?ฐ๋ฅ? ?ฌ?ฉ???ฐ ?ด?ค ๊ตฌ์กฐ๊ฐ? ์ข์??์ง?๋ฅ? ? ๋ชจ๋ฅด๊ฒ ์,,
public class FileData : ScriptableObject
{
    [SerializeField] private string fileName;
    public string FileName { get { return fileName;}}
    

    [SerializeField] private float hp;
    public float HP { get { return hp;} }
    

    
    [SerializeField] private float damage;
    public float Damage { get { return damage;} }
    

    [SerializeField] private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed;}}
    

    [SerializeField] private Sprite img;
    public Sprite Image { get { return img;}}


    [SerializeField] private GameObject prefab;
    public GameObject Prefab { get { return prefab;}}

    
    // [SerializeField] private Skill skill;
    // public Skill Skill { get { return skill;}}




}
