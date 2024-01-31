using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.RemoteConfig;
using Unity.Services.Core;
using Unity.Services.Authentication;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace GB 
{
  

public class ApplyRemoteConfig : MonoBehaviour
{
    public static ApplyRemoteConfig instance { get; private set; }

    public string language = "English";
    public string season = "Default";
    public float characterSize = 1.0f;

    public struct UserAttributes
    {
        //datos activos del jugador que pueden mandarse a la base de datos a configurar 
        //variables can be updated as the game progresses and them used in Campaing Audience Targeting
        public int score;
    }

    public struct AppAttributes
    {
        //optionalmente declara variables para cada tipo de configuracion de la app segun sus atributos
        //lo que me han pedido que rellene
        public string appVersion;
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
    }
    async void Start()
    {
        await InitializeRemoteConfigAssync();

        UserAttributes user = new UserAttributes()
        {
            score = 10
        };

        
    }
    async Task InitializeRemoteConfigAssync()
    {
        //nitialize handlers for unity game services
        await UnityServices.InitializeAsync();

        //remote config now requires authentication for managing environment information and retrieving settings
        if(!AuthenticationService.Instance.IsSignedIn)
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }
        Debug.Log("InitializeRemoteConfigAssync <color=green>SUCCESS</color>",this);
    }
}

}
