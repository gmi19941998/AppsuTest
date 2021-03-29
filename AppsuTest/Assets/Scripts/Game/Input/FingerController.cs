using System;
using AppsuTest;
using UnityEngine;

public class FingerController : MonoBehaviour, IRaycasting
{
    // Start is called before the first frame update


    public event Action OnPlayerHit;
    public event Action<Vector3> OnGroundHit;

    void Update()
    {
        Raycasting();
    }

    public void Raycasting()
    {
        Vector2 CurMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(CurMousePos, Vector2.zero);
        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider.GetComponent<PlayerCircle>())
            {
                OnPlayerHit?.Invoke();
                return;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (hit.collider.GetComponent<PlayerCircle>()) return;
            OnGroundHit?.Invoke(CurMousePos);
        }
    }
}