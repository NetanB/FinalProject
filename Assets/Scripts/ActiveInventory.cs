using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInventory : Singleton<ActiveInventory>
{
    private int activeSlotIndexNum = 0;

    private PlayerControls playerControls;

    protected override void Awake() {
        base.Awake();

        playerControls = new PlayerControls();
    }

    private void Start() {
        playerControls.Inventory.Keyboard.performed += ctx => ToggleActiveSlot((int)ctx.ReadValue<float>());
        
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    public void EquipStartingWeapon() {
        ToggleActiveHighlight(0);
    }

    private void ToggleActiveSlot(int numValue) {
        ToggleActiveHighlight(numValue - 1);
    }

    private void ToggleActiveHighlight(int indexNum) {
        activeSlotIndexNum = indexNum;

        foreach (Transform inventorySlot in this.transform)
        {
            inventorySlot.GetChild(0).gameObject.SetActive(false);
        }

        if (indexNum < 0 || indexNum >= transform.childCount)
{
    Debug.LogError("Invalid inventory index: " + indexNum);
    return;
}

        ChangeActiveWeapon();
    }

   private void ChangeActiveWeapon() {

    if (ActiveWeapon.Instance.CurrentActiveWeapon != null) {
        Destroy(ActiveWeapon.Instance.CurrentActiveWeapon.gameObject);
    }

    if (activeSlotIndexNum < 0 || activeSlotIndexNum >= transform.childCount) {
        Debug.LogError("Invalid slot index");
        return;
    }

    Transform childTransform = transform.GetChild(activeSlotIndexNum);
    InventorySlot inventorySlot = childTransform.GetComponentInChildren<InventorySlot>();

    if (inventorySlot == null) {
        Debug.LogError("Missing InventorySlot component");
        ActiveWeapon.Instance.WeaponNull();
        return;
    }

    WeaponInfo weaponInfo = inventorySlot.GetWeaponInfo();

    if (weaponInfo == null) {
        Debug.Log("Empty slot");
        ActiveWeapon.Instance.WeaponNull();
        return;
    }

    GameObject weaponToSpawn = weaponInfo.weaponPrefab;
    GameObject newWeapon = Instantiate(weaponToSpawn, ActiveWeapon.Instance.transform);

    var weaponComponent = newWeapon.GetComponent<MonoBehaviour>();

    Debug.Log("Weapon Component: " + weaponComponent);

    if (weaponComponent == null) {
        Debug.LogError("Weapon prefab has no MonoBehaviour!");
        return;
    }

    ActiveWeapon.Instance.NewWeapon(weaponComponent);
}
}
