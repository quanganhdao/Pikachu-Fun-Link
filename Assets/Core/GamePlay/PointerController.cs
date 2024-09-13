using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PointerController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layerMask;

    public UnityEvent<Tile> OnTileClicked;
    public void OnPointerClick(BaseEventData eventData)
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // Bắn raycast từ vị trí của chuột
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        // Kiểm tra nếu raycast trúng một đối tượng có Collider2D
        if (hit.collider != null)
        {
            Debug.Log("Selected Object: " + hit.collider.gameObject.name);
            // Thực hiện các hành động khác với đối tượng đã chọn ở đây
            OnTileClicked?.Invoke(hit.collider.gameObject.GetComponent<Tile>());
        }

    }
}
