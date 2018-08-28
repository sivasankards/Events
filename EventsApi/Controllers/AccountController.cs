using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using EventsApi.Models;
using System.Web.Http.Cors;
using System.Web;

namespace EventsApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AccountController : ApiController
    {
        public static string con = ConfigurationManager.ConnectionStrings["EventCS"].ConnectionString;
        //string session = Convert.ToString(HttpContext.Current.Session);
        public HttpResponseMessage POSTRegisterUser(AccountModel model)
        {
            int affectedRows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("Usp_RegisterUser", conn);
                    sqlComm.Parameters.AddWithValue("@Username", model.Name);
                    sqlComm.Parameters.AddWithValue("@Password", model.Password);
                    sqlComm.Parameters.AddWithValue("@Email", model.Email);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    affectedRows = (int)sqlComm.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch(Exception ex)
            {

            }
            return Request.CreateResponse(HttpStatusCode.OK, affectedRows);
        }

        //[HttpPost]
        public HttpResponseMessage POSTLogin(LoginViewModel model)
        {
            DataSet ds = new DataSet();
            
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("Usp_VerifyUser", conn);
                    sqlComm.Parameters.AddWithValue("@Email", model.Email);
                    sqlComm.Parameters.AddWithValue("@Password", model.Password);                    
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;
                    da.Fill(ds);
                }             
            }
            catch (Exception ex)
            {

            }

            return Request.CreateResponse(HttpStatusCode.OK, ds);
        }

        public HttpResponseMessage POSTCreateEvent(EventInputModel model)
        {
            int affectedRows = 0;
            //if ()
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("Usp_CreateEvent", conn);
                    sqlComm.Parameters.AddWithValue("@Title", model.Title);
                    sqlComm.Parameters.AddWithValue("@StartDateTime", model.StartDateTime);
                    sqlComm.Parameters.AddWithValue("@Duration", model.Duration);
                    sqlComm.Parameters.AddWithValue("@Description", model.Description);
                    sqlComm.Parameters.AddWithValue("@Location", model.Location);
                    sqlComm.Parameters.AddWithValue("@IsPublic", model.IsPublic);
                    sqlComm.Parameters.AddWithValue("@UserId", model.UserId);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    affectedRows = (int)sqlComm.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return Request.CreateResponse(HttpStatusCode.OK, affectedRows);
        }

        public HttpResponseMessage POSTMyEvents(EventInputModel model)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("Usp_GetMyEvents", conn);
                    sqlComm.Parameters.AddWithValue("@UserId", model.UserId);                    
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;
                    da.Fill(ds);
                }
                
                //var PassedEvents = (from rw in ds.Tables[1].AsEnumerable()
                //                    select new EventViewModel()
                //                    {
                //                        Id = Convert.ToInt32(rw["ID"]),
                //                        Title = Convert.ToString(rw["Title"]),
                //                        StartDateTime = Convert.ToDateTime(rw["StartDateTime"]),
                //                        //Duration = TimeSpan.Parse(rw["Duration"])
                //                    }
            }
            catch (Exception ex)
            {

            }

            return Request.CreateResponse(HttpStatusCode.OK, ds);
        }
    }
}
