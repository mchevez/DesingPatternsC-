using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPattern.State
{
    public class CustomerContext
    {
        private IState _state;

        private decimal _reside;

        public decimal Reside
        {
            get { return _reside; }
            set { _reside = value; }
        }

        public CustomerContext()
        {
            _state = new NewState();
        }

        public void SetState(IState state) => _state = state;
        public IState GetState() => _state;
        public void Request(decimal amount) => _state.Action(this, amount);
        public void Discount(decimal amount) => _reside -= amount;
    }
}
