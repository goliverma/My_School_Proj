using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataProvider
{
    public interface IDataProvider
    {
        DataTable ConnectDataBaseWithParam(Collection<SqlParameter> param, string Procuder);
        DataTable ConnectDataBase(string Procuder);
        bool SaveDataEntity(Collection<SqlParameter> param, string Procuder);
    }
}
