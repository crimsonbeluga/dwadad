using UnityEngine;

public class UFO : MonoBehaviour
{
    public float UFOspeed = 1f;
    public GameObject player;
    public Vector3 playerCurentPosition;
    public Vector3 ufoCurrentPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        {
            if (player == null)

                player = GameObject.FindWithTag("Player");
        }
      
        ufoCurrentPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        playerCurentPosition = player.transform.position;
       

        ufoCurrentPosition = Vector3.MoveTowards(ufoCurrentPosition, playerCurentPosition, UFOspeed * Time.deltaTime);

        transform.position = ufoCurrentPosition;    
    }
}
