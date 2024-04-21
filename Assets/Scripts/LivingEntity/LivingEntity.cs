using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct EntityState
{
    public int maxHp;
    public int currntHp;
    public bool isDead;
    public int base_AttackSpeed;
    public int base_MoveSpeed;
    public int attackSpeed;
    public int moveSpeed;
    public int turn;
    public int oldTurn;
    public int damage;
}

public class LivingEntity : MonoBehaviour
{
    public EntityState myState;
    
    public MoveState moveState;
    public int lastDamaged;
    
    GameObject hpSliderObj;
    Slider hpSlider;
    GameObject myCanvasObj;

    private void Awake()
    {
        SetCanvas();
    }
    private void Start()
    {

    }
    private void Update()
    {
        //CanvasSetActive();
    }
    public virtual void Damaged(int damage)
    {
        myState.currntHp -= damage;
        IsDead();
        SetHpBarValue();
    }
    void SetCanvas()
    {
        myCanvasObj = this.gameObject.transform.GetChild(0).transform.gameObject;
        hpSliderObj = myCanvasObj.transform.GetChild(0).gameObject;
        hpSlider = hpSliderObj.transform.GetComponent<Slider>();
    }
    protected void CanvasSetActive()
    {
        if(myCanvasObj == null)
        {
            Debug.Log("Canvas Error");
            Debug.Log(this.gameObject.layer);
            return;
        }
        if (myCanvasObj.layer != this.gameObject.layer)
        {
            myCanvasObj.layer = this.gameObject.layer;
        }
    }
    void SetHpBarValue()
    {
        hpSlider.value = myState.currntHp / myState.maxHp;
    }
    public virtual void Attack(LivingEntity target)
    {
        target.Damaged(myState.damage);
    }
    protected virtual void IsDead()
    {
        
    }
    protected virtual void OnMove()
    {

    }
    protected virtual void SetSpeed()
    {
        myState.attackSpeed = myState.base_AttackSpeed;
        myState.moveSpeed = myState.base_MoveSpeed;
    }
}
