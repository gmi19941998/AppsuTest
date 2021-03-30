using System;
using AppsuTest;
using UnityEngine;
using UnityEngine.EventSystems;

public class FingerController : ApplicationElement, IRaycasting
{
    
    public event Action OnPlayerHit;
    public event Action<Vector3> OnGroundHit;
    [SerializeField] private float _timeForNextRay = 0.05f;
    private float timer = 0;
    
    void Update()
    {

        Raycasting();
    }

    public void Raycasting()
    {
        Vector2 CurMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(CurMousePos, Vector2.zero);

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (hit.collider.GetComponent<PlayerCircle>())
            {
                OnPlayerHit?.Invoke();

                return;
            }
        }
        if (Input.GetMouseButton(0) && timer > _timeForNextRay && !EventSystem.current.IsPointerOverGameObject())
        {
            //  Debug.DrawLine(Camera.main.transform.position, hit.point, Color.green, 1f);
            if (hit.collider.GetComponent<PlayerCircle>()) return;
            OnGroundHit?.Invoke(CurMousePos);
            timer = 0;
        }
        if (Input.GetMouseButtonUp(0) &&!EventSystem.current.IsPointerOverGameObject())
        {
            //  Debug.DrawLine(Camera.main.transform.position, hit.point, Color.green, 1f);
            if (hit.collider.GetComponent<PlayerCircle>()) return;
            OnGroundHit?.Invoke(CurMousePos);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}