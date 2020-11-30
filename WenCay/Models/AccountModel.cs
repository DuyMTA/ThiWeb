using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WenCay.Models.Entity;

namespace WenCay.Models
{
    public class AccountModel
    {
        private ModelWebCay context = null;
        private AccountModel()
        {
            context = new ModelWebCay();
        }
    }
}