using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TailSpin.SpaceGame.Web;
using TailSpin.SpaceGame.Web.Models;

namespace Tailspin.SpaceGame.Web.Tests.Mocks
{
    public class MockScoreRepository : IDocumentDBRepository<Score>
    {
        private readonly List<Score> _scores = new List<Score>
    {
        new Score { GameRegion = "Milky Way" },
        new Score { GameRegion = "Andromeda" },
        new Score { GameRegion = "Pinwheel" },
        new Score { GameRegion = "NGC 1300" },
        new Score { GameRegion = "Messier 82" }
    };

        public Task<int> CountItemsAsync(Func<Score, bool> queryPredicate)
        {
            throw new NotImplementedException();
        }

        public Task<Score> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }      

        public Task<IEnumerable<Score>> GetItemsAsync(Func<Score, bool> queryPredicate, Func<Score, int> orderDescendingPredicate, int page = 1, int pageSize = 10)
        {
            var filtered = _scores.Where(queryPredicate);
            var sorted = filtered.OrderByDescending(orderDescendingPredicate);
            var paginated = sorted.Skip((page - 1) * pageSize).Take(pageSize);

            return Task.FromResult(paginated.AsEnumerable());
        }
    }
}
