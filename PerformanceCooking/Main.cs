using KitchenData;
using KitchenLib;
using KitchenLib.Customs;
using KitchenLib.Utils;
using KitchenLib.References;
using KitchenLib.Logging;
using KitchenMods;
using System.Collections.Generic;
using System.Reflection;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using Kitchen;
using PerformanceCooking.Unlocks;

namespace KitchenPerformanceCooking
{
    public class PerformanceCooking : BaseMod, IModSystem
    {
        public const string MOD_GUID = "Kailaria.PlateUp.PerformanceCooking";
        public const string MOD_NAME = "Performance Cooking";
        public const string MOD_VERSION = "0.1.0";
        public const string MOD_AUTHOR = "Kailaria";
        public const string MOD_GAMEVERSION = ">=1.1.7";

        internal static KitchenLogger Logger = new KitchenLogger(MOD_NAME);

        // Boolean constant whose value depends on whether you built with DEBUG or RELEASE mode, useful for testing
#if DEBUG
        public const bool DEBUG_MODE = true;
#else
        public const bool DEBUG_MODE = false;
#endif

        public PerformanceCooking() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        //public virtual HashSet<string> RequiredModNames => new HashSet<string>()
        //{

        //};

        protected override void OnPostActivate(Mod mod)
        {
            AddGameData();
            //Appliance hob = GDOUtils.GetExistingGDO(ApplianceReferences.Hob) as Appliance;
            //hob.EffectType = new CTableModifier
            //{
            //    PatienceModifiers = new PatienceValues
            //    {
            //        WaitForFood = 0.2f
            //    }
            //};
        }

        internal void AddGameData()
        {
            Logger.LogInfo($"Adding Game Data.");

            AddGameDataObject<PerformanceCookingUnlock>();

            Logger.LogInfo($"Done adding game data.");
        }
    }
}
