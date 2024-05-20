﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyLife.Core.Services;

namespace MyLife.Maui.ViewModels
{
    public partial class MainViewModel(LifeService lifeService, MediumService mediumService) : ObservableObject
    {
        [ObservableProperty]
        private string firstname;

        [ObservableProperty]
        private Uri avatarImageUri;

        [ObservableProperty]
        private string introduction;

        [RelayCommand]
        private async Task FetchData()
        {
            var life = await lifeService.GetLife();
            if (life is null) return;

            Firstname = "Hi, I'm " + life.Persona.Firstname;
            AvatarImageUri = new(life.Persona.AvatarImageUrls[0]);
            Introduction = string.Join("\n", life.Persona.IntroductionParagraphs);
        }
    }
}