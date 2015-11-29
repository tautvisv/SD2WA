using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseEntities.Entities
{
    public class Player : ObjectBase
    {
        public string Name { get; set; }
        public string TeamName { get; set; }
        public string TeamTag { get; set; }
        public string Sponsor { get; set; }
        public string FantasyRole { get; set; }
        public bool IsFinished { get; set; }
        [Required]
        public DateTime? LastModified { get; set; }
    }
}
