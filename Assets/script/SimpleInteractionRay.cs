using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class SimpleInteractionRay : MonoBehaviour
{
    public float distance = 5f;
    public TextMeshProUGUI interactionText;

    bool isLookingAtInteractable;

    void Start()
    {
        if (interactionText != null)
            interactionText.gameObject.SetActive(false);
    }

    void Update()
    {
        Debug.Log("SCRIPT ÇALIŞIYOR");

        if (Camera.main == null) return;
        if (Keyboard.current == null) return;

        isLookingAtInteractable = false;

        Ray ray = new Ray(
            Camera.main.transform.position,
            Camera.main.transform.forward
        );

        RaycastHit hit;

        // 🔵 Ray yerine SphereCast (daha stabil)
        if (Physics.SphereCast(ray, 0.3f, out hit, distance))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                isLookingAtInteractable = true;

                interactionText.text = "E - İncele";

                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    interactable.Interact();
                }
            }
        }

        // 🔴 Yazıyı tek yerden aç/kapat (titreme yok)
        interactionText.gameObject.SetActive(isLookingAtInteractable);
    }
}
