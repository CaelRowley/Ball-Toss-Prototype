using UnityEngine;

public class ContainerCollisionCheck : MonoBehaviour
{
    public float collisionTimeRequired = 1.0f;
    public Transform spawnedPrefab;

    private float collisionCurrentTime = 0.0f;
    private bool continueTimer = false;

    // Flags contact timer true when collision occurs
    private void OnCollisionEnter(Collision collider)
    {
        Debug.Log("Collided");
        continueTimer = true;
    }

    // Flags contact timer false when collision is over
    private void OnCollisionLeave(Collision collider)
    {
        continueTimer = false;
    }

    void OnCollisionStay(Collision collider)
    {
        collisionCurrentTime += Time.deltaTime;

        if(collisionCurrentTime > collisionTimeRequired && continueTimer)
        {
            Instantiate(spawnedPrefab, transform.position, transform.rotation);
            // Need to implement a destroy all in heirarchy function
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }
}
