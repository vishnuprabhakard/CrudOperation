using CrudOperation.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperation.Dal
{
    public class EmployeService
    {
        public string connectionstring = "Data Source=DESKTOP-531QTCP;Initial catalog=vishnu; user id =sa;password=Anaiyaan@123";

        public List<Employe> GetAll()
        {
            var connection = new SqlConnection(connectionstring);
            connection.Open();
           var result = connection.Query<Employe>("select * from Employedetailes").ToList();
            connection.Close();
            return result;
        }


        public Employe GetById(int id)
        {
            try
            {
                var connection = new SqlConnection(connectionstring);
                connection.Open();
                var result = connection.Query<Employe>($"select * from Employedetailes where userId={id}").FirstOrDefault();
                connection.Close();
                return result;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public void Create(Employe add)
        {
            try
            {
                var connection = new SqlConnection(connectionstring);
                connection.Open();
                var result = connection.Execute($"insert into Employedetailes values ('{add.Fullname}','{add.EmailID}',{add.PhoneNumber},'{add.Password}','{add.RetypePassword}','{add.City}','{add.country}','{add.Status}')");
                connection.Close();
               
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public void  update(int id, Employe update)
        {

        }



    }
}
