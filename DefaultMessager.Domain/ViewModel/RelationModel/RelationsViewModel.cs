using DefaultMessager.Domain.Enums;

namespace DefaultMessager.Domain.ViewModel.RelationModel
{
    public class RelationsViewModel
    {
        public Guid AccountId1 { get; set; }
        public Guid AccountId2 { get; set; }
        public StatusRelation Status { get; set; }
    }
}
