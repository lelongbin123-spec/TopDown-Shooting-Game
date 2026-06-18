using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField]
    private Gun currentGun;

    public void Shoot()
    {
        currentGun?.Shoot();
    }
}