using DefaultMessager.Domain.Entities;
using DefaultMessager.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Domain.ViewModel.RelationModel
{
    public class RelationViewModel
    {
        public Guid AccountId1 { get; set; }
        public Guid AccountId2 { get; set; }
        public StatusRelation Status { get; set; }
    }
}
