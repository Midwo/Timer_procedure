using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apka_procedury
{
    class claseprocedure
    {

    public static   void procedure(string x1)
        {

            try
            {
                System.Data.SqlClient.SqlConnection M1conn;
                M1conn = new SqlConnection();
                M1conn.ConnectionString = yourData.connetionStringToDataBase;
                M1conn.Open();
                System.Data.SqlClient.SqlCommand M1command = new SqlCommand();
                M1command.Connection = M1conn;
                M1command.CommandText = "" + x1 + "";
                M1command.ExecuteNonQuery();
                M1conn.Close();
            }
            catch(Exception ex)
            {
                Error.SaveErrorLogging(ex);
                Error.ReadError();
                MessageBox.Show(ex.Message, "Error");
                Error.statusError = 1;
            }

        }

    }
}
