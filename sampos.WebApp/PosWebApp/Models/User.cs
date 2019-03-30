using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

// data acccess
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace Angularjs.UIRouting.WebApp.Models
 
{
    public class User
    {
        public String user_id{get; set;}
        public String user_name{get; set;}
        public String user_phone{get; set;}
        public int user_level{get; set;}
        public String user_password{get; set;}
        public String address{get; set;}
        public String district{get; set;}
        public String post{get; set;}
        public String country{get; set;}
        public String mobile_phone{get; set;}
        public String e_mail{get; set;}
        public String sex{get; set;}
        public Nullable<System.DateTime> date_of_birth{get; set;}
        public Nullable<System.DateTime> date_hired{get; set;}
        public Nullable<System.DateTime> date_terminate{get; set;}
        public String remarks{get; set;}
        public String commission_id{get; set;}
        //public int u_photo{get; set;}
        public String modAceess{get; set;}
        public String file_name{get; set;}
        public int? add { get; set; }
    }

    #region userModel
    public class UserModel
    {
        public User _user { get; set; }
        public List<User> _User { get; set; }

        #region insert

        public bool InsertUser()
        {

            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();

                strSQL = "INSERT INTO users  ( user_id , user_name , user_phone, user_level , user_password, address ";
                strSQL = strSQL + ", district , post  , country  , mobile_phone ";
                strSQL = strSQL + ", e_mail  , sex, date_of_birth  , date_hired ";
                strSQL = strSQL + ", date_terminate  , remarks     , commission_id  ,  modAceess , file_name  )";
                strSQL = strSQL + " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";


                if (string.IsNullOrEmpty(_user.user_id))
                {
                    _mycommand.Parameters.AddWithValue("@user_id", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@user_id", _user.user_id);
                }


                if (string.IsNullOrEmpty(_user.user_name))
                {
                    _mycommand.Parameters.AddWithValue("@user_name", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@user_name", _user.user_name);
                }


                if (string.IsNullOrEmpty(_user.user_phone))
                {
                    _mycommand.Parameters.AddWithValue("@user_phone", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@user_phone", _user.user_phone);
                }


                
                 _mycommand.Parameters.AddWithValue("@user_level", _user.user_level);
                


                if (string.IsNullOrEmpty(_user.user_password))
                {
                    _mycommand.Parameters.AddWithValue("@user_password", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@user_password", _user.user_password);
                }


                if (string.IsNullOrEmpty(_user.address))
                {
                    _mycommand.Parameters.AddWithValue("@address", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@address", _user.address);
                }


                if (string.IsNullOrEmpty(_user.district))
                {
                    _mycommand.Parameters.AddWithValue("@district", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@district", _user.district);
                }


                if (string.IsNullOrEmpty(_user.post))
                {
                    _mycommand.Parameters.AddWithValue("@post", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@post", _user.post);
                }


                if (string.IsNullOrEmpty(_user.country))
                {
                    _mycommand.Parameters.AddWithValue("@country", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@country", _user.country);
                }


                if (string.IsNullOrEmpty(_user.mobile_phone))
                {
                    _mycommand.Parameters.AddWithValue("@mobile_phone", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@mobile_phone", _user.mobile_phone);
                }


                if (string.IsNullOrEmpty(_user.e_mail))
                {
                    _mycommand.Parameters.AddWithValue("@e_mail", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@e_mail", _user.e_mail);
                }


                if (string.IsNullOrEmpty(_user.sex))
                {
                    _mycommand.Parameters.AddWithValue("@sex", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@sex", _user.sex);
                }


                if (_user.date_of_birth==null)
                {
                    _mycommand.Parameters.AddWithValue("@date_of_birth", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@date_of_birth", _user.date_of_birth);
                }


                if (_user.date_hired ==null)
                {
                    _mycommand.Parameters.AddWithValue("@date_hired", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@date_hired", _user.date_hired);
                }

                

                if (_user.date_terminate ==null)
                {
                    _mycommand.Parameters.AddWithValue("@date_terminate", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@date_terminate", _user.date_terminate);
                }


                if (string.IsNullOrEmpty(_user.remarks))
                {
                    _mycommand.Parameters.AddWithValue("@remarks", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@remarks", _user.remarks);
                }


                if (string.IsNullOrEmpty(_user.commission_id))
                {
                    _mycommand.Parameters.AddWithValue("@commission_id", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@commission_id", _user.commission_id);
                }




                if (string.IsNullOrEmpty(_user.modAceess))
                {
                    _mycommand.Parameters.AddWithValue("@modAceess", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@modAceess", _user.modAceess);
                }


                if (string.IsNullOrEmpty(_user.file_name))
                {
                    _mycommand.Parameters.AddWithValue("@file_name", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@file_name", _user.file_name);
                }





                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = strSQL;
                _mycommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("Insert sales commission", e);
                return false;
            }
            return true;
        }
        #endregion end insert

        #region update
        public bool UpdateUser()
        {
            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                
                string _gid = _user.user_id;
             

                #region sql update


                 strSQL = "Update users set";
        
        
                    strSQL = strSQL + " user_name=@user_name ,";
                    strSQL = strSQL + " user_level=@user_level ,";
                    strSQL = strSQL + " Address=@Address ,";
                    strSQL = strSQL + " district= @district ,";
                    strSQL = strSQL + " post= @post ,";
                    strSQL = strSQL + " country =@country,";
                    strSQL = strSQL + " user_phone =@User_phone";
                    strSQL = strSQL + " e_mail=@e_mail,";
                    strSQL = strSQL + " Sex =@Sex,";
                    strSQL = strSQL + " date_of_birth =@CDate(date_of_birth,";
                    strSQL = strSQL + " date_hired = @CDate(date_hired) ,";
                    strSQL = strSQL + " date_terminate =@date_terminate,";
                    strSQL = strSQL + " remarks = @remarks ,";
                    strSQL = strSQL + " Commission_id =@Commission_id,";            
                    strSQL = strSQL + " file_name =@file_name ";
                    strSQL = strSQL + " user_password =@User_password ";
                    strSQL = strSQL + " where user_id='" + _gid + "'";

#endregion









                #region users update

                //if (string.IsNullOrEmpty(_user.user_id))
                //{
                //    _mycommand.Parameters.AddWithValue("@user_id", DBNull.Value);
                //}
                //else
                //{
                //    _mycommand.Parameters.AddWithValue("@user_id", _user.user_id);
                //}


                if (string.IsNullOrEmpty(_user.user_name))
                {
                    _mycommand.Parameters.AddWithValue("@user_name", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@user_name", _user.user_name);
                }


                if (string.IsNullOrEmpty(_user.user_phone))
                {
                    _mycommand.Parameters.AddWithValue("@user_phone", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@user_phone", _user.user_phone);
                }



                _mycommand.Parameters.AddWithValue("@user_level", _user.user_level);



                if (string.IsNullOrEmpty(_user.user_password))
                {
                    _mycommand.Parameters.AddWithValue("@user_password", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@user_password", _user.user_password);
                }


                if (string.IsNullOrEmpty(_user.address))
                {
                    _mycommand.Parameters.AddWithValue("@address", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@address", _user.address);
                }


                if (string.IsNullOrEmpty(_user.district))
                {
                    _mycommand.Parameters.AddWithValue("@district", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@district", _user.district);
                }


                if (string.IsNullOrEmpty(_user.post))
                {
                    _mycommand.Parameters.AddWithValue("@post", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@post", _user.post);
                }


                if (string.IsNullOrEmpty(_user.country))
                {
                    _mycommand.Parameters.AddWithValue("@country", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@country", _user.country);
                }


                if (string.IsNullOrEmpty(_user.mobile_phone))
                {
                    _mycommand.Parameters.AddWithValue("@mobile_phone", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@mobile_phone", _user.mobile_phone);
                }


                if (string.IsNullOrEmpty(_user.e_mail))
                {
                    _mycommand.Parameters.AddWithValue("@e_mail", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@e_mail", _user.e_mail);
                }


                if (string.IsNullOrEmpty(_user.sex))
                {
                    _mycommand.Parameters.AddWithValue("@sex", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@sex", _user.sex);
                }


                if (_user.date_of_birth == null)
                {
                    _mycommand.Parameters.AddWithValue("@date_of_birth", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@date_of_birth", _user.date_of_birth);
                }


                if (_user.date_hired == null)
                {
                    _mycommand.Parameters.AddWithValue("@date_hired", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@date_hired", _user.date_hired);
                }



                if (_user.date_terminate == null)
                {
                    _mycommand.Parameters.AddWithValue("@date_terminate", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@date_terminate", _user.date_terminate);
                }


                if (string.IsNullOrEmpty(_user.remarks))
                {
                    _mycommand.Parameters.AddWithValue("@remarks", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@remarks", _user.remarks);
                }


                if (string.IsNullOrEmpty(_user.commission_id))
                {
                    _mycommand.Parameters.AddWithValue("@commission_id", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@commission_id", _user.commission_id);
                }




                if (string.IsNullOrEmpty(_user.modAceess))
                {
                    _mycommand.Parameters.AddWithValue("@modAceess", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@modAceess", _user.modAceess);
                }


                if (string.IsNullOrEmpty(_user.file_name))
                {
                    _mycommand.Parameters.AddWithValue("@file_name", DBNull.Value);
                }
                else
                {
                    _mycommand.Parameters.AddWithValue("@file_name", _user.file_name);
                }




                #endregion users update






                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = strSQL;
                _mycommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("Update users", e);
                return false;
            }
            return true;

        }
        #endregion end update


        #region delete
        public bool deleteUser(string _userid)
        {


            string strSQL;

            try
            {
                OleDbCommand _mycommand = new OleDbCommand();

                OleDbDataAdapter _myadapter = new OleDbDataAdapter();
                
                strSQL = "delete from users where user_Id='" + _userid + "'";


                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = strSQL;
                _mycommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                samposoapp.ErrorLog.ErrorLog.ccException("Delete commission", e);
                return false;
            }
            return true;


        }

        #endregion end delete

        #region getuser
        
        public void GetUser(string id)
        {

            List<User> _gList = new List<User>();
            OleDbCommand _mycommand = new OleDbCommand();
            DataTable _mydatatable = new DataTable();

            OleDbDataAdapter _myadapter = new OleDbDataAdapter();
            _mydatatable = null;
            string _query;
            DataSet _ds = new DataSet();
            _query = "";

            try
            {

                if (id.Length == 0)
                {
                    _query = "select * from users order by user_Id";

                    
            

                }
                else
                {
                    _query = "select * from users where user_name ='" + id + "'";
                }
                OleDbConnection _conn = new OleDbConnection();
                _conn = samposoapp.db.SqlDatabaseUtility.GetConnection_db();
                _mycommand.Connection = _conn;
                _mycommand.CommandType = CommandType.Text;
                _mycommand.CommandText = _query;
                _mycommand.ExecuteNonQuery();


                _myadapter.SelectCommand = _mycommand;
                _myadapter.Fill(_ds);
                _mydatatable = _ds.Tables[0];


                User g;
                foreach (DataRow dr in _mydatatable.Rows)
                {

                    g = new User();
                    g.user_id = dr["user_id"].ToString();
                    g.user_name = dr["user_name"].ToString();
                    g.user_phone = dr["user_phone"].ToString();
                    g.user_level =int.Parse(dr["user_level"].ToString());
                    g.user_password = dr["user_password"].ToString();
                    g.address = dr["address"].ToString();
                    g.district = dr["district"].ToString();
                    g.post = dr["post"].ToString();
                    g.country = dr["country"].ToString();
                    g.mobile_phone = dr["mobile_phone"].ToString();
                    g.e_mail = dr["e_mail"].ToString();
                    g.sex = dr["sex"].ToString();

                    if (dr["date_of_birth"] == DBNull.Value) { g.date_of_birth = null; }
                    else
                    {
                        g.date_of_birth = DateTime.Parse(dr["date_of_birth"].ToString());
                    }


                    if (dr["date_hired"] == DBNull.Value) { g.date_hired = null; }
                    else
                    {
                        g.date_hired = DateTime.Parse(dr["date_hired"].ToString());
                    }

                    if (dr["date_terminate"] == DBNull.Value) { g.date_terminate = null; }
                    else
                    {
                        g.date_terminate = DateTime.Parse(dr["date_terminate"].ToString());
                    }
                    //g.date_of_birth = dr["date_of_birth"].ToString();
                    //g.date_hired = dr["date_hired"].ToString();
                    //g.date_terminate = dr["date_terminate"].ToString();
                    g.remarks = dr["remarks"].ToString();
                    g.commission_id = dr["commission_id"].ToString();
                    //g.u_photo = dr["u_photo"].ToString();
                    g.modAceess = dr["modAceess"].ToString();
                    g.file_name = dr["file_name"].ToString();
                    


                    _gList.Add(g);

                }

                _User = _gList.ToList();



            }
            catch (SqlException e)
            {
                //   return _result;

                samposoapp.ErrorLog.ErrorLog.ccException("Load users", e);
                //samposoapp.ErrorLog.ErrorLog.ccLog(e.Message);

                _mydatatable = null;
                // blist = null;


            }

            // return blist;
        }

        #endregion
    }
    #endregion
}