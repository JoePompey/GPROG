using UnityEngine;
using UnityEngine.SceneManagement;

public class ActiveGame : MonoBehaviour
{
    //Loads the map, player, and sailor.
    void Start()
    {
        SceneManager.LoadScene("Map", LoadSceneMode.Additive);
        SceneManager.LoadScene("Player", LoadSceneMode.Additive);
        SceneManager.LoadScene("Sailor", LoadSceneMode.Additive);
    }
    //.
}
