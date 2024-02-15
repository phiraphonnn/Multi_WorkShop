using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class AppContron : MonoBehaviour
{
    [SerializeField] private ClientSingleton clientPrefab;
    [SerializeField] private HostSingleton HostPrefab;
    // Start is called before the first frame update
    private async void Start()
    {
        DontDestroyOnLoad(gameObject);
        await LaunchInMode(SystemInfo.graphicsDeviceType == UnityEngine.Rendering.GraphicsDeviceType.Null);
    }

    private async Task LaunchInMode(bool isDedicatedServer)
    {
        if (isDedicatedServer)
        {
            
        }
        else
        {
            ClientSingleton clientSingleton = Instantiate(clientPrefab);
            await clientSingleton.CreateClient();
            
            HostSingleton hostSingleton = Instantiate(HostPrefab);
             hostSingleton.CreateHost();
        }
    }
}
