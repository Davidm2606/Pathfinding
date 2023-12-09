using UnityEngine;

public class MoveToClick : MonoBehaviour
{
    // Velocidad de movimiento de la cápsula
    public float speed = 20f;

    void Update()
    {
        // Verifica si se hizo clic con el botón izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            // Obtén la posición del clic en el mundo
            Vector3 targetPosition = GetMouseWorldPosition();

            // Mueve la cápsula hacia la posición del clic
            MoveToTarget(targetPosition);
        }
    }

    // Método para obtener la posición del clic en el mundo
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

    // Método para mover la cápsula hacia la posición objetivo
    void MoveToTarget(Vector3 targetPosition)
    {
        // Calcula la dirección hacia el objetivo
        Vector3 direction = targetPosition - transform.position;

        // Normaliza la dirección para mantener una velocidad constante
        direction.Normalize();

        // Mueve la cápsula en la dirección calculada con la velocidad establecida
        transform.Translate(direction * speed * Time.deltaTime);
    }
}