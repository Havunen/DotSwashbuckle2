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
    public partial class FootblandDistributionsoap
    {
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public List<FootblandsGroupsoap> FootblandsGroup { get; set; }

        /// <summary>
        /// XX-31-Keyboard
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public Numericsoap MaximumFootblandsSubmitqweNumeric { get; set; }

        /// <summary>
        /// XX-33-Keyboard
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public Numericsoap MaximumFootblandscreateedNumeric { get; set; }


    }
}
