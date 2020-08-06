using System;
using System.Collections.Generic;
using System.Text;
using ExercicioInterface.Entities;

namespace ExercicioInterface.Services
{
    class PaypalService : IPaymentService
    {

        private const double FeePercentage = 0.02;
        private const double MonthlyInterest = 0.01;

        public double PaymentFee(double amount)
        {
            return amount * FeePercentage;
        }

        public double Interest(double amount, int months)
        {
            return amount * MonthlyInterest * months;
        }
    }
}
