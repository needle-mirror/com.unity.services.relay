//-----------------------------------------------------------------------------
// <auto-generated>
//     This file was generated by the C# SDK Code Generator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using UnityEngine.Scripting;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Unity.Services.Relay.Http;



namespace Unity.Services.Relay.Models
{
    /// <summary>
    /// Region model
    /// </summary>
    [Preserve]
    [DataContract(Name = "Region")]
    public class Region
    {
        /// <summary>
        /// Creates an instance of Region.
        /// </summary>
        /// <param name="id">The region ID used in allocation requests.</param>
        /// <param name="description">A human-readable description of the region. It can include geographical information such as the city name or country.</param>
        [Preserve]
        public Region(string id, string description)
        {
            Id = id;
            Description = description;
        }

        /// <summary>
        /// The region ID used in allocation requests.
        /// </summary>
        [Preserve]
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public string Id{ get; }
        /// <summary>
        /// A human-readable description of the region. It can include geographical information such as the city name or country.
        /// </summary>
        [Preserve]
        [DataMember(Name = "description", IsRequired = true, EmitDefaultValue = true)]
        public string Description{ get; }
    
    }
}

