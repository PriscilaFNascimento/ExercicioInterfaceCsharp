
using ExercicioInterface.Entities;
using Microsoft.VisualBasic;
using System;

namespace ExercicioInterface.Services
{
    class ContractService
    {
        private IPaymentService _paymentService;

        public ContractService(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public void ProcessContract(Contract contract, int months)
        {
            double basicQuota = contract.TotalValue / (double)months;
            for (int i = 1; i <= months; i++)
            {
                double updatedQuota = basicQuota + _paymentService.Interest(basicQuota, i);
                double fullQuota = updatedQuota + _paymentService.PaymentFee(updatedQuota);
                DateTime dueDate = contract.Date.AddMonths(i);
                contract.AddInstallment(new Installment(dueDate, fullQuota));

            }
        }
    }
}
