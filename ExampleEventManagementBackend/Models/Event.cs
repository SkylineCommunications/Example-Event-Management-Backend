using Skyline.DataMiner.SDM;
using System;
using System.Collections.Generic;

namespace Skyline.DataMiner.Utils.Examples.EventManager.Models
{

    [GenerateExposers]
    [SdmDomStorage("exampleventmgmt")]
    public class Event : SdmObject<Event>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public EventType Type { get; set; }

        public EventPriority Priority { get; set; }

        public List<Package> AdditionalPackages { get; set; } = new List<Package>();

    }
}
