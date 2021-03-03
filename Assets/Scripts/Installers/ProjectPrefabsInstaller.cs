﻿using DataBase.Audio;
using DataBase.Character;
using DataBase.Objects;
using DataBase.Objects.Impl;
using UnityEngine;
using Zenject;
using ZenjectUtil.Test.Extensions;

namespace Installers
{
    [CreateAssetMenu(menuName = "Installers/ProjectPrefabsInstaller", fileName = "ProjectPrefabsInstaller")]
    public class ProjectPrefabsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private PrefabsBase prefabBase;
        [SerializeField] private CharacterSettingsBase characterBase;
        [SerializeField] private AudioBase audioBase;
        
        public override void InstallBindings()
        {
            Container.Bind<IPrefabsBase>().FromSubstitute(prefabBase).AsSingle();
            Container.Bind<ICharacterSettingsBase>().FromSubstitute(characterBase).AsSingle();
            Container.Bind<IAudioBase>().FromSubstitute(audioBase).AsSingle();
        }
    }
}