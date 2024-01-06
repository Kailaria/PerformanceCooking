using KitchenData;
using KitchenLib;
using KitchenLib.Logging;
using KitchenLib.Logging.Exceptions;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenMods;
using KitchenPerformanceCooking.Unlocks;
using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace KitchenPerformanceCooking
{
    public class Mod : BaseMod, IModSystem
    {
        public const string MOD_GUID = "com.kailaria.performancecooking";
        public const string MOD_NAME = "Performance Cooking";
        public const string MOD_VERSION = "0.1.0";
        public const string MOD_AUTHOR = "Kailaria";
        public const string MOD_GAMEVERSION = ">=1.1.8";

        public static AssetBundle Bundle;
        public static KitchenLogger Logger;

        public Mod() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        protected override void OnInitialise()
        {
            Logger.LogWarning($"{MOD_GUID} v{MOD_VERSION} in use!");
            SetVictorianStandardsBlockedBy();
        }

        protected override void OnUpdate()
        {
            var victorianStandards = (UnlockCard)GDOUtils.GetExistingGDO(UnlockCardReferences.LosePatienceInView);
            Logger.LogInfo($"Blocked by count in OnUpdate: {victorianStandards.BlockedBy.Count}");
        }

        protected override void OnPostActivate(KitchenMods.Mod mod)
        {
            Logger = InitLogger();
            AddGameData(mod);
        }

        internal void AddGameData(KitchenMods.Mod mod)
        {
            Logger.LogInfo($"Adding Game Data.");

            //Bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).FirstOrDefault() ?? throw new MissingAssetBundleException(MOD_GUID);

            AddGameDataObject<PerformanceCookingUnlock>();

            Logger.LogInfo($"Done adding game data.");
        }

        private void SetVictorianStandardsBlockedBy()
        {
            Logger.LogInfo("Make Victorian Standards be blocked by Performance Cooking.");
            Logger.LogInfo("Getting Performance Cooking GDO");
            var performanceCookingUnlock = GDOUtils.GetCastedGDO<UnlockCard, PerformanceCookingUnlock>();

            // TODO: See if changing to OnInit helps find Vicky
            Logger.LogInfo("Getting Vicky Standards GDO");
            var victorianStandards = (UnlockCard)GDOUtils.GetExistingGDO(UnlockCardReferences.LosePatienceInView);

            var vickyStanText = victorianStandards == null ? "null" : $"{victorianStandards}";
            Logger.LogInfo($"Perf Cook: {performanceCookingUnlock} -- VickyStan?: {vickyStanText}");
            if (performanceCookingUnlock != null && victorianStandards != null && victorianStandards.BlockedBy != null)
            {
                // Make Vicky Standards mutually exclusive from Performance Cooking, so that neither can be in the same restaurant.
                Logger.LogInfo($"Blocked by count before: {victorianStandards.BlockedBy.Count}");
                victorianStandards.BlockedBy.Add(performanceCookingUnlock);
                Logger.LogInfo($"Blocked by count after: {victorianStandards.BlockedBy.Count}");
            }
            else
            {
                Logger.LogWarning("Victorian Standards will not be blocked by Performance Cooking.");
            }

        }
    }
}
