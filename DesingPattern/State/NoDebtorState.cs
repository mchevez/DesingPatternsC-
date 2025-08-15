using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPattern.State
{
    public class NoDebtorState : IState
    {
        public void Action(CustomerContext customerContext, decimal amount)
        {
            if (amount <= customerContext.Reside)
            {
                customerContext.Discount(amount);
                Console.WriteLine($"Solicitud Permida Gasta {amount} y le queda de saldo {customerContext.Reside}");
                
                if (customerContext.Reside <= 0) {
                    customerContext.SetState(new DebtorState());
                }
            }
            else {
                Console.WriteLine($"No Ajusta con lo solicitado, "+
                    $"ya que tienes {customerContext.Reside}"+
                    $"y quieres gasta {amount}");
            }
        }
    }
}
