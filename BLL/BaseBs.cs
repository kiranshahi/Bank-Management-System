using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BaseBs
    {
        public UserBs UserBs { get; set; }
        public OpenActBs OpenActBs { get; set; }
        public DepositBs DepositBs { get; set; }
        public WithdrawalBs WithdrawalBs { get; set; }
        public ChqIssueBs ChqIssueBs { get; set; }
        public ChqCancellationBs ChqCancellationBs { get; set; }
        public ActtypeBs ActtypeBs { get; set; }
        public LoanTypeBs LoanTypeBs { get; set; }
        public LoanBs LoanBs { get; set; }
        public BaseBs()
        {
            UserBs = new UserBs();
            OpenActBs = new OpenActBs();
            DepositBs = new DepositBs();
            WithdrawalBs = new WithdrawalBs();
            ChqIssueBs = new ChqIssueBs();
            ChqCancellationBs = new ChqCancellationBs();
            ActtypeBs = new ActtypeBs();
            LoanTypeBs = new LoanTypeBs();
            LoanBs = new LoanBs();
        }
    }
}