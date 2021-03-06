﻿namespace AssessmentAnywhere.Services.AccountActivation
{
    using System;

    using AssessmentAnywhere.Services.Users;

    internal class AccountActivationService : IAccountActivationService
    {
        private readonly IAccountActivationRepo accountActivationRepo;

        private readonly IUserRepo userRepo;

        private readonly Action<IUser, IAccountActivation> beginActivation;

        public AccountActivationService()
        {
            this.accountActivationRepo = new AccountActivationRepo();
            this.userRepo = new UserRepo();
        }

        public AccountActivationService(Action<IUser, IAccountActivation> beginActivation)
            : this(new AccountActivationRepo(), new UserRepo(), beginActivation)
        {
        }

        public AccountActivationService(IAccountActivationRepo accountActivationRepo, IUserRepo userRepo, Action<IUser, IAccountActivation> beginActivation)
        {
            this.accountActivationRepo = accountActivationRepo;
            this.userRepo = userRepo;
            this.beginActivation = beginActivation;
        }

        public IAccountActivation BeginActivation(IUser userAccount)
        {
            return this.accountActivationRepo.CreateOrReplace(userAccount.Username);
        }

        public CompleteActivationResult TryCompleteActivation(string emailAddress, string code)
        {
            if (!this.accountActivationRepo.Contains(emailAddress))
            {
                return CompleteActivationResult.NotFound;
            }

            var accountActivation = this.accountActivationRepo.Open(emailAddress);
            if (accountActivation.ActivationCode != code)
            {
                return CompleteActivationResult.IncorrectCode;
            }

            var completed = accountActivation.TryComplete();
            if (!completed)
            {
                return CompleteActivationResult.Expired;
            }

            this.userRepo.Open(accountActivation.Username).Activate();

            return CompleteActivationResult.Success;
        }
    }
}
