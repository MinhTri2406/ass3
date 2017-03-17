using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QLBanhang.Model
{
    class ConnectToSQL
    {
        #region Availible
        private SqlConnection Connect;
        private SqlCommand _cmd;
        private string StrCon;
        private string _error;

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

        public SqlConnection Connection
        {
            get { return Connect; }
            //set { Connect = value; }
        }

        public SqlCommand CMD
        {
            get { return _cmd; }
            set { _cmd = value; }
        }
        #endregion

        //Constructor:
        #region Construstor
        public ConnectToSQL()
        {

            StrCon = @"Data Source = TRI-PC;Initial Catalog = QL_BanHang;Integrated Security=True"; //String connection to connect to SQL
            
            Connect = new SqlConnection(StrCon);
        }
        #endregion

        #region Methods

        //Open the database:
        public bool OpenConn()
        {
            try
            {
                if (Connect.State == ConnectionState.Closed)
                    Connect.Open();
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return false;
            }
            return true;
        }

        //Close the database:
        public bool CloseConn()
        {
            try
            {
                if (Connect.State == ConnectionState.Open)
                    Connect.Close();
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return false;
            }
            return true;
        }
        #endregion
    }
}
