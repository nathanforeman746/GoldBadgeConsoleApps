using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    public class ClaimsRepo
    {
        private Queue<Claim> _claims = new Queue<Claim>();

        //Create
        public void AddClaim(Claim claim)
        {
            _claims.Enqueue(claim);
        }

        //Read
        public Queue<Claim> ViewClaimList()
        {
            return _claims;
        }
    }
}
