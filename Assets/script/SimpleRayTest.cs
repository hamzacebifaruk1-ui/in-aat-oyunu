using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleRayTest : MonoBehaviour
{
    void Update()
    {
        if (Camera.main == null) return;

        Ray ray = new Ray(
            Camera.main.transform.position,
            Camera.main.transform.forward
        );

        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.green);

        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("E BASILDI");

            if (Physics.Raycast(ray, out RaycastHit hit, 10f))
            {
                Debug.Log("RAY ÇARPTI → " + hit.collider.name);

                Interactable interactable =
                    hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    Debug.Log("INTERACTABLE BULUNDU");
                    interactable.Interact();
                }
                else
                {
                    Debug.Log("INTERACTABLE YOK");
                }
            }
            else
            {
                Debug.Log("RAY HİÇBİR ŞEYE ÇARPMADI");
            }
        }
    }
}
