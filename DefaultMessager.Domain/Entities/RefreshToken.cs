using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultMessager.Domain.Entities
{
    public class RefreshToken
    {
        public Guid? Id { get; set; }
        public Guid AccountId { get; set; }
        public string Token { get; set; } = null!;
        public Account? Account { get; set; }

        public RefreshToken(Guid accountId, string token)
        {
            AccountId = accountId;
            Token = token;
        }
    }
}
