using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
   //private PlayerControls playerControls;
   private Animator myAnimator;

    //private PlayerController playerController;

    //private ActiveWeapon activeWeapon;

    private Transform weaponCollider;
    [SerializeField] private float swordAttackCD = 0.5f;
    [SerializeField] private WeaponInfo weaponInfo;
    
    //private bool attackButtonDown, isAttacking = false;

    private void Awake() {
        myAnimator = GetComponent<Animator>();
        //PlayerControls = new PlayerControls();
    }

    private void Start() {
        weaponCollider = PlayerController.Instance.GetWeaponCollider();
    }
/*
    private void onEnable(){
        PlayerControls.Enable();
        
    }
*/
    private void Update() {
        MouseFollowWithOffset();
        //Attack();
    }
/*
    private void StartAttacking()
    {
        attackButtonDown = true;
    }
    private void StopAttacking()
    {
        attackButtonDown = false;
    }
*/
    public WeaponInfo GetWeaponInfo() {
        return weaponInfo;
    }

    public void Attack() {
        //is attacking = true;
        myAnimator.SetTrigger("Attack");
        weaponCollider.gameObject.SetActive(true);
        StartCoroutine(AttackCDRoutine());
        
    }

    private IEnumerator AttackCDRoutine() {
        yield return new WaitForSeconds(swordAttackCD);
        ActiveWeapon.Instance.ToggleIsAttacking(false);
        //isAttacking = false;
    }

    public void DoneAttackingAnimEvent() {
        weaponCollider.gameObject.SetActive(false);
    }


    private void MouseFollowWithOffset() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(PlayerController.Instance.transform.position);

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (mousePos.x < playerScreenPoint.x) {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, -180, angle);
            weaponCollider.transform.rotation = Quaternion.Euler(0, -180, 0);
        } else {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, 0, angle);
            weaponCollider.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }


}
