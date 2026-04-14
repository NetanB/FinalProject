using System;
using UnityEngine;

public class Sword : MonoBehaviour
{
   private PlayerControls playerControls;
   private Animator myAnimator;

    private PlayerController playerController;

    private ActiveWeapon activeWeapon;


   private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
        activeWeapon = GetComponentInParent<ActiveWeapon>();   
        playerControls = new PlayerControls();
        myAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        playerControls.Enable();

    }

    void Start()
    {
        playerControls.Combat.Attack.started += _ => Attack();

    }
    private void Update()
    {
        MouseFollowWithOffset();
    }

    private void Attack()
    {
        myAnimator.SetTrigger("Attack");
    }

    private void MouseFollowWithOffset()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(playerController.transform.position);

        float angle = Mathf.Atan2(mousePosition.x, mousePosition.y) * Mathf.Rad2Deg;

        if(mousePosition.x < playerScreenPosition.x)
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0f, -180f, angle);
        }
        else
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }


}
