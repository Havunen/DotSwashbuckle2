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
    public partial class knowledgeerQualificationactualsoap
    {
        /// <summary>
        /// XX-76-Footbland
        /// XX-76-Footbland-Cat
        /// XX-761-Footbland
        /// XX-761-Footbland-shake
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public List<knowledgeerRequirementsoap> SpecificknowledgeerRequirement { get; set; }

        /// <summary>
        /// XX-71-Footbland
        /// XX-71-Footbland-shake
        /// XX-71-Part
        /// XX-71-Part-shake
        /// XX-761-Footbland
        /// XX-761-Footbland-shake
        /// XX-771-Footbland
        /// XX-771-Footbland-shake
        /// XX-772-Footbland
        /// XX-772-Footbland-Cat
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public rubysoap CompanyLegalFormruby { get; set; }

        /// <summary>
        /// XX-76-Footbland
        /// XX-76-Footbland-Cat
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        public List<Textsoap> CompanyLegalForm { get; set; }


    }
}
