
using System.Collections.Generic;
using Unity.Services.Authentication;
using Unity.Services.CloudCode;
using Unity.Services.Core;
using UnityEngine;


public class CloudCodeExample : MonoBehaviour
{
    
    //The response from the script, used for deserialization.
    // In this example, the script would return a JSON in the format
    // {"welcomeMessage": "Hello, arguments['name']. Welcome to Cloud Code!"}
    
    private class CloudCodeResponse
    {
        public string welcomeMessage;
    }


    public async void Awake()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }


    public async void OnClick()
    {
        try
        {
            string respuesta = await CloudCodeService.Instance.CallModuleEndpointAsync<string>(
            "ModuloJuego",                                            // 1. Qué módulo
            "SayHello",                                               // 2. Qué función
            new Dictionary<string, object> { { "name", "Lautaro" } }  // 3. Con qué parámetros
            );

            Debug.Log(respuesta);
        }
        catch (CloudCodeException e)
        {
            Debug.Log(e);
        }
        
    }
}
