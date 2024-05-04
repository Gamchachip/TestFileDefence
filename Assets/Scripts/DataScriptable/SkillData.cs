using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Skill Data", menuName = "Scriptable Object/Skill Data")]
public class SkillData : ScriptableObject
{
    [SerializeField] private string skillName;
    public string SkillName { get { return skillName;}}
    
    [SerializeField] private string description;
    public string Description { get { return description;}}
    

    [SerializeField] private Sprite img;
    public Sprite Image { get { return img;}}


    // 스킬이 대미지를 가하는지 여부
    [SerializeField] private bool dealsDamage;
    public bool DealsDamage { get { return dealsDamage;}}


    //데미지
    [SerializeField] private float damage;
    public float Damage { get { return damage;} }


    //사거리
    [SerializeField] private float distance ;
    public float Distance  { get { return Distance;} }


    //쿨타임
    [SerializeField] private float cooltime ;
    public float Cooltime  { get { return Cooltime;} }


    [SerializeField] private GameObject prefab;
    public GameObject Prefab { get { return prefab;}}
}
