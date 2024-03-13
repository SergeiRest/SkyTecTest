using System;
using LoadingScreen.Installer;
using UnityEngine;
using Zenject;

public class GameStartup : MonoBehaviour
{
    [Inject] private LoadingScreenProvider _loadingScreen;
    private void Awake()
    {
        _loadingScreen.LoadMainMenu();
    }
}