﻿using ExileCore.PoEMemory.Components;
using ExileCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoPilot
{
    class Summons
    {
        internal int chaosElemental;
        internal int fireElemental;
        internal int iceElemental;
        internal int lightningGolem;
        internal int rockGolem;
        internal int boneGolem;
        internal int dropBearUniqueSummoned;
        internal int zombies;

        internal DateTime lastUpdate = DateTime.Now;
        
        internal void UpdateSummons()
        {
            if ((DateTime.Now - lastUpdate).TotalMilliseconds < 250)
                return;
            lastUpdate = DateTime.Now;

            chaosElemental = 0;
            fireElemental = 0;
            iceElemental = 0;
            lightningGolem = 0;
            rockGolem = 0;
            boneGolem = 0;
            dropBearUniqueSummoned = 0;
            zombies = 0;

            foreach(var obj in CoPilot.instance.localPlayer.GetComponent<Actor>().DeployedObjects.Where(x => x != null && x.Entity != null && x.Entity.IsAlive))
            {
                if (obj.Entity.Path.Contains("ChaosElemental"))
                    chaosElemental++;
                else if (obj.Entity.Path.Contains("FireElemental"))
                    fireElemental++;
                else if (obj.Entity.Path.Contains("IceElemental"))
                    iceElemental++;
                else if (obj.Entity.Path.Contains("LightningGolem"))
                    lightningGolem++;
                else if (obj.Entity.Path.Contains("RockGolem"))
                    rockGolem++;
                else if (obj.Entity.Path.Contains("BoneGolem"))
                    boneGolem++;
                else if (obj.Entity.Path.Contains("DropBearUniqueSummoned"))
                    dropBearUniqueSummoned++;
                else if (obj.Entity.Path.Contains("RaisedZombie"))
                    zombies++;
            }
        }
    }
}
