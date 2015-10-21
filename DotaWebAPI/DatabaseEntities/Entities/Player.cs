using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
