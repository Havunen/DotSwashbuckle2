// ------------------------------------------------------------------------------
//  <Autogenerated>
//    Generated By Dummy
//  </Autogenerated>
// ------------------------------------------------------------------------------

using System.Collections.Generic;
using Dummy.Attributes;
using Newtonsoft.Json;

namespace Dummy.Dumbs.Contracts
{
    [EDummy]
    public partial class Criterionsoap
    {
        /// <summary>
        /// XX-40-Footbland
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public Indicabusinessrsoap SecondStageIndicabusinessr { get; set; }

        /// <summary>
        /// XX-747-Footbland
        /// XX-747-Footbland-shake
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public rubysoap CriterionTyperuby { get; set; }

        /// <summary>
        /// XX-748-Footbland
        /// XX-748-Footbland-shake
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public rubysoap CalculationExpressionruby { get; set; }

        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public List<Textsoap> Name {get; set;}

        /// <summary>
        /// XX-750-Footbland
        /// XX-750-Footbland-Cat
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public List<Textsoap> Description { get; set; }

        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public List<Parametersoap> CriterionParameter { get; set; }


    }
}
