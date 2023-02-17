using DefaultMessager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Domain.ViewModel.LikeModel
{
    public class LikeViewModel
    {
        public Guid? Id { get; set; }
        public Guid PostId { get; set; }
        public Guid AccountId { get; set; }
    }
}
