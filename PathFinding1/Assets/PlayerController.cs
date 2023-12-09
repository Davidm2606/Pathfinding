using UnityEngine;

public class MoveToClick : MonoBehaviour
{
    // Velocidad de movimiento de la c�psula
    public float speed = 20f;

    void Update()
    {
        // Verifica si se hizo clic con el bot�n izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Obt�n la posici�n del clic en el mundo
            Vector3 targetPosition = GetMouseWorldPosition();

            // Mueve la c�psula hacia la posici�n del clic
            MoveToTarget(targetPosition);
        }
    }

    // M�todo para obtener la posici�n del clic en el mundo
    Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }

        return Vector3.zero;
    }

    // M�todo para mover la c�psula hacia la posici�n objetivo
    void MoveToTarget(Vector3 targetPosition)
    {
        // Calcula la direcci�n hacia el objetivo
        Vector3 direction = targetPosition - transform.position;

        // Normaliza la direcci�n para mantener una velocidad constante
        direction.Normalize();

        // Mueve la c�psula en la direcci�n calculada con la velocidad establecida
        transform.Translate(direction * speed * Time.deltaTime);
    }
}