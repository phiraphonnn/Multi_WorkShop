using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class HostSingleton : MonoBehaviour
{
    private static HostGameManager instance;
    private HostGameManager gameManager;
  
    public static HostGameManager Instance
    {
        get
        {
            if (instance == null) { return instance; }

            instance = FindFirstObjectByType<HostGameManager>();
            if (instance == null)
            {
                return null;
            }

            return instance;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public async Task CreateHost()
    {
        gameManager = new HostGameManager();
    }
}
