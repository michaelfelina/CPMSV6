﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CPMS.BL;
using CPMS.Rep;
using Common.Methods;

namespace CPMS.Web.Controllers
{
    public class UserAccountController : Controller
    {
        readonly UserAccountsRep userAccountRep = new UserAccountsRep();
        // GET: UserAccount
        public ActionResult Index(UserAccountType accountType)
        {
            new OperationResult();
            var userAccounts = new List<UserAccount>();
            userAccountRep.GetAll(accountType, out userAccounts);
            if (accountType == UserAccountType.Admin)
                @ViewBag.Title = "Administrators";
            else
                @ViewBag.Title = "Cashiers";

            @ViewBag.AccountType = accountType;
            return View(userAccounts);
        }

        public ActionResult Edit(int IDNo, UserAccountType accountType)
        {
            var result = new OperationResult();
            var userAccount = new UserAccount();
            result = userAccountRep.GetInfo_ByID(IDNo, accountType, out userAccount);
            return View(userAccount);
        }

        public ActionResult Create(UserAccountType accountType)
        {
            @ViewBag.AccountType = accountType;
            return View();
        }
    }
}