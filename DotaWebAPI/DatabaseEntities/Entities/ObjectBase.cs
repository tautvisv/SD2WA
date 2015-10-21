﻿using System.ComponentModel.DataAnnotations;
using DatabaseEntities.Interfaces;
using Newtonsoft.Json;

namespace DatabaseEntities.Entities
{
    public class ObjectBase : IObject
    {
        [Key]
        [JsonProperty("id")]
        public int ID { get; set; }
    }
}
