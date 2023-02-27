using DefaultMessager.Domain.Entities;

namespace DefaultMessager.Domain.ViewModel.DescriptionAccountModel
{
    public class DescriptionAccountViewModel
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Patronymic { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Describe { get; set; }
        public string? AccountStatus { get; set; }
        public string? PathAvatar { get; set; }

        public DescriptionAccountViewModel(DescriptionAccount description)
        {
            Id = description.Id;
            Name = description.Name;
            Surname = description.Surname;
            Patronymic = description.Patronymic;
            Birthday = description.Birthday;
            Describe = description.Describe;
            AccountStatus = description.AccountStatus;
            PathAvatar = description.PathAvatar;
        }

        public DescriptionAccountViewModel()
        {
        }
    }
}
