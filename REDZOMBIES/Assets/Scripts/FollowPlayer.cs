using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject playerObject; //Get a reference to player object

    void Update()
    {
        gameObject.transform.position = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, gameObject.transform.position.z);
        //Set cameras position to that of players x and y position
    }
}
