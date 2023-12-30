﻿using KitchenData;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KitchenPerformanceCooking
{
    public static class References
    {
        // Patience phase sprites
        public static string SPRITE_PATIENCE_SERVICE = "<sprite name=\"service\">";
        public static string SPRITE_PATIENCE_WAITFORFOOD = "<sprite name=\"waitforfood\">";

        // Process sprites
        public static string SPRITE_PROCESS_CHOP = "<sprite name=\"chop\">";
        public static string SPRITE_PROCESS_KNEAD = "<sprite name=\"knead\">";
        public static string SPRITE_PROCESS_COOK = "<sprite name=\"cook\">";
        public static string SPRITE_PROCESS_BREW = "<sprite name=\"fill_coffee\">";

        // Restaurant Status
        public static RestaurantStatus PERFORMANCE_COOKING_STATUS = (RestaurantStatus)VariousUtils.GetID("Performance Cooking Status");
    }
}
