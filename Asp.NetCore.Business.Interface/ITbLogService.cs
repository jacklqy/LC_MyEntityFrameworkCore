using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Business.Interface
{
    public interface ITbLogService: IBaseService
    {
        public void DeleteCompanyAndUser(long Id);

    }
}
