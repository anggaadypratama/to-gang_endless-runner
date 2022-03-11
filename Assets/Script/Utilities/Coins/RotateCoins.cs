using UnityEngine;

public class RotateCoins : MonoBehaviour
{
    public int rotateSpeed = 1;
    void Update() => transform.Rotate(0, rotateSpeed, 0, Space.World);

}
