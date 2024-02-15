using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class ClientSingleton : MonoBehaviour
{
  private static ClientSingleton instance;
  private CilentGameManager gameManager;
  
  public static ClientSingleton Instance
  {
    get
    {
      if (instance == null) { return instance; }

      instance = FindFirstObjectByType<ClientSingleton>();
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

  public async Task CreateClient()
  {
    gameManager = new CilentGameManager();
    await gameManager.InitAsync();
  }
}
