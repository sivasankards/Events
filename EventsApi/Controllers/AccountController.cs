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
            }
            catch (Exception ex)
            {

            }

            return Request.CreateResponse(HttpStatusCode.OK, ds);
        }

        public HttpResponseMessage POSTFriendsList(FriendsModel model)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("Usp_GetMyFriends", conn);
                    sqlComm.Parameters.AddWithValue("@UserId", model.UserId);
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

        public HttpResponseMessage POSTFriendRequest(FriendsModel model)
        {
            int affectedRows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("Usp_AddFriend", conn);
                    sqlComm.Parameters.AddWithValue("@UserId", model.UserId);
                    sqlComm.Parameters.AddWithValue("@FriendsId", model.FriendsId);
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

        public HttpResponseMessage POSTMyNotification(NotificationModel model)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("Usp_GetNotification", conn);
                    sqlComm.Parameters.AddWithValue("@UserId", model.UserId);
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

        public HttpResponseMessage POSTAcceptFriend(FriendsModel model)
        {
            int affectedRows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("Usp_AcceptFriend", conn);
                    sqlComm.Parameters.AddWithValue("@UserId", model.UserId);
                    sqlComm.Parameters.AddWithValue("@FriendsId", model.FriendsId);
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

        public HttpResponseMessage POSTInviteFriends(FriendsModel model)
        {
            int affectedRows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("Usp_InviteFriends", conn);
                    sqlComm.Parameters.AddWithValue("@UserId", model.UserId);
                    sqlComm.Parameters.AddWithValue("@FriendsId", model.FriendsList);
                    sqlComm.Parameters.AddWithValue("@EventId", model.EventId);
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

        public HttpResponseMessage POSTAcceptInvite(FriendsModel model)
        {
            int affectedRows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("Usp_AcceptInvite", conn);
                    sqlComm.Parameters.AddWithValue("@UserId", model.UserId);
                    sqlComm.Parameters.AddWithValue("@FriendsId", model.FriendsId);
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

        public HttpResponseMessage POSTEventDetails(EventInputModel model)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("Usp_GetEventDetails", conn);
                    sqlComm.Parameters.AddWithValue("@EventId", model.Id);
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

        public HttpResponseMessage POSTEditEvent(EventInputModel model)
        {
            int affectedRows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("Usp_EditEvent", conn);
                    sqlComm.Parameters.AddWithValue("@Title", model.Title);
                    sqlComm.Parameters.AddWithValue("@StartDateTime", model.StartDateTime);
                    sqlComm.Parameters.AddWithValue("@Duration", model.Duration);
                    sqlComm.Parameters.AddWithValue("@Description", model.Description);
                    sqlComm.Parameters.AddWithValue("@Location", model.Location);
                    sqlComm.Parameters.AddWithValue("@IsPublic", model.IsPublic);
                    sqlComm.Parameters.AddWithValue("@EventId", model.Id);
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

        public HttpResponseMessage POSTDeleteEvent(EventInputModel model)
        {
            int affectedRows = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(con))
                {
                    SqlCommand sqlComm = new SqlCommand("Usp_DeleteEvent", conn);
                    sqlComm.Parameters.AddWithValue("@EventId", model.Id);
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
    }
}
