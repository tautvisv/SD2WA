using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class WinrateAgaintOtherHeroDto : DtoBase
    {
        public int? MainHeroId { get; set; }
        [Required(ErrorMessage = "EnemyHeroId is Required")]
        public int? EnemyHeroId { get; set; }
        public DateTime? DateFrom { get; set; }
        public new bool IsValid()
        {
            return base.IsValid() && EnemyHeroId != null;
        }

        public new bool IsValidThrowable()
        {
            if (!base.IsValidThrowable() || !IsValid())
            {
                throw new ArgumentNullException("EnemyHeroId");
            }
            return true;
        }
    }
}
