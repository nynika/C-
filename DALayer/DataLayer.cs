using DALayer;
using EnitityLayer.BusinessModels;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;
using System.Text;


namespace DALayer
{
    public class DataLayer
    {
        #region Initialization

        protected SqlDatabase db;
        protected SqlDatabase db_Master;
        protected SqlDatabase db_Institution;
        protected SqlDatabase db_Business;
        protected SqlDatabase db_RMC_IP;
        protected SqlDatabase db_Inventory;
        protected SqlDatabase db_SQLMaster;
        protected SqlDatabase db_SQLMasterTest;
        protected SqlDatabase db_PACS_Interface;
        protected SqlDatabase db_Laboratory;
        protected SqlDatabase db_Radiology;
        protected SqlDatabase db_HelpDeskIT;
        protected SqlDatabase db_HelpDesk;
        protected SqlDatabase db_Que;
        protected SqlDatabase db_Rimc2019;
        protected SqlDatabase db_R012424;
        protected SqlDatabase db_Image_Upload;
        protected SqlDatabase db_RMC_PACS_Interface;
        protected SqlDatabase db_RMC_EMR;
        protected SqlDatabase db_PatientPortal;

        //private string procedure = "";

        public DataLayer()
        {
            //string CON = ConfigurationManager.AppSettings["ConnectionString"];
            //db = new SqlDatabase(CON);
            db = new SqlDatabase(ConfigurationManager.AppSettings["ConnectionString"]);
            db_Master = new SqlDatabase(ConfigurationManager.AppSettings["CStrRIMC_Master"]);
            db_Institution = new SqlDatabase(ConfigurationManager.AppSettings["CStrRIMC_Institution"]);
            db_RMC_IP = new SqlDatabase(ConfigurationManager.AppSettings["CStrRIMC_IP"]);
            db_Inventory = new SqlDatabase(ConfigurationManager.AppSettings["CStrRIMC_Inventory"]);
            db_Que = new SqlDatabase(ConfigurationManager.AppSettings["CStrDWQueue"]);
            db_HelpDeskIT = new SqlDatabase(ConfigurationManager.AppSettings["CStrRIMC_HelpDesk_IT"]);
            db_HelpDesk = new SqlDatabase(ConfigurationManager.AppSettings["CStrRIMC_HelpDesk"]);
            db_R012424 = new SqlDatabase(ConfigurationManager.AppSettings["cstrdwR012424"]);
            db_R012424 = new SqlDatabase(ConfigurationManager.AppSettings["cstrdwR012424"]);
            db_Image_Upload = new SqlDatabase(ConfigurationManager.AppSettings["cstrdwImage_Upload"]);
            db_RMC_PACS_Interface = new SqlDatabase(ConfigurationManager.AppSettings["cstrdwRMC_PACS_Interface"]);
            db_RMC_EMR = new SqlDatabase(ConfigurationManager.AppSettings["cstrdwRMC_EMR"]);
            db_Laboratory = new SqlDatabase(ConfigurationManager.AppSettings["CStrRIMC_Laboratory"]);
            db_Radiology = new SqlDatabase(ConfigurationManager.AppSettings["CStrRIMC_Radiology"]);
            db_Rimc2019 = new SqlDatabase(ConfigurationManager.AppSettings["CStr_RIMC2019"]);
            db_PatientPortal = new SqlDatabase(ConfigurationManager.AppSettings["CStr_PatientPortal"]);
        }

        #endregion

        public DataSet GetLoginData(reqLogin request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.Login))
                {
                    param = new SqlParameter("@UserId", request.userID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Password", request.password);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getUserLogin(reqUserLogin request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_HelpDeskIT.GetStoredProcCommand(MediDBConstants.UserLogin))
                {
                    param = new SqlParameter("@EmpId", request.EmpId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Password", request.Password);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_HelpDeskIT.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet patLogin(reqpatLogin request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.Sp_patLogin))
                {
                    param = new SqlParameter("@UserId", request.UserId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Password", request.Password);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet SaveUser_login(reqSaveLogin request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_HelpDeskIT.GetStoredProcCommand(MediDBConstants.SaveUserLogin))
                {

                   
                    param = new SqlParameter("@EmpId", request.EmpId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@UHID", request.UHID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_HelpDeskIT.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        

        public DataSet Get_HouseKeepingList_Save(ReqHouseKeepingList request)

        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_RMC_IP.GetStoredProcCommand(MediDBConstants.House_Keeping_List_Save))
                {
                    param = new SqlParameter("@Cot_code", request.Cot_code);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@WashRoom_code", request.WashRoom_code);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Fridge_code", request.Fridge_code);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Flooring_code", request.Flooring_code);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Mop_code", request.Mop_code);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Floorcleaning_code", request.Floorcleaning_code);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Bedsheet_code", request.Bedsheet_code);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Couch_code", request.Couch_code);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", request.Remarks);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreateID", request.CreateID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);



                    ds = db_RMC_IP.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;

        }


        public DataSet Get_RestRoomCheckList_Save(ReqRestRoomList request)

        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_RMC_IP.GetStoredProcCommand(MediDBConstants.RestRoom_Check_List_Save))
                {
                    param = new SqlParameter("@WC_Code", request.WC_Code);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Floor_Mopping", request.Floor_Mopping);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Walls", request.Walls);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@DustBin_Clearence", request.DustBin_Clearence);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Wash_Basin", request.Wash_Basin);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Mirror", request.Mirror);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Door", request.Door);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@HandWash_Liquid", request.HandWash_Liquid);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Urine_StoolSampleBox", request.Urine_StoolSampleBox);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Urinal_Basin", request.Urinal_Basin);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@HRT_Roll", request.HRT_Roll);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Door_Mat", request.Door_Mat);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Floor_Trap", request.Floor_Trap);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@HK_Sign", request.HK_Sign);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Supervisor_Sign", request.Supervisor_Sign);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", request.Remarks);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreateID", request.CreateID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);



                    ds = db_RMC_IP.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;

        }
        public DataSet Get_Patient_Portal(Patient_Portal request)

        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.Portal_Patient_dTL))
                {
                    param = new SqlParameter("@Salutations", request.Salutation);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@FirstName", request.FirstName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@LastName", request.LastName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Gender", request.Gender);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@DOB", request.DOB);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Age", request.Age);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@EmploymentStatus", request.EmploymentStatus);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@MaritalStatus", request.MaritalStatus);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Nationality", request.Nationality);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@EmergencyContactType", request.EmergencyContactType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@EmergencyContactName", request.EmergencyContactName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@EmergencyContactNumber", request.EmergencyContactNumber);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@IdType", request.IdType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@IdNumber", request.IdNumber);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@PreferredLanguage", request.PreferredLanguage);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@SpecialAssistance", request.SpecialAssistance);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@BloodGroup", request.BloodGroup);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReferralSource", request.ReferralSource);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@MobileNumber", request.MobileNumber);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@EmailId", request.EmailId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Country", request.Country);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Pincode", request.Pincode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@State", request.State);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@City", request.City);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Area", request.Area);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@DoorNoAppartmentName", request.DoorNoAppartmentName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StreetLocality", request.StreetLocality);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ChickenPox", request.ChickenPox);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Measles", request.Measles);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Mumps", request.Mumps);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Rubella", request.Rubella);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Diarrhea", request.Diarrhea);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@TB", request.TB);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Cough", request.Cough);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Rashes", request.Rashes);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Travel", request.Travel);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Flu", request.Flu);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@HealthCareWrker", request.HealthCareWrker);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@RecentDisease", request.RecentDisease);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Religion", request.Religion);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@idproof", request.idproof);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@patType", request.pattype);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    //param = new SqlParameter("@ImG", request.ImG);
                    //param.Direction = ParameterDirection.Input;
                    //param.DbType = DbType.String;
                    //Cmd.Parameters.Add(param);

                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet Get_Patient_Portal_MHC(Patient_Portal request)

        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.Get_Patient_Portal_MHC))
                {
                    param = new SqlParameter("@Salutations", request.Salutation);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@FirstName", request.FirstName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@LastName", request.LastName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Gender", request.Gender);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@DOB", request.DOB);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Age", request.Age);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@EmploymentStatus", request.EmploymentStatus);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@MaritalStatus", request.MaritalStatus);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Nationality", request.Nationality);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@EmergencyContactType", request.EmergencyContactType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@EmergencyContactName", request.EmergencyContactName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@EmergencyContactNumber", request.EmergencyContactNumber);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@IdType", request.IdType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@IdNumber", request.IdNumber);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@PreferredLanguage", request.PreferredLanguage);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@SpecialAssistance", request.SpecialAssistance);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@BloodGroup", request.BloodGroup);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReferralSource", request.ReferralSource);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@MobileNumber", request.MobileNumber);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@EmailId", request.EmailId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Country", request.Country);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Pincode", request.Pincode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@State", request.State);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@City", request.City);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Area", request.Area);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@DoorNoAppartmentName", request.DoorNoAppartmentName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StreetLocality", request.StreetLocality);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ChickenPox", request.ChickenPox);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Measles", request.Measles);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Mumps", request.Mumps);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Rubella", request.Rubella);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Diarrhea", request.Diarrhea);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@TB", request.TB);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Cough", request.Cough);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Rashes", request.Rashes);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Travel", request.Travel);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Flu", request.Flu);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@HealthCareWrker", request.HealthCareWrker);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@RecentDisease", request.RecentDisease);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Religion", request.Religion);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@idproof", request.idproof);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;

        }
        public DataSet GetPatientDet_MobNo(string MobileNo)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_Image_Upload.GetStoredProcCommand(MediDBConstants.Get_Patient_Details))
                {
                    //db_Institution.AddInParameter(Cmd, "recordCount", DbType.Int32);
                    //db_Institution.AddInParameter(Convert.ToDateTime(ApptDate), "@ApptDate", DbType.DateTime);
                    param = new SqlParameter("@MobileNo", MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);
                    //Cmd.Parameters.Add("@APPDate", SqlDbType.VarChar).Value = txtFirstName.Text;
                    //Cmd.Parameters.Add("@ConsId", SqlDbType.VarChar).Value = txtLastName.Text;
                    Cmd.CommandTimeout = 30;
                    ds = db_Image_Upload.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet InsertUpdateOTP_portal(string RandomNumber, string MobileNo)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_Image_Upload.GetStoredProcCommand(MediDBConstants.InsertUpdateOTP_Portal))
                {
                    ////param = new SqlParameter("@OTP_RefID", RefId);
                    ////param.Direction = ParameterDirection.Input;
                    ////param.DbType = DbType.String;
                    ////Cmd.Parameters.Add(param);

                    param = new SqlParameter("@OTP_MobileNo", MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Otp", RandomNumber);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    //////param = new SqlParameter("@DoctorId", DoctorId);
                    //////param.Direction = ParameterDirection.Input;
                    //////param.DbType = DbType.Int64;
                    //////Cmd.Parameters.Add(param);

                    //////param = new SqlParameter("@APPStartDate", AppStartDate);
                    //////param.Direction = ParameterDirection.Input;
                    //////param.DbType = DbType.String;
                    //////Cmd.Parameters.Add(param);

                    //////param = new SqlParameter("@APPEndDate", AppEndDate);
                    //////param.Direction = ParameterDirection.Input;
                    //////param.DbType = DbType.String;
                    //////Cmd.Parameters.Add(param);

                    //////param = new SqlParameter("@PaymentStatus", PaymentStatus);
                    //////param.Direction = ParameterDirection.Input;
                    //////param.DbType = DbType.String;
                    //////Cmd.Parameters.Add(param);

                    //////param = new SqlParameter("@APPId", AppointmentId);
                    //////param.Direction = ParameterDirection.Input;
                    //////param.DbType = DbType.Int64;
                    //////Cmd.Parameters.Add(param);

                    //////param = new SqlParameter("@OTP_PatientType", PatientType);
                    //////param.Direction = ParameterDirection.Input;
                    //////param.DbType = DbType.String;
                    //////Cmd.Parameters.Add(param);

                    //////param = new SqlParameter("@OTP_UHID", UHID);
                    //////param.Direction = ParameterDirection.Input;
                    //////param.DbType = DbType.String;
                    //////Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Image_Upload.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public string AuthenticateMobNo(string RandomNumber, string MobileNo)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            string RetMsg = "";
            try
            {
                using (DbCommand Cmd = db_Image_Upload.GetStoredProcCommand(MediDBConstants.AuthenticateMobNo))
                {
                    param = new SqlParameter("@OTP_MobileNo", MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Otp", RandomNumber);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    SqlParameter returnValue = new SqlParameter("@Response", DbType.String);
                    returnValue.Direction = ParameterDirection.Output;
                    returnValue.DbType = DbType.String;
                    returnValue.Size = 50;
                    Cmd.Parameters.Add(returnValue);

                    db_Image_Upload.ExecuteNonQuery(Cmd);

                   // RetMsg = (string)Cmd.Parameters["@Response"].Value;

                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RetMsg;
        }

        public DataSet SaveAppointmentSlot(ClsSaveAppointmentSlot Request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;

            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.SaveAppointmentSlot))
                {
                    param = new SqlParameter("@DoctorId", Request.DoctorId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);


                    param = new SqlParameter("@FromDate", Request.FromDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.DateTime;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ToDate", Request.ToDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.DateTime;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@SessionStartTime", Request.SessionStartTime);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.DateTime;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@SessionEndingTime", Request.SessionEndingTime);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.DateTime;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", Request.UserId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                    Cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet Update_RefId(reqclass req)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand cmd = db_Institution.GetStoredProcCommand(MediDBConstants.Update_RefId))
                {

                    param = new SqlParameter("@RefID", req.refId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet uhidGenerateLayer(long UHID)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.TempToUHIDGen_Procedure))
                {
                    param = new SqlParameter("@PatientID", UHID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        //public DataSet OT_LIST_SAVE(OtClass req)
        //{
        //    DataSet ds = new DataSet();
        //    SqlParameter param;
        //    try
        //    {
        //        using (DbCommand cmd = db_OT.GetStoredProcCommand(MediDBConstants.Ot_Schedule_screen))
        //        {

        //            param = new SqlParameter("@SNo", req.SNo);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.Int64;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@UHID", req.UHID);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@PatientName", req.PatientName);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Gender", req.Gender);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Age", req.Age);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.Int64;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@ScheduleTime", req.ScheduleTime);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@TheaterName", req.TheaterName);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@StartTime", req.StartTime);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@EndTime", req.EndTime);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);


        //            param = new SqlParameter("@ProcedureName", req.ProcedureName);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Surgeon_Name", req.SurgeonName);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Remarks", req.Remarks);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Ward", req.Ward);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            cmd.CommandTimeout = 30;
        //            ds = db_OT.ExecuteDataSet(cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}

        public DataSet doc_dir_img_view(docDir_imgView req)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand cmd = db_Que.GetStoredProcCommand(MediDBConstants.DocDirImg_save_VIEW))
                {
                    //param = new SqlParameter("@Sno", req.Sno);
                    //param.Direction = ParameterDirection.Input;
                    //param.DbType = DbType.String;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@UHID", req.UHID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PatientName", req.PatientName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MobileNo", req.MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DOB", req.DOB);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Age", req.Age);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@patientAadharFile", req.patientAadharFile);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@insuanceholderAadharFile", req.insuanceholderAadharFile);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@panCardFile", req.panCardFile);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@passportFile", req.passportFile);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@drivinglicenceFile", req.drivinglicenceFile);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@cancelledchequeleafFile", req.cancelledchequeleafFile);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);



                    param = new SqlParameter("@passportsizephotoFile", req.passportsizephotoFile);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@doctorprescriptionFile", req.doctorprescriptionFile);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@investiationreportsFile", req.investiationreportsFile);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@dischargesummaryFile", req.dischargesummaryFile);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@radiologyreportsFile", req.radiologyreportsFile);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@corproateinsurancepolicyFile", req.corproateinsurancepolicyFile);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@healthcardFile", req.healthcardFile);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@corporateidFile", req.corporateidFile);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@empidFile", req.empidFile);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@last3yearsinsuracepolicyFile", req.last3yearsinsuracepolicyFile);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);


                    cmd.CommandTimeout = 30;
                    ds = db_Que.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet Doc_Dir_IMG_import(docDir_img_imp req)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand cmd = db_Que.GetStoredProcCommand(MediDBConstants.SP_DocDirImg_import))
                {

                    param = new SqlParameter("@UHID", req.UHID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PatientName", req.PatientName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MobileNo", req.MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DOB", req.DOB);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Age", req.Age);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@ImageFolderPath", req.ImageFolderPath);
                    //param.Direction = ParameterDirection.Input;
                    //param.DbType = DbType.String;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@IDENTIFICATION_DOCUMENTS", req.IDENTIFICATION_DOCUMENTS);
                    //param.Direction = ParameterDirection.Input;
                    //param.DbType = DbType.String;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@MEDICAL_DOCUMENTS", req.MEDICAL_DOCUMENTS);
                    //param.Direction = ParameterDirection.Input;
                    //param.DbType = DbType.String;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@CORPORATE_DOCUMENTS", req.CORPORATE_DOCUMENTS);
                    //param.Direction = ParameterDirection.Input;
                    //param.DbType = DbType.String;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@INSURANCE_DOCUMENTS", req.INSURANCE_DOCUMENTS);
                    //param.Direction = ParameterDirection.Input;
                    //param.DbType = DbType.String;
                    //cmd.Parameters.Add(param);

                    var dt = new DataTable();

                    dt.Columns.Add("UHID", typeof(string));
                    dt.Columns.Add("IDENTIFICATION_DOCUMENTS", typeof(string));
                    
                    for (int i = 0; i < req.Identification_Image.Count; i++)
                    {
                        var row = dt.NewRow();

                        row["UHID"] = req.Identification_Image[i].uhid;
                        row["IDENTIFICATION_DOCUMENTS"] = req.Identification_Image[i].Identification_Image;
                        dt.Rows.Add(row);
                        dt.AcceptChanges();
                    }

                    param = new SqlParameter("@Doc_DirImg_Upload", dt);
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.Structured;
                    cmd.Parameters.Add(param);
                    //medical
                    var dt1 = new DataTable();

                    dt1.Columns.Add("UHID", typeof(string));
                    dt1.Columns.Add("MEDICAL_DOCUMENTS", typeof(string));

                    for (int i = 0; i < req.Medical_Image.Count; i++)
                    {
                        var row = dt1.NewRow();

                        row["UHID"] = req.Medical_Image[i].uhid;
                        row["MEDICAL_DOCUMENTS"] = req.Medical_Image[i].Medical_Image;
                        dt1.Rows.Add(row);
                        dt1.AcceptChanges();
                    }

                    param = new SqlParameter("@Doc_DirImg_Upload1", dt1);
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.Structured;
                    cmd.Parameters.Add(param);
                    //corp
                    //medical
                    var dt2 = new DataTable();

                    dt2.Columns.Add("UHID", typeof(string));
                    dt2.Columns.Add("CORPORATE_DOCUMENTS", typeof(string));

                    for (int i = 0; i < req.Corporate_Image.Count; i++)
                    {
                        var row = dt2.NewRow();

                        row["UHID"] = req.Corporate_Image[i].uhid;
                        row["CORPORATE_DOCUMENTS"] = req.Corporate_Image[i].Corporate_Image;
                        dt2.Rows.Add(row);
                        dt2.AcceptChanges();
                    }

                    param = new SqlParameter("@Doc_DirImg_Upload2", dt2);
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.Structured;
                    cmd.Parameters.Add(param);
                    //ins
                    //medical
                    var dt3 = new DataTable();

                    dt3.Columns.Add("UHID", typeof(string));
                    dt3.Columns.Add("INSURANCE_DOCUMENTS", typeof(string));

                    for (int i = 0; i < req.Insurance_Image.Count; i++)
                    {
                        var row = dt3.NewRow();

                        row["UHID"] = req.Insurance_Image[i].uhid;
                        row["INSURANCE_DOCUMENTS"] = req.Insurance_Image[i].Insurance_Image;
                        dt3.Rows.Add(row);
                        dt3.AcceptChanges();
                    }

                    param = new SqlParameter("@Doc_DirImg_Upload3", dt3);
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.Structured;
                    cmd.Parameters.Add(param);

                    cmd.CommandTimeout = 30;
                    ds = db_Que.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet Doc_Dir_IMG_export(docDir_img_exp req)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand cmd = db_Que.GetStoredProcCommand(MediDBConstants.SP_DocDirImg_export))
                {

                    param = new SqlParameter("@PicName", req.PicName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ImageFolderPath", req.ImageFolderPath);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Filename", req.Filename);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);


                    cmd.CommandTimeout = 30;
                    ds = db_Que.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet save_signimg(signimgreq req)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand cmd = db_Institution.GetStoredProcCommand(MediDBConstants.save_signimage))
                {

                    param = new SqlParameter("@UHID", req.UHID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PatientName", req.PatientName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MobileNo", req.MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DOB", req.DOB);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Age", req.Age);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@img", req.img);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);


                    cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet signimage()
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand cmd = db_Institution.GetStoredProcCommand(MediDBConstants.Sp_signimage))
                {

                    cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        //public DataSet Insert_DocDir_New(DoctorDirectory_new req)
        //{
        //    DataSet ds = new DataSet();
        //    SqlParameter param;
        //    try
        //    {
        //        using (DbCommand cmd = db_Que.GetStoredProcCommand(MediDBConstants.Insert_NewDoc_Dir))
        //        {

        //            param = new SqlParameter("@Department", req.Department);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Qualification", req.Qualification);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Name", req.Name);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Sub_Department", req.Sub_Department);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Status", req.Status);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@slide_no", req.slide_no);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.Int64;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Tv_no", req.Tv_no);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.Int64;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Sequence", req.Sequence);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.Int64;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@profile", req.profile_image);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Designation", req.Designation);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            cmd.CommandTimeout = 30;
        //            ds = db_Que.ExecuteDataSet(cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}
        //public DataSet Update_DocDir_Dtl(DoctorDirectory req)
        //{
        //    DataSet ds = new DataSet();
        //    SqlParameter param;
        //    try
        //    {
        //        using (DbCommand cmd = db_Que.GetStoredProcCommand(MediDBConstants.Update_NewDoc_Dir))
        //        {
        //            param = new SqlParameter("@SNo", req.SNo);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.Int32;
        //            cmd.Parameters.Add(param);


        //            param = new SqlParameter("@Department", req.Department);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Qualification", req.Qualification);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Name", req.Name);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Sub_Department", req.Sub_Department);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Status", req.Status);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@slide_no", req.slide_no);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.Int64;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Tv_no", req.Tv_no);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.Int64;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Sequence", req.Sequence);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.Int64;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@profile", req.profile_image);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Designation", req.Designation);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            cmd.CommandTimeout = 30;
        //            ds = db_Que.ExecuteDataSet(cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}
        //public DataSet Delete_DocDir_Dtl(int SNo)
        //{
        //    DataSet ds = new DataSet();
        //    SqlParameter param;
        //    try
        //    {
        //        using (DbCommand cmd = db_Que.GetStoredProcCommand(MediDBConstants.Delete_NewDoc_Dir))
        //        {
        //            param = new SqlParameter("@SNo", SNo);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            cmd.CommandTimeout = 30;
        //            ds = db_Que.ExecuteDataSet(cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}

        //public DataSet DeleteFilefromDisk(int UHID, string DocumentPath)
        //{
        //    DataSet ds = new DataSet();
        //    SqlParameter param;
        //    try
        //    {
        //        using (DbCommand cmd = db_Image_Upload.GetStoredProcCommand(MediDBConstants.Sp_DeleteFilefromDisk))
        //        {
        //            param = new SqlParameter("@UHID", UHID);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@DocumentPath", DocumentPath);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            cmd.CommandTimeout = 30;
        //            ds = db_Image_Upload.ExecuteDataSet(cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}

        //public DataSet Get_PaymentGetWay(PaymentGateWay req)
        //{
        //    DataSet ds = new DataSet();
        //    SqlParameter param;
        //    try
        //    {
        //        using (DbCommand cmd = db_Que.GetStoredProcCommand(MediDBConstants.Payment_Gateway))
        //        {
        //            param = new SqlParameter("@FirstName", req.FirstName);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@LastName", req.LastName);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Dob", req.Dob);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.DateTime;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Gender", req.Gender);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Org_InsName", req.Org_InsName);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Profession", req.Profession);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@MobileNo", req.MobileNo);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@EmailId", req.EmailId);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            cmd.CommandTimeout = 30;
        //            ds = db_Que.ExecuteDataSet(cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}
        //public DataSet Get_OTLits()
        //{
        //    DataSet ds = new DataSet();

        //    try
        //    {
        //        using (DbCommand cmd = db_OT.GetStoredProcCommand(MediDBConstants.Ot_getdetails))
        //        {
        //            cmd.CommandTimeout = 30;
        //            ds = db_OT.ExecuteDataSet(cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}
        //public DataSet get_LicenseModel()
        //{
        //    DataSet ds = new DataSet();

        //    try
        //    {
        //        using (DbCommand cmd = db_rimc2019.GetStoredProcCommand(MediDBConstants.get_License_Dtl))
        //        {
        //            cmd.CommandTimeout = 30;
        //            ds = db_rimc2019.ExecuteDataSet(cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}
        //public DataSet Get_Appsolt_dtl()
        //{
        //    DataSet ds = new DataSet();

        //    try
        //    {
        //        using (DbCommand cmd = db_Que.GetStoredProcCommand(MediDBConstants.get_AppSolt_Dtl))
        //        {
        //            cmd.CommandTimeout = 30;
        //            ds = db_Que.ExecuteDataSet(cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}
        //public DataSet OT_Excel(Otexcel_req request)
        //{
        //    DataSet ds = new DataSet();
        //    SqlParameter param;
        //    try
        //    {
        //        using (DbCommand Cmd = db_Que.GetStoredProcCommand(MediDBConstants.otexcel_save))
        //        {

        //            var dt = new DataTable();

        //            dt.Columns.Add("SNo",  typeof(string));
        //            dt.Columns.Add("UHID", typeof(string));
        //            dt.Columns.Add("PatientName", typeof(string));
        //            dt.Columns.Add("Gender", typeof(string));
        //            dt.Columns.Add("Age", typeof(string));
        //            dt.Columns.Add("ScheduleTime", typeof(string));
        //            dt.Columns.Add("TheaterName", typeof(string));
        //            dt.Columns.Add("StartTime", typeof(string));
        //            dt.Columns.Add("EndTime", typeof(string));
        //            dt.Columns.Add("ProcedureName", typeof(string));
        //            dt.Columns.Add("Surgeon_Name", typeof(string));
        //            dt.Columns.Add("Remarks", typeof(string));
        //            dt.Columns.Add("Ward", typeof(string));

        //            for (int i = 0; i < request.otexcel.Count; i++)
        //            {
        //                var row = dt.NewRow();

        //                row["SNo"]           = request.otexcel[i].SNo;
        //                row["UHID"]          = request.otexcel[i].UHID;
        //                row["PatientName"]   = request.otexcel[i].PatientName;
        //                row["Gender"]        = request.otexcel[i].Gender;
        //                row["Age"]           = request.otexcel[i].Age;
        //                row["ScheduleTime"]   = request.otexcel[i].ScheduleTime;
        //                row["TheaterName"]   = request.otexcel[i].TheaterName;
        //                row["StartTime"]     = request.otexcel[i].StartTime;
        //                row["EndTime"]       = request.otexcel[i].EndTime;
        //                row["ProcedureName"] = request.otexcel[i].ProcedureName;
        //                row["Surgeon_Name"]  = request.otexcel[i].Surgeon_Name;
        //                row["Remarks"]       = request.otexcel[i].Remarks;
        //                row["Ward"]          = request.otexcel[i].Ward;

        //                dt.Rows.Add(row);
        //                dt.AcceptChanges();
        //            }

        //            param = new SqlParameter("@ot_excel", dt);
        //            param.Direction = ParameterDirection.Input;
        //            param.SqlDbType = SqlDbType.Structured;
        //            Cmd.Parameters.Add(param);

        //            Cmd.CommandTimeout = 30;
        //            ds = db_Que.ExecuteDataSet(Cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}
        //public DataSet Get_DoctorDirectory_dtl()
        //{
        //    DataSet ds = new DataSet();

        //    try
        //    {
        //        using (DbCommand cmd = db_Que.GetStoredProcCommand(MediDBConstants.doctor_directory))
        //        {
        //            cmd.CommandTimeout = 30;
        //            ds = db_Que.ExecuteDataSet(cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}
        //public DataSet Get_TicketingCount_dtl(string Fromdate, string Todate)
        //{
        //    DataSet ds = new DataSet();
        //    SqlParameter param;
        //    try
        //    {
        //        using (DbCommand cmd = db_rimc2019.GetStoredProcCommand(MediDBConstants.Ticketing_Count))
        //        {

        //            param = new SqlParameter("@fromdate", Fromdate);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@todate", Todate);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            cmd.CommandTimeout = 30;
        //            ds = db_rimc2019.ExecuteDataSet(cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}
        //public DataSet Get_TicketingDepCount_dtl(string Fromdate, string Todate)
        //{
        //    DataSet ds = new DataSet();
        //    SqlParameter param;
        //    try
        //    {
        //        using (DbCommand cmd = db_rimc2019.GetStoredProcCommand(MediDBConstants.DepWiseTicketing_Count))
        //        {

        //            param = new SqlParameter("@fromdate", Fromdate);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@todate", Todate);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            cmd.CommandTimeout = 30;
        //            ds = db_rimc2019.ExecuteDataSet(cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}
        //public DataSet Get_DocDirectoru_Editdtl(int SNo)
        //{
        //    DataSet ds = new DataSet();
        //    SqlParameter param;
        //    try
        //    {
        //        using (DbCommand cmd = db_Que.GetStoredProcCommand(MediDBConstants.doctor_directory_EditDtl))
        //        {

        //            param = new SqlParameter("@SNo", SNo);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            cmd.CommandTimeout = 30;
        //            ds = db_Que.ExecuteDataSet(cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}
        //public DataSet DoctoryDiectory_Img(DocDirImg_req request)
        //{
        //    DataSet ds = new DataSet();
        //    SqlParameter param;
        //    try
        //    {
        //        using (DbCommand Cmd = db_Que.GetStoredProcCommand(MediDBConstants.DocDirImg_save))
        //        {

        //            var dt = new DataTable();

        //            dt.Columns.Add("Image", typeof(string));


        //            for (int i = 0; i < request.DocDirImg_Line.Count; i++)
        //            {
        //                var row = dt.NewRow();

        //                row["Image"] = request.DocDirImg_Line[i].Image;


        //                dt.Rows.Add(row);
        //                dt.AcceptChanges();
        //            }

        //            param = new SqlParameter("@Doc_DirImg", dt);
        //            param.Direction = ParameterDirection.Input;
        //            param.SqlDbType = SqlDbType.Structured;
        //            Cmd.Parameters.Add(param);

        //            Cmd.CommandTimeout = 30;
        //            ds = db_Que.ExecuteDataSet(Cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}
        //public DataSet Get_DocDir_Img_List()
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        using (DbCommand cmd = db_Que.GetStoredProcCommand(MediDBConstants.doctor_directory_Img_List))
        //        {

        //            cmd.CommandTimeout = 30;
        //            ds = db_Que.ExecuteDataSet(cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}
        //public DataSet Get_DocDir_Img_View_List()
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        using (DbCommand cmd = db_Que.GetStoredProcCommand(MediDBConstants.doctor_directory_Img_View_List))
        //        {

        //            cmd.CommandTimeout = 30;
        //            ds = db_Que.ExecuteDataSet(cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}
        //public DataSet Get_PaymentGetWay_List(string frdate, string todate)
        //{
        //    DataSet ds = new DataSet();
        //    SqlParameter param;
        //    try
        //    {
        //        using (DbCommand cmd = db_Que.GetStoredProcCommand(MediDBConstants.Get_PaymentGetWay_List))
        //        {

        //            param = new SqlParameter("@frdate", frdate);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@todate", todate);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            cmd.CommandTimeout = 30;
        //            ds = db_Que.ExecuteDataSet(cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}
        //public DataSet Get_PaymentGetWay_Listdemo(string frdate, string todate)
        //{
        //    DataSet ds = new DataSet();
        //    SqlParameter param;
        //    try
        //    {
        //        using (DbCommand cmd = db_Que.GetStoredProcCommand(MediDBConstants.Get_PaymentGetWay_Listdemo))
        //        {

        //            param = new SqlParameter("@frdate", frdate);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            param = new SqlParameter("@todate", todate);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            cmd.CommandTimeout = 30;
        //            ds = db_Que.ExecuteDataSet(cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}
        public DataSet getAppAvailableSlotTimeDtl(DateTime APPDate, String ConsId, String Slottype)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand cmd = db_Institution.GetStoredProcCommand(MediDBConstants.AppAvailableSlotTime_Dtl))
                {

                    param = new SqlParameter("@APPDate", APPDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.DateTime;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ConsId", ConsId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slottype", Slottype);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);


                    cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetCombinedData( string DtlType)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand cmd = db_HelpDesk.GetStoredProcCommand(MediDBConstants.SP_GetCombinedData))
                {

                    param = new SqlParameter("@DtlType", DtlType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    cmd.CommandTimeout = 30;
                    ds = db_HelpDesk.ExecuteDataSet(cmd);

                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        //public DataSet GetCombinedData_v1(string DtlType)
        //{
        //    DataSet ds = new DataSet();
        //    SqlParameter param;
        //    try
        //    {
        //        using (DbCommand cmd = db_HelpDesk.GetStoredProcCommand(MediDBConstants.SP_GetCombinedData))
        //        {

        //            param = new SqlParameter("@DtlType", DtlType);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            cmd.Parameters.Add(param);

        //            cmd.CommandTimeout = 30;
        //            ds = db_HelpDesk.ExecuteDataSet(cmd);

        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}

        public DataSet BB_BloodGroup(BB_BloodGroup_req request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.BB_BloodGroup))
                {

                    var dt = new DataTable();

                    dt.Columns.Add("VisitId", typeof(string));
                    dt.Columns.Add("RegistrationId", typeof(decimal));
                    dt.Columns.Add("PatientId", typeof(decimal));
                    dt.Columns.Add("ServiceNumber", typeof(string));
                    dt.Columns.Add("ChargeId", typeof(int));
                    dt.Columns.Add("TestName", typeof(string));
                    dt.Columns.Add("ParameterName", typeof(string));
                    dt.Columns.Add("TestRemaks", typeof(string));
                    dt.Columns.Add("Result", typeof(string));
                    dt.Columns.Add("Remaks", typeof(string));

                    for (int i = 0; i < request.BB_BloodGroup.Count; i++)
                    {
                        var row = dt.NewRow();

                        row["VisitId"] = request.BB_BloodGroup[i].VisitId;
                        row["RegistrationId"] = request.BB_BloodGroup[i].RegistrationId;
                        row["PatientId"] = request.BB_BloodGroup[i].PatientId;
                        row["ServiceNumber"] = request.BB_BloodGroup[i].ServiceNumber;
                        row["ChargeId"] = request.BB_BloodGroup[i].ChargeId;
                        row["TestName"] = request.BB_BloodGroup[i].TestName;
                        row["ParameterName"] = request.BB_BloodGroup[i].ParameterName;
                        row["TestRemaks"] = request.BB_BloodGroup[i].TestRemaks;
                        row["Result"] = request.BB_BloodGroup[i].Result;
                        row["Remaks"] = request.BB_BloodGroup[i].Remaks;



                        dt.Rows.Add(row);
                        dt.AcceptChanges();
                    }

                    param = new SqlParameter("@tblBloodBank_Result", dt);
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.Structured;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetSalutationsDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.GetSalutationsData))
                {
                    //db.AddInParameter(Cmd, "recordCount", DbType.Int32);
                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetMobileCodeData()
        {
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.GetMobileCodeProcedure))
                {
                    //db.AddInParameter(Cmd, "recordCount", DbType.Int32);
                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetCountriesDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.GetCountriesData))
                {
                    //db.AddInParameter(Cmd, "recordCount", DbType.Int32);
                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetServiceLoad()
        {
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.ServiceLoad_Procedure))
                {
                    //db.AddInParameter(Cmd, "recordCount", DbType.Int32);
                    Cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        //End by jeyaganesh 06.08.2021

        public DataSet GetPriorityrData()
        {
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.Priority_Procedure))
                {
                    //db.AddInParameter(Cmd, "recordCount", DbType.Int32);
                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        //public DataSet GetChargeMasterData(long code)
        //{
        //    SqlParameter param;
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.ChargeMasterLoad_Procedure))
        //        {
        //            param = new SqlParameter("@ServiceCode", code);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.Int64;
        //            Cmd.Parameters.Add(param);

        //            Cmd.CommandTimeout = 30;
        //            ds = db_Institution.ExecuteDataSet(Cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}
        public DataSet GetNationalityDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.GetNationalityData))
                {
                    //db.AddInParameter(Cmd, "recordCount", DbType.Int32);
                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetExternal_DocData()
        {

            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.web_ExternalDoc_Data))
                {

                    Cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetMasterBloodGroup()
        {
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.Master_Blood_Group))
                {
                    //db.AddInParameter(Cmd, "recordCount", DbType.Int32);
                    Cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetRef_Relationship()//prabha 25/10/2021
        {
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand cmd = db_Master.GetStoredProcCommand(MediDBConstants.web_Relationship_procedure))
                {
                    cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;

        }

        public DataSet SurgProcname_Dtl()//Sujithra 30/12/2023
        {
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand cmd = db_RMC_IP.GetStoredProcCommand(MediDBConstants.SP_SurgProcname_Dtl))
                {
                    cmd.CommandTimeout = 30;
                    ds = db_RMC_IP.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;

        }
        public DataSet FinancialCounsellingprint(int Patientid, int CounsellingId)//Sujithra 30/12/2023
        {

            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_RMC_IP.GetStoredProcCommand(MediDBConstants.SP_FinancialCounsellingprint))
                {

                    param = new SqlParameter("@Patientid", Patientid);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@CounsellingId", CounsellingId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_RMC_IP.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet FinancialCounsellingprint(int Patientid)//Sujithra 02/01/2023
        {

            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_RMC_IP.GetStoredProcCommand(MediDBConstants.Sp_FinCouncil_Detail_Load))
                {

                    param = new SqlParameter("@Patid", Patientid);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);


                    Cmd.CommandTimeout = 30;
                    ds = db_RMC_IP.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetMasReligion_Data()
        {

            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.web_religion_hdr))
                {

                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetStateDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.GetStateData))
                {
                    //db.AddInParameter(Cmd, "recordCount", DbType.Int32);
                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetOccupationDataDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.GetOccupationData))
                {
                    //db.AddInParameter(Cmd, "recordCount", DbType.Int32);
                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet Web_Bed_Report()
        {
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_RMC_IP.GetStoredProcCommand(MediDBConstants.GetBed_Report))
                {
                   
                    Cmd.CommandTimeout = 30;
                    ds = db_RMC_IP.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetChargeMasterData_v1(long code)
        {
            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.ChargeMasterLoad_Procedure_v1))
                {
                    param = new SqlParameter("@ServiceCode", code);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetCityStatewiseDtl(int StateCode)
        {
            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.GetCityDtl_Statewise))
                {
                    param = new SqlParameter("@StateCode", StateCode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);


                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetMaritalStatusDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.GetMaritalStatusData))
                {
                    //db.AddInParameter(Cmd, "recordCount", DbType.Int32);
                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetAreaData(string pincode)
        {
            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.GetAreaProcedure))
                {
                    param = new SqlParameter("@Pincode", pincode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);


                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetRef_Corprate_Insurance(string PanelType)
        {
            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.web_Corprate_Insurance_procedure))
                {
                    param = new SqlParameter("@Type", PanelType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);
                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetDoctorNameDepWise(long DepID, string DoctorName)
        {
            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.GetDoctorDetailsDepwise_SP))
                {
                    param = new SqlParameter("@DepID", DepID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@DoctorName", DoctorName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetIDTypeDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.GetIDTypeData))
                {
                    //db.AddInParameter(Cmd, "recordCount", DbType.Int32);
                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetMasLang_Data()
        {

            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.web_language_hdr))
                {

                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetRef_DoctorData()//prabha 04-Jan-2022
        {
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand cmd = db_Master.GetStoredProcCommand(MediDBConstants.web_DoctorsData_procedure))
                {
                    cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;

        }
        public DataSet GetRef_Source()
        {
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand cmd = db_Master.GetStoredProcCommand(MediDBConstants.Web_Ref_source_Procedure))
                {
                    cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetDepartmentData()
        {
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.GetDepartmentProcedure))
                {
                    //db.AddInParameter(Cmd, "recordCount", DbType.Int32);
                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet Insert_OPDMaster_Porc(OPD_MasterProc_req req)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.OPD_MasterProc_api))
                {

                    var dt = new DataTable();

                    dt.Columns.Add("Mchr_ChargeId_id", typeof(int));
                    dt.Columns.Add("Opbl_Unit_nbr", typeof(int));
                    dt.Columns.Add("Opbl_Rate_nbr", typeof(decimal));
                    dt.Columns.Add("Opbl_DiscountType_cd", typeof(int));
                    dt.Columns.Add("Opbl_Discount_nbr", typeof(decimal));
                    dt.Columns.Add("Opbl_NetAmt_nbr", typeof(decimal));
                    dt.Columns.Add("Prio_PriorityType_Desc", typeof(string));
                    dt.Columns.Add("Opbl_Remarks_desc", typeof(string));

                    for (int i = 0; i < req.OPBillRecepitLine.Count; i++)
                    {
                        var row = dt.NewRow();

                        row["Mchr_ChargeId_id"] = req.OPBillRecepitLine[i].ServiceID;
                        row["Opbl_Unit_nbr"] = req.OPBillRecepitLine[i].Unit;
                        row["Opbl_Rate_nbr"] = req.OPBillRecepitLine[i].Rate;
                        row["Opbl_DiscountType_cd"] = req.OPBillRecepitLine[i].DiscType;
                        row["Opbl_Discount_nbr"] = req.OPBillRecepitLine[i].Discount;
                        row["Opbl_NetAmt_nbr"] = req.OPBillRecepitLine[i].Amount;
                        row["Prio_PriorityType_Desc"] = req.OPBillRecepitLine[i].PriorityID;
                        row["Opbl_Remarks_desc"] = req.OPBillRecepitLine[i].Remarks;
                        dt.Rows.Add(row);
                        dt.AcceptChanges();
                    }

                    //for (int i = 0; i < req.ExistsOPBillRecepitLine.Count; i++)
                    //{
                    //    var row = dt.NewRow();

                    //    row["Mchr_ChargeId_id"] = req.ExistsOPBillRecepitLine[i].ServiceID;
                    //    row["Opbl_Unit_nbr"] = req.ExistsOPBillRecepitLine[i].Unit;
                    //    row["Opbl_Rate_nbr"] = req.ExistsOPBillRecepitLine[i].Rate;
                    //    row["Opbl_DiscountType_cd"] = req.ExistsOPBillRecepitLine[i].DiscType;
                    //    row["Opbl_Discount_nbr"] = req.ExistsOPBillRecepitLine[i].Discount;
                    //    row["Opbl_NetAmt_nbr"] = req.ExistsOPBillRecepitLine[i].Amount;
                    //    row["Prio_PriorityType_Desc"] = req.ExistsOPBillRecepitLine[i].PriorityID;
                    //    row["Opbl_Remarks_desc"] = req.ExistsOPBillRecepitLine[i].Remarks;
                    //    dt.Rows.Add(row);
                    //    dt.AcceptChanges();
                    //}

                    param = new SqlParameter("@tblInvstigation", dt);
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.Structured;
                    Cmd.Parameters.Add(param);


                    var dt1 = new DataTable();

                    dt1.Columns.Add("PayType", typeof(string));
                    dt1.Columns.Add("amount", typeof(decimal));
                    dt1.Columns.Add("CardNo", typeof(string));


                    for (int i = 0; i < req.OPReceipt_Payment_Line.Count; i++)
                    {
                        var row = dt1.NewRow();

                        row["PayType"] = req.OPReceipt_Payment_Line[i].PayMode;
                        row["amount"] = req.OPReceipt_Payment_Line[i].Amount;
                        row["CardNo"] = req.OPReceipt_Payment_Line[i].RefNo;

                        dt1.Rows.Add(row);
                        dt1.AcceptChanges();
                    }

                    param = new SqlParameter("@Web_OPReceipt_Payment_Type", dt1);
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.Structured;
                    Cmd.Parameters.Add(param);


                    param = new SqlParameter("@PatientTitle", req.PatientTitle);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@SalutationName", req.SalutationName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@PatientName", req.PatientName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@DOB", Convert.ToDateTime(req.DOB).ToString("dd/MMM/yyyy"));
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Date;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Gender", req.Gender);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    string DOB = Convert.ToDateTime(req.DOB).ToString("dd/MMM/yyyy");

                    param = new SqlParameter("@MaritalStatus", req.MaritalStatus);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int16;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@IDtype", req.IDtype);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int16;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@IDNo", req.IDNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Nationality", req.Nationality);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Language", req.Language);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Occupation", req.Occupation);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@MobileNo", req.MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@EmailId", req.EmailId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Address", req.Address);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StateCode", req.StateCode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@CityCode", req.CityCode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@CountryCode", req.CountryCode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Pincode", req.Pincode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@BirthCountry", req.CountryCode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@PassportNo", req.PassportNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@VISANo", req.VISANo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@VISAType", req.VISAType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);


                    param = new SqlParameter("@VISAValidity", req.VISAValidity);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                    param = new SqlParameter("@FormCstatus", req.FormCstatus);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Mob_CountryCode", req.Mob_CountryCode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@AltMob_CountryCode", req.AltMob_CountryCode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@AltMobileNo", req.AltMobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@CurrAddress", req.CurrAddress);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@PermAddress", req.PermAddress);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Area", req.Area);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Pat_Is_symptoms", req.Pat_Is_symptoms);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Boolean;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Pat_Is_historyoffever", req.Pat_Is_historyoffever);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Boolean;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Pat_Is_outofcountry1month", req.Pat_Is_outofcountry1month);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Boolean;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Pat_Is_diseaseoutbreak", req.Pat_Is_diseaseoutbreak);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Boolean;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Pat_Is_healthcareworker", req.Pat_Is_healthcareworker);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Boolean;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Pat_Is_disease_last1month", req.Pat_Is_disease_last1month);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Boolean;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Pat_Is_chickenpox", req.Pat_Is_chickenpox);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Boolean;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Pat_Is_measles", req.Pat_Is_measles);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Boolean;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Pat_Is_mumps", req.Pat_Is_mumps);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Boolean;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Pat_Is_rubella", req.Pat_Is_rubella);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Boolean;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Pat_Is_diarrheasymptoms", req.Pat_Is_diarrheasymptoms);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Boolean;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Pat_Is_activeTB", req.Pat_Is_activeTB);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Boolean;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Pat_Is_receivewhatsapp", req.Pat_Is_receivewhatsapp);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Boolean;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@RelationType", req.RelationType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@RelationName", req.RelationName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@RelationMobileno", req.RelationMobileno);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", req.UserID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@annualincome", req.annualincome);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@prefferedLanguages", req.prefferedLanguages);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@religion", req.religion);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@kin_Address", req.kin_Address);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@kin_StateCode", req.kin_StateCode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@kin_CityCode", req.kin_CityCode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@kin_CountryCode", req.kin_CountryCode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@kin_Pincode", req.kin_Pincode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@kin_Area", req.kin_Area);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@OccRemark", req.OccRemark);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@BloodGroup", req.BloodGroup);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@DOCID", req.docId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@AppointmentId", req.appointmentId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@RefSource", req.RefSource);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@VistType", req.VistType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@PatientType", req.PatientType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@PayorID", req.PayorID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", req.Remarks);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@internalDocId", req.InternalDocId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ExternalDocId", req.ExternalDocId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Opbl_GrossAmount_nbr", req.GrossAmount);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Decimal;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Opbl_DiscAmount_nbr", req.DiscountAmount);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Decimal;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Opbl_GLAmount_nbr", req.GLAmount);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Decimal;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Opbl_PatientResponsibility_desc", req.PatientResponsibility);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Decimal;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Opbl_NetAmount_nbr", req.NetAmount);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Decimal;
                    Cmd.Parameters.Add(param);


                    param = new SqlParameter("@APPStartDate", req.APPStartDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.DateTime;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Package", req.Package);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@AppRemarks", req.AppRemarks);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@AppRefSource", req.AppRefSource);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public class ListtoDataTableConverter
        {
            public DataTable ToDataTable<T>(List<T> items)
            {
                PropertyDescriptorCollection properties =
            TypeDescriptor.GetProperties(typeof(T));

                DataTable table = new DataTable();

                //Get all the properties
                foreach (PropertyDescriptor prop in properties)
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                foreach (T item in items)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    table.Rows.Add(row);
                }
                return table;

                //put a breakpoint here and check datatable
                //return dataTable;
            }

        }

        public DataSet Insert_ExsistsOPDMaster_Porc(OPD_ExsitsMasterProc_req req)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.OPD_ExsistsMasterProc_api))
                {

                    var dt = new DataTable();

                    dt.Columns.Add("Mchr_ChargeId_id", typeof(int));
                    dt.Columns.Add("Opbl_Unit_nbr", typeof(int));
                    dt.Columns.Add("Opbl_Rate_nbr", typeof(decimal));
                    dt.Columns.Add("Opbl_DiscountType_cd", typeof(int));
                    dt.Columns.Add("Opbl_Discount_nbr", typeof(decimal));
                    dt.Columns.Add("Opbl_NetAmt_nbr", typeof(decimal));
                    dt.Columns.Add("Prio_PriorityType_Desc", typeof(string));
                    dt.Columns.Add("Opbl_Remarks_desc", typeof(string));

                    for (int i = 0; i < req.ExistsOPBillRecepitLine.Count; i++)
                    {
                        var row = dt.NewRow();

                        row["Mchr_ChargeId_id"] = req.ExistsOPBillRecepitLine[i].ServiceID;
                        row["Opbl_Unit_nbr"] = req.ExistsOPBillRecepitLine[i].Unit;
                        row["Opbl_Rate_nbr"] = req.ExistsOPBillRecepitLine[i].Rate;
                        row["Opbl_DiscountType_cd"] = req.ExistsOPBillRecepitLine[i].DiscType;
                        row["Opbl_Discount_nbr"] = req.ExistsOPBillRecepitLine[i].Discount;
                        row["Opbl_NetAmt_nbr"] = req.ExistsOPBillRecepitLine[i].Amount;
                        row["Prio_PriorityType_Desc"] = req.ExistsOPBillRecepitLine[i].PriorityID;
                        row["Opbl_Remarks_desc"] = req.ExistsOPBillRecepitLine[i].Remarks;
                        dt.Rows.Add(row);
                        dt.AcceptChanges();
                    }

                    param = new SqlParameter("@tblInvstigation", dt);
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.Structured;
                    Cmd.Parameters.Add(param);


                    var dt1 = new DataTable();

                    dt1.Columns.Add("PayType", typeof(string));
                    dt1.Columns.Add("amount", typeof(decimal));
                    dt1.Columns.Add("CardNo", typeof(string));


                    for (int i = 0; i < req.OPReceipt_Payment_Line.Count; i++)
                    {
                        var row = dt1.NewRow();

                        row["PayType"] = req.OPReceipt_Payment_Line[i].PayMode;
                        row["amount"] = req.OPReceipt_Payment_Line[i].Amount;
                        row["CardNo"] = req.OPReceipt_Payment_Line[i].RefNo;

                        dt1.Rows.Add(row);
                        dt1.AcceptChanges();
                    }

                    param = new SqlParameter("@Web_OPReceipt_Payment_Type", dt1);
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.Structured;
                    Cmd.Parameters.Add(param);


                    param = new SqlParameter("@PatientID", req.PatientID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Gender", req.Gender);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@MobileNo", req.MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Email", req.EmailId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", req.UserID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@DOCID", req.docId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@AppointmentId", req.appointmentId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@RefSource", req.RefSource);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@VistType", req.VistType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@PatientType", req.PatientType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@PayorID", req.PayorID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", req.Remarks);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@internalDocId", req.InternalDocId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ExternalDocId", req.ExternalDocId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Opbl_GrossAmount_nbr", req.GrossAmount);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Decimal;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Opbl_DiscAmount_nbr", req.DiscountAmount);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Decimal;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Opbl_GLAmount_nbr", req.GLAmount);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Decimal;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Opbl_PatientResponsibility_desc", req.PatientResponsibility);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Decimal;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Opbl_NetAmount_nbr", req.NetAmount);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Decimal;
                    Cmd.Parameters.Add(param);


                    param = new SqlParameter("@APPStartDate", req.APPStartDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.DateTime;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Package", req.Package);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@AppRemarks", req.AppRemarks);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@AppRefSource", req.AppRefSource);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet opInvoice(clsopInvoice request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;

            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.op_Invoice_Procedure))
                {
                    param = new SqlParameter("@Mpat_PatientId_id", request.UHID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Opbl_DoctorCode_cd", request.Doctor.columnCode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", request.UserID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Opbl_GrossAmount_nbr", request.TotalGrossAmount);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Decimal;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Opbl_DiscAmount_nbr", request.TotalDiscountAmount);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Decimal;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Opbl_GLAmount_nbr", request.GLAmount);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Decimal;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Opbl_PatientResponsibility_desc", request.PatientResponsibility);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Opbl_NetAmount_nbr", request.TotalNetAmount);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Decimal;
                    Cmd.Parameters.Add(param);

                    var dt = new DataTable();

                    dt.Columns.Add("Preg_RegistrationId_id", typeof(int));
                    dt.Columns.Add("Mchr_ChargeId_id", typeof(int));
                    dt.Columns.Add("Opbl_Unit_nbr", typeof(int));
                    dt.Columns.Add("Opbl_Rate_nbr", typeof(decimal));
                    dt.Columns.Add("Opbl_DiscountType_cd", typeof(int));
                    dt.Columns.Add("Opbl_Discount_nbr", typeof(decimal));
                    dt.Columns.Add("Opbl_NetAmt_nbr", typeof(decimal));
                    dt.Columns.Add("Prio_PriorityType_Desc", typeof(int));
                    dt.Columns.Add("Opbl_Remarks_desc", typeof(string));

                    for (int i = 0; i < request.opInvoiceLine.Count; i++)
                    {
                        var row = dt.NewRow();

                        row["Preg_RegistrationId_id"] = request.opInvoiceLine[i].RegistrationId;
                        row["Mchr_ChargeId_id"] = request.opInvoiceLine[i].Service.columnCode;
                        row["Opbl_Unit_nbr"] = request.opInvoiceLine[i].Unit;
                        row["Opbl_Rate_nbr"] = request.opInvoiceLine[i].Rate;
                        row["Opbl_DiscountType_cd"] = request.opInvoiceLine[i].DiscountType.value;
                        row["Opbl_Discount_nbr"] = request.opInvoiceLine[i].Discount;
                        row["Opbl_NetAmt_nbr"] = request.opInvoiceLine[i].Amount;
                        row["Prio_PriorityType_Desc"] = request.opInvoiceLine[i].Priority.columnCode;
                        row["Opbl_Remarks_desc"] = request.opInvoiceLine[i].Remarks;
                        dt.Rows.Add(row);
                        dt.AcceptChanges();
                    }

                    param = new SqlParameter("@tblInvstigation", dt);
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.Structured;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet Deposit_Dep(clsdeposit request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;

            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.Deposit_Dep_Procedure))
                {
                    param = new SqlParameter("@PatientId", request.PatientId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepAmomunt", request.DepAmomunt);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", request.UserId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepositType", request.DepositType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                    var dt = new DataTable();

                    dt.Columns.Add("PayType", typeof(string));
                    dt.Columns.Add("CardNo", typeof(string));
                    dt.Columns.Add("amount", typeof(int));
                    dt.Columns.Add("ContraVoucherNo", typeof(string));
                    dt.Columns.Add("CreditCardId", typeof(int));
                    dt.Columns.Add("ValidityDate", typeof(DateTime));
                    dt.Columns.Add("AuthorisationNo", typeof(int));


                    for (int i = 0; i < request.clsdepositLine.Count; i++)
                    {
                        var row = dt.NewRow();

                        row["PayType"] = request.clsdepositLine[i].PayType;
                        row["CardNo"] = request.clsdepositLine[i].CardNo;
                        row["amount"] = request.clsdepositLine[i].amount;
                        row["ContraVoucherNo"] = request.clsdepositLine[i].ContraVoucherNo;
                        row["CreditCardId"] = request.clsdepositLine[i].CreditCardId;
                        row["ValidityDate"] = request.clsdepositLine[i].ValidityDate;
                        row["AuthorisationNo"] = request.clsdepositLine[i].AuthorisationNo;

                        dt.Rows.Add(row);
                        dt.AcceptChanges();
                    }

                    param = new SqlParameter("@Web_Deposit_Payment_Type", dt);
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.Structured;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet web_refincoun_save(clsrefincoun request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;

            try
            {
                using (DbCommand Cmd = db_RMC_IP.GetStoredProcCommand(MediDBConstants.SP_web_refincoun_save))
                {
                    param = new SqlParameter("@Counselling", request.Counselling);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@RevisedEstimationStaty", request.RevisedEstimationStaty);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@CurrentBillAmount", request.CurrentBillAmount);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@RecounselledAmount", request.RecounselledAmount);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepositAmount", request.DepositAmount);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);


                    param = new SqlParameter("@StayExceeding_Desc", request.StayExceeding_Desc);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@AdditionalProcedures", request.AdditionalProcedures);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@MedicalReason", request.MedicalReason);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", request.Remarks);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@PatientType", request.PatientType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@payorid", request.payorid);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Roomcategory", request.Roomcategory);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedById", request.CreatedById);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                    Cmd.CommandTimeout = 30;
                    ds = db_RMC_IP.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }



        public DataSet IPBedBlock_Save(clsIPBedBlock request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;

            try
            {
                using (DbCommand Cmd = db_RMC_IP.GetStoredProcCommand(MediDBConstants.SP_IP_IPBedBlock_Save))
                {
                    param = new SqlParameter("@BEDID", request.BEDID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@CrPatientID", request.CrPatientID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@FuPatientID", request.FuPatientID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@CREATEDBY", request.CREATEDBY);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                    Cmd.CommandTimeout = 30;
                    ds = db_RMC_IP.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet IPBedBlock_Clear(reqIPBedBlock_Clear request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;

            try
            {
                using (DbCommand Cmd = db_RMC_IP.GetStoredProcCommand(MediDBConstants.SP_IPBedBlock_Clear))
                {
                    param = new SqlParameter("@Remark", request.Remark);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@LASTMODIFIEDBY", request.LASTMODIFIEDBY);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@BEDID", request.BEDID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);


                    Cmd.CommandTimeout = 30;
                    ds = db_RMC_IP.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet updateVist_new(reqAppVisit request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.web_Visitcreation_Procedure))
                {
                    param = new SqlParameter("@PATIENTID", request.patientId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@DOCID", request.docId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@USERID", request.userId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@AppointmentId", request.appointmentId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@RefSource", request.RefSource);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@VistType", request.VistType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@PatientType", request.PatientType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@PayorID", request.PayorID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", request.Remarks);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Email", request.Email);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@MobileNo", request.MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@internalDocId", request.InternalDocId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ExternalDocId", request.ExternalDocId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getWebExisitingPatientAppointment(clsWebExisitingPatientAppointmenthead request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand cmd = db_Institution.GetStoredProcCommand(MediDBConstants.WebExisitingPatientAppointment))
                {

                    param = new SqlParameter("@UHID", request.UHID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DocId", request.DocId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@APPStartDate", request.APPStartDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.DateTime;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", request.UserId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Package", request.Package);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", request.Remarks);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RefSource", request.RefSource);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);


                    cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet VisitWithAppointment(VisitWithAppointment_Detail request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand cmd = db_Institution.GetStoredProcCommand(MediDBConstants.VisitWithAppointment))
                {

                    param = new SqlParameter("@UHID", request.UHID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DocId", request.DocId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@APPStartDate", request.APPStartDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.DateTime;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", request.UserId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    ////param = new SqlParameter("@Package", request.Package);
                    ////param.Direction = ParameterDirection.Input;
                    ////param.DbType = DbType.String;
                    ////cmd.Parameters.Add(param);

                    param = new SqlParameter("@Remarks", request.Remarks);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RefSource", request.RefSource);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);


                    //param = new SqlParameter("@AppointmentId", request.AppointmentId);
                    //param.Direction = ParameterDirection.Input;
                    //param.DbType = DbType.Int64;
                    //cmd.Parameters.Add(param);

                    param = new SqlParameter("@VisitRefSource", request.RefSource);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@VistType", request.VistType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PatientType", request.PatientType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PayorID", request.PayorID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@VisitRemarks", request.Remarks);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Email", request.Email);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MobileNo", request.MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    //param = new SqlParameter("@internalDocId", request.InternalDocId);
                    //param.Direction = ParameterDirection.Input;
                    //param.DbType = DbType.Int64;
                    //cmd.Parameters.Add(param);

                    //param = new SqlParameter("@ExternalDocId", request.ExternalDocId);
                    //param.Direction = ParameterDirection.Input;
                    //param.DbType = DbType.Int64;
                    //cmd.Parameters.Add(param);


                    cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet Web_OPBill_Receipt(OPBillRecepitHead request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;

            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.Web_OPBill_Receipt))
                {
                    param = new SqlParameter("@Mpat_PatientId_id", request.UHID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Opbl_DoctorCode_cd", request.DoctorID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserID", request.UserID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Opbl_GrossAmount_nbr", request.GrossAmount);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Decimal;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Opbl_DiscAmount_nbr", request.DiscountAmount);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Decimal;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Opbl_GLAmount_nbr", request.GLAmount);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Decimal;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Opbl_PatientResponsibility_desc", request.PatientResponsibility);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Opbl_NetAmount_nbr", request.NetAmount);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Decimal;
                    Cmd.Parameters.Add(param);

                    var dt = new DataTable();

                    dt.Columns.Add("Preg_RegistrationId_id", typeof(int));
                    dt.Columns.Add("Mchr_ChargeId_id", typeof(int));
                    dt.Columns.Add("Opbl_Unit_nbr", typeof(int));
                    dt.Columns.Add("Opbl_Rate_nbr", typeof(decimal));
                    dt.Columns.Add("Opbl_DiscountType_cd", typeof(int));
                    dt.Columns.Add("Opbl_Discount_nbr", typeof(decimal));
                    dt.Columns.Add("Opbl_NetAmt_nbr", typeof(decimal));
                    dt.Columns.Add("Prio_PriorityType_Desc", typeof(int));
                    dt.Columns.Add("Opbl_Remarks_desc", typeof(string));

                    for (int i = 0; i < request.OPBillRecepitLine.Count; i++)
                    {
                        var row = dt.NewRow();

                        row["Preg_RegistrationId_id"] = request.OPBillRecepitLine[i].RegistrationID;
                        row["Mchr_ChargeId_id"] = request.OPBillRecepitLine[i].ServiceID;
                        row["Opbl_Unit_nbr"] = request.OPBillRecepitLine[i].Unit;
                        row["Opbl_Rate_nbr"] = request.OPBillRecepitLine[i].Rate;
                        row["Opbl_DiscountType_cd"] = request.OPBillRecepitLine[i].DiscType;
                        row["Opbl_Discount_nbr"] = request.OPBillRecepitLine[i].Discount;
                        row["Opbl_NetAmt_nbr"] = request.OPBillRecepitLine[i].Amount;
                        row["Prio_PriorityType_Desc"] = request.OPBillRecepitLine[i].PriorityID;
                        row["Opbl_Remarks_desc"] = request.OPBillRecepitLine[i].Remarks;
                        dt.Rows.Add(row);
                        dt.AcceptChanges();
                    }

                    param = new SqlParameter("@tblInvstigation", dt);
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.Structured;
                    Cmd.Parameters.Add(param);


                    var dt1 = new DataTable();

                    dt1.Columns.Add("PayType", typeof(string));
                    dt1.Columns.Add("amount", typeof(decimal));
                    dt1.Columns.Add("CardNo", typeof(string));


                    for (int i = 0; i < request.OPReceipt_Payment_Line.Count; i++)
                    {
                        var row = dt1.NewRow();

                        row["PayType"] = request.OPReceipt_Payment_Line[i].PayMode;
                        row["amount"] = request.OPReceipt_Payment_Line[i].Amount;
                        row["CardNo"] = request.OPReceipt_Payment_Line[i].RefNo;

                        dt1.Rows.Add(row);
                        dt1.AcceptChanges();
                    }

                    param = new SqlParameter("@Web_OPReceipt_Payment_Type", dt1);
                    param.Direction = ParameterDirection.Input;
                    param.SqlDbType = SqlDbType.Structured;
                    Cmd.Parameters.Add(param);


                    Cmd.CommandTimeout = 100;
                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetPatientMas_List_v1(int PatientID)
        {
            DataSet ds = new DataSet();
            SqlParameter param;

            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.GetPatientMas_List_web))
                {

                    param = new SqlParameter("@appPatID", PatientID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);


                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet Get_PatDepositeDtl(int PatientID)
        {
            DataSet ds = new DataSet();
            SqlParameter param;

            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.Web_PatientDtlforDepEntry))
                {

                    param = new SqlParameter("@PatientID", PatientID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);


                    Cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet GetwebPatientDtl(string Type, string search)
        {
            SqlParameter param;
            DataSet ds = new DataSet();

            try
            {
                using (DbCommand cmd = db_Master.GetStoredProcCommand(MediDBConstants.Web_Patient_DtlNew))
                {
                    param = new SqlParameter("@Type", Type);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@search", search);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(cmd);

                };
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return ds;

        }
        
        public DataSet WebSave_QMS_Details(Save_QMSDetails request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand cmd = db_HelpDeskIT.GetStoredProcCommand(MediDBConstants.WebSAVE_QMS_Details))
                {

                    param = new SqlParameter("@Name", request.PatientName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MobileNo", request.MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", request.Type);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    cmd.CommandTimeout = 30;
                    ds = db_HelpDeskIT.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet SavePatientDetails(reqimg request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand cmd = db_Image_Upload.GetStoredProcCommand(MediDBConstants.Sp_Image_save))
                {
                    param = new SqlParameter("@UHID", request.UHID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@temppath", request.temppath );
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PatientName", request.PatientName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MobileNo", request.MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@DocumentPath", request.DocumentPath);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@LastModifiedDate", request.LastModifiedDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DocumentName", request.DocumentName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

            
                    param = new SqlParameter("@TempPath_FileName", request.TempPath_FileName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

           
                    cmd.CommandTimeout = 30;
                    ds = db_Image_Upload.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet import(Patient_Portal_PathModel request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand cmd = db_Image_Upload.GetStoredProcCommand(MediDBConstants.Sp_import))
                {
                    param = new SqlParameter("@UHID", request.UHID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@PatientName", request.PatientName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MobileNo", request.MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DocumentName", request.DocumentName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DocumentPath", request.DocumentPath);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    cmd.CommandTimeout = 30;
                    ds = db_Image_Upload.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetImageDetails()
        {
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Image_Upload.GetStoredProcCommand(MediDBConstants.Sp_GetImageDetails))
                {
                    Cmd.CommandTimeout = 30;
                    ds = db_Image_Upload.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet WebSave_QMS_Details_test(Save_QMSDetails request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand cmd = db_HelpDeskIT.GetStoredProcCommand(MediDBConstants.WebSAVE_QMS_Details_test))
                {

                    param = new SqlParameter("@Name", request.PatientName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MobileNo", request.MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", request.Type);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    cmd.CommandTimeout = 30;
                    ds = db_HelpDeskIT.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet Get_QMS_Details(string FromDate, string ToDate, string Type)
        {
            SqlParameter param;
            DataSet ds = new DataSet();

            try
            {
                using (DbCommand cmd = db_HelpDeskIT.GetStoredProcCommand(MediDBConstants.Web_QMS_Details))
                {
                    param = new SqlParameter("@FromDate", FromDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ToDate", ToDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", Type);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    cmd.CommandTimeout = 30;
                    ds = db_HelpDeskIT.ExecuteDataSet(cmd);

                };
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return ds;

        }

        public DataSet Get_QMS_Details_test(string FromDate, string ToDate, string Type)
        {
            SqlParameter param;
            DataSet ds = new DataSet();

            try
            {
                using (DbCommand cmd = db_HelpDeskIT.GetStoredProcCommand(MediDBConstants.Web_QMS_Details_test))
                {
                    param = new SqlParameter("@FromDate", FromDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ToDate", ToDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Type", Type);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    cmd.CommandTimeout = 30;
                    ds = db_HelpDeskIT.ExecuteDataSet(cmd);

                };
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return ds;

        }


        public DataSet Get_appointmentList(string Search)
        {
            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.AppointmentListing_Procedure))
                {
                    param = new SqlParameter("@Search", Search);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                    Cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }



        public DataSet Get_appointmentList_v1(string FromDate, string ToDate)
        {
            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.AppointmentListing_Procedure_V1))
                {
                    param = new SqlParameter("@FromDate", FromDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ToDate", ToDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet appointmentList_All(string FromDate, string ToDate)
        {
            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.AppointmentListing_Procedure_All))
                {
                    param = new SqlParameter("@FromDate", FromDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ToDate", ToDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet Get_Web_Deposite_Reprint(string FromDate, string ToDate, int Uhid)
        {
            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.DepositReprint_Procedure))
                {
                    param = new SqlParameter("@FromDate", FromDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ToDate", ToDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Uhid", Uhid);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet Get_DepositeReprintOutput(string ReceiptNo)
        {

            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.DepositeReprint_Output))
                {
                    param = new SqlParameter("@ReceiptNo", ReceiptNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                    Cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet Get_WEB_SP_QMSStatus_Dtl(string PatientName, string MobileNo, int PatType)
        {

            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_HelpDeskIT.GetStoredProcCommand(MediDBConstants.SP_QMSStatus_Dtl))
                {

                    param = new SqlParameter("@PatientName", PatientName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@MobileNo", MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@PatType", PatType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_HelpDeskIT.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet RadiologyAppointmentStatus(string DoctorName, int UHID, int APPID, int PatType)
        {

            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Que.GetStoredProcCommand(MediDBConstants.SP_RadiologyAppointmentStatus))
                {

                    param = new SqlParameter("@DoctorName", DoctorName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@APPID", APPID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@UHID", UHID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@PatType", PatType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Que.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet RadiologyAppointmentStatus_v1(string DoctorName, int UHID, int APPID, string PatType)
        {

            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Que.GetStoredProcCommand(MediDBConstants.SP_RadiologyAppStatus_v1))
                {

                    param = new SqlParameter("@DoctorName", DoctorName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@APPID", APPID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@UHID", UHID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@PatType", PatType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Que.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet Get_DaywiseQMS_Data_V1()
        {
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_HelpDeskIT.GetStoredProcCommand(MediDBConstants.Sp_DaywiseQMS_Data_V1))
                {
                   
                    Cmd.CommandTimeout = 30;
                    ds = db_HelpDeskIT.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet Get_QMS_TVData()
        {
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_HelpDeskIT.GetStoredProcCommand(MediDBConstants.SP_QMS_TVData))
                {
                    Cmd.CommandTimeout = 30;
                    ds = db_HelpDeskIT.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet UpdateQMSStatus_Dtl(Save_QMSDetails req)
        {

            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_HelpDeskIT.GetStoredProcCommand(MediDBConstants.Web_SP_QMSStatus_Dtl))
                {

                    param = new SqlParameter("@PatientName",req.PatientName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@MobileNo", req.MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@PatType", req.Type);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    //param = new SqlParameter("@Status", req.Status);
                    //param.Direction = ParameterDirection.Input;
                    //param.DbType = DbType.Int32;
                    //Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_HelpDeskIT.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet UpdateQMSStatus_Dtl_test(Save_QMSDetails req)
        {

            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_HelpDeskIT.GetStoredProcCommand(MediDBConstants.Web_SP_QMSStatus_Dtl_test))
                {

                    param = new SqlParameter("@PatientName", req.PatientName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@MobileNo", req.MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@PatType", req.Type);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@username", req.username);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_HelpDeskIT.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet Get_WEB_DayWiseQMS_Dtl()
        {

            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_HelpDeskIT.GetStoredProcCommand(MediDBConstants.SP_QMSDayWise_Dtl))
                {
                    Cmd.CommandTimeout = 30;
                    ds = db_HelpDeskIT.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet Get_RadiologyAppointment()
        {

            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Que.GetStoredProcCommand(MediDBConstants.SP_RadiologyAppointment))
                {
                    Cmd.CommandTimeout = 30;
                    ds = db_Que.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet Get_RadiologyAppointment_Modality()
        {

            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Que.GetStoredProcCommand(MediDBConstants.SP_RadiologyApp_modality))
                {
                    Cmd.CommandTimeout = 30;
                    ds = db_Que.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet Get_WEB_DayWiseQMS_Dtl_test()
        {

            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_HelpDeskIT.GetStoredProcCommand(MediDBConstants.SP_QMSDayWise_Dtl_test))
                {
                    Cmd.CommandTimeout = 30;
                    ds = db_HelpDeskIT.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet Get_WEB_DepPatAmt_Details(int UHID)
        {
            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.SP_DepPatAmt_Details))
                {
                    param = new SqlParameter("@UHID", UHID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet Get_web_DepositType_Dtl()
        {

            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.SP_DepositType_Dtl))
                {
                    Cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet Get_opList(string Type, string Search)
        {
            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.opLIST_Procedure))
                {

                    param = new SqlParameter("@VisitType", Type);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Search", Search);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetVisitData(string type)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.GetVisitProcedure))
                {


                    param = new SqlParameter("@strType", type);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetPatientRegOutPutPdf(int RegId)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand cmd = db_Institution.GetStoredProcCommand(MediDBConstants.PatientRegOutputPdf))
                {
                    param = new SqlParameter("@RegId", RegId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    cmd.Parameters.Add(param);

                    cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;

        }
        public DataSet OpReprint_V1(int BillNo)//prabha03/12/2021
        {
            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand cmd = db_Institution.GetStoredProcCommand(MediDBConstants.Op_InvoiceReprint_Out_V1))
                {
                    param = new SqlParameter("@BillNo", BillNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    cmd.Parameters.Add(param);

                    cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(cmd);

                };
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return ds;
        }

        public DataSet get_WebRef_pat(int appPatID)
        {

            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.Web_Ref_pat))
                {
                    param = new SqlParameter("@appPatID", appPatID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet OpInvoice_Reprint_List(string FromDate, string ToDate, string type, string search)
        {
            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand cmd = db_Institution.GetStoredProcCommand(MediDBConstants.web_Invoice_Reprint_List_procedure))
                {
                    param = new SqlParameter("@fromdate", FromDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@todate", ToDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@VisitType", type);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Search", search);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(cmd);

                };
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return ds;
        }


        public DataSet Package_Patient_venue()
        {
            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand cmd = db_Master.GetStoredProcCommand(MediDBConstants.Sp_Package_Patient_venue))
                {
                    cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(cmd);

                };
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return ds;
        }



        public DataSet Package_master()
        {
            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand cmd = db_Institution.GetStoredProcCommand(MediDBConstants.Sp_Package_master))
                {
                    cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(cmd);

                };
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return ds;
        }

        public DataSet Test_master()
        {
            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand cmd = db_Institution.GetStoredProcCommand(MediDBConstants.Sp_Test_master))
                {
                    cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(cmd);

                };
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return ds;
        }
        public DataSet BedRateAndNursingRate_dtl(int Bedcategoryid)
        {
            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand cmd = db_RMC_IP.GetStoredProcCommand(MediDBConstants.SP_BedRateAndNursingRate_dtl))
                {
                    param = new SqlParameter("@Bedcategoryid", Bedcategoryid);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    cmd.Parameters.Add(param);


                    cmd.CommandTimeout = 30;
                    ds = db_RMC_IP.ExecuteDataSet(cmd);

                };
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return ds;
        }



        public DataSet web_sp_BedDetails_Load(int CatId) 
        {
            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand cmd = db_RMC_IP.GetStoredProcCommand(MediDBConstants.sp_BedDetails_Load))
                {
                    param = new SqlParameter("@CatId", CatId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    cmd.Parameters.Add(param);


                    cmd.CommandTimeout = 30;
                    ds = db_RMC_IP.ExecuteDataSet(cmd);

                };
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return ds;
        }



        public DataSet AuthenticateMobNo_Upload_V1(string OTP_MobileNo, int Otp)
        {
            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand cmd = db_Image_Upload.GetStoredProcCommand(MediDBConstants.SP_AuthenticateMobNo_Upload_V1))
                {
                    param = new SqlParameter("@OTP_MobileNo", OTP_MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Otp", Otp);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    cmd.Parameters.Add(param);


                    cmd.CommandTimeout = 30;
                    ds = db_Image_Upload.ExecuteDataSet(cmd);

                };
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return ds;
        }

        public DataSet web_sp_Get_BedID(int BedId)
        {
            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand cmd = db_RMC_IP.GetStoredProcCommand(MediDBConstants.sp_Get_BedID))
                {
                    param = new SqlParameter("@BedId", BedId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    cmd.Parameters.Add(param);


                    cmd.CommandTimeout = 30;
                    ds = db_RMC_IP.ExecuteDataSet(cmd);

                };
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return ds;
        }

        public DataSet BedBlockDetails_Load()
        {

            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_RMC_IP.GetStoredProcCommand(MediDBConstants.Sp_BedBlockDetails_Load))
                {
                    Cmd.CommandTimeout = 30;
                    ds = db_RMC_IP.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet Get_CriticalCare_InfectiousDis()
        {

            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_HelpDeskIT.GetStoredProcCommand(MediDBConstants.SP_CriticalCare_InfectiousDis))
                {
                    Cmd.CommandTimeout = 30;
                    ds = db_HelpDeskIT.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet Get_web_RadLandingScreen_Dtl(string dtFrom, string dtTo, int blnOrderwise)
        {

            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Radiology.GetStoredProcCommand(MediDBConstants.SP_RadLandingScreen_Dtl))
                {

                    param = new SqlParameter("@dtFrom", dtFrom);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@dtTo", dtTo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@blnOrderwise", blnOrderwise);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);


                    Cmd.CommandTimeout = 30;
                    ds = db_Radiology.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet Web_CardiologyLanding(string FromDate, string ToDate)
        {

            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Radiology.GetStoredProcCommand(MediDBConstants.SP_CardiologyLanding))
                {

                    param = new SqlParameter("@FromDate", FromDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ToDate", ToDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Radiology.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet FinancialCounsellingSave(FinancialCounselling_req request)

        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_RMC_IP.GetStoredProcCommand(MediDBConstants.SP_FinancialCounselling))
                {
                    param = new SqlParameter("@Patientid", request.Patientid);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@DoctorId", request.DoctorId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@DepartmentCode", request.DepartmentCode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@AdmDate", request.AdmDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.DateTime;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReqBedCat", request.ReqBedCat);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@AllotedBedCat", request.AllotedBedCat);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@RoomNumber", request.RoomNumber);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@PlanOfTreatment", request.PlanOfTreatment);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@RoomUpgrade", request.RoomUpgrade);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Boolean;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@EstimatedStay", request.EstimatedStay);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Deposit_Nbr", request.Deposit_Nbr);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@CounselledDate", request.CounselledDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.DateTime;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@CounselledId", request.CounselledId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@RoomTariff", request.RoomTariff);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@DrugConsumables", request.DrugConsumables);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Proceduresid", request.Proceduresid);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@BloodProduct", request.BloodProduct);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ICUOthers", request.ICUOthers);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Investigations", request.Investigations);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@DoctorFees", request.DoctorFees);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Others", request.Others);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@EstimatedAmt", request.EstimatedAmt);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Admissionid", request.Admissionid);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Isactive", request.Isactive);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Boolean;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreateddBy", request.CreateddBy);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ModifiedBy", request.ModifiedBy);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@PatientType", request.PatientType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@IPFC_Payor", request.IPFC_Payor);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Ispackage", request.Ispackage);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackageId", request.PackageId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Boolean;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackageInclusion", request.PackageInclusion);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@PackageExclusion", request.PackageExclusion);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ImplantCharges", request.ImplantCharges);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@TotalInsured", request.TotalInsured);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Diagnosisid", request.Diagnosisid);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@SURGICALPROCEDURE", request.SURGICALPROCEDURE);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ExpectedDeliveryDate", request.ExpectedDeliveryDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Date;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Nursingid", request.Nursingid);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@DMOId", request.DMOId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ReportInTime", request.ReportInTime);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                    ds = db_RMC_IP.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;

        }

        public DataSet web_RadPatientSearch(string FromDate, string ToDate, string MRN, string PatientName, string ApptTime, string DoctName, string Company, string MobileNo, string DeptName, int radmenu)
        {

            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Radiology.GetStoredProcCommand(MediDBConstants.SP_RadPatientSearch))
                {

                    param = new SqlParameter("@dtFrom", FromDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@dtTo", ToDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StrMRN", MRN);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StrPatientName", PatientName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StrApptTime", ApptTime);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StrDoctName", DoctName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StrCompany", Company);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StrMobileNo", MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StrDeptName", DeptName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@intradmenu", radmenu);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Radiology.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet web_NMPatientSearch(string FromDate, string ToDate, string MRN, string PatientName, string ApptTime, string DoctName, string Company, string MobileNo, string DeptName, int radmenu)
        {

            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Radiology.GetStoredProcCommand(MediDBConstants.SP_NMPatientSearch))
                {

                    param = new SqlParameter("@dtFrom", FromDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@dtTo", ToDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StrMRN", MRN);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StrPatientName", PatientName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StrApptTime", ApptTime);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StrDoctName", DoctName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StrCompany", Company);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StrMobileNo", MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StrDeptName", DeptName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@intradmenu", radmenu);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Radiology.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet web_MediScanPatientSearch(string FromDate, string ToDate, string MRN, string PatientName, string ApptTime, string DoctName, string Company, string MobileNo, string DeptName, int radmenu)
        {

            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Radiology.GetStoredProcCommand(MediDBConstants.SP_MediScanPatientSearch))
                {

                    param = new SqlParameter("@dtFrom", FromDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@dtTo", ToDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StrMRN", MRN);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StrPatientName", PatientName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StrApptTime", ApptTime);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StrDoctName", DoctName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StrCompany", Company);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StrMobileNo", MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@StrDeptName", DeptName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@intradmenu", radmenu);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Radiology.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet Web_NMLanding_Dtl(string FromDate, string ToDate)
        {

            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Radiology.GetStoredProcCommand(MediDBConstants.SP_NMLanding_Dtl))
                {

                    param = new SqlParameter("@FromDate", FromDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ToDate", ToDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Radiology.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet Web_GetRadRequisitionSlipDetail(string sPatient, string strRegID, string OrderID, string strSampleNo)
        {

            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Radiology.GetStoredProcCommand(MediDBConstants.SP_GetRadRequisitionSlipDetail))
                {

                    param = new SqlParameter("@sPatient", sPatient);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@strRegID", strRegID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderID", OrderID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@strSampleNo", strSampleNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                    Cmd.CommandTimeout = 30;
                    ds = db_Radiology.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet getPendingDetails(string processingid)
        {
            DataSet dtSettlementAllocate;
            StringBuilder sbQuery;

            try
            {
                sbQuery = new StringBuilder();
                sbQuery.Append(" Select ");
                sbQuery.Append(" *");
                sbQuery.Append(" from HIS_POSPayment_Confirmation_dtl where Onl_RefID='" + processingid + "'");

                dtSettlementAllocate = new DataSet();
                //if (DATABASETYPE.MSACCESS == ACTIVEDATABASE)
                //{
                //}
                //else if (DATABASETYPE.SQLSERVER == ACTIVEDATABASE)
                //    dtSettlementAllocate = SQLDATAACCESS.GetDataFromDatabase(sbQuery.ToString(), SQLInstitutionConnection);
                //else if (DATABASETYPE.ORACLE == ACTIVEDATABASE)
                //    dtSettlementAllocate = ORACLEDATAACCESS.GetDataFromDatabase(sbQuery.ToString(), ORACLEInstitutionConnection);

                using (DbCommand cmd = db_Institution.GetSqlStringCommand(sbQuery.ToString()))
                {
                    cmd.CommandTimeout = 30;
                    dtSettlementAllocate = db_Institution.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtSettlementAllocate;
        }
        public DataSet InsertCriticalCare_InfectiousDis(InsertCriticalCare_req request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand cmd = db_HelpDeskIT.GetStoredProcCommand(MediDBConstants.SP_InsertCriticalCare_InfectiousDis))
                {


                    param = new SqlParameter("@Name", request.Name);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Gender", request.Gender);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Email_ID", request.Email_ID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@MobileNo", request.MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Institute_Organization", request.Institute_Organization);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DOB", request.DOB);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@Designation", request.Designation);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@RegistrationNoTNMC", request.RegistrationNoTNMC);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AddressofIns_Organization", request.AddressofIns_Organization);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@AreaofInterestinCCID", request.AreaofInterestinCCID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    cmd.CommandTimeout = 30;
                    ds = db_HelpDeskIT.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet Get_Doctor_Directory_Js() 
        {

            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Rimc2019.GetStoredProcCommand(MediDBConstants.SP_Get_Doctor_Directory_Js))
                {
                    Cmd.CommandTimeout = 30;
                    ds = db_Rimc2019.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

  


        public DataSet InsertDoctor_Directory_Js(InsertDoctor_Directory_Js_req request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand cmd = db_Rimc2019.GetStoredProcCommand(MediDBConstants.Sp_InsertDoctor_Directory_Js))
                {


                    param = new SqlParameter("@doctorid", request.doctorid);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@doctorname", request.doctorname);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@department_Name", request.department_Name);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@subdepartment", request.subdepartment);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@qualification", request.qualification);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@designation", request.designation);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@profile_image", request.profile_image);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@tv_no", request.tv_no);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@slide_no", request.slide_no);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sequence_no", request.sequence_no);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@header", request.header);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    cmd.CommandTimeout = 30;
                    ds = db_Rimc2019.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet UPDATEDoctor_Directory_Js(UPDATEDoctor_Directory_Js_req request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand cmd = db_Rimc2019.GetStoredProcCommand(MediDBConstants.Sp_UPDATEDoctor_Directory_Js))
                {


                    param = new SqlParameter("@doctorid", request.doctorid);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@doctorname", request.doctorname);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@department_Name", request.department_Name);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@subdepartment", request.subdepartment);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@qualification", request.qualification);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@designation", request.designation);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@profile_image", request.profile_image);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@tv_no", request.tv_no);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@slide_no", request.slide_no);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@sequence_no", request.sequence_no);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@header", request.header);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    cmd.CommandTimeout = 30;
                    ds = db_Rimc2019.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet Get_TVbackgraound()
        {

            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Rimc2019.GetStoredProcCommand(MediDBConstants.SP_TVbackgraound))
                {
                    Cmd.CommandTimeout = 30;
                    ds = db_Rimc2019.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet UpdateTVbackgraound(UpdateTVbackgraound_req request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand cmd = db_Rimc2019.GetStoredProcCommand(MediDBConstants.Sp_UPDATETVbackgraound))
                {


                    param = new SqlParameter("@tvid", request.tvid);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@tvname", request.tvname);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@imageurl", request.imageurl);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    cmd.Parameters.Add(param);

                    cmd.CommandTimeout = 30;
                    ds = db_Rimc2019.ExecuteDataSet(cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet updateOnlinePayment(pay_request request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.Payment_Procedure))
                {
         
                    param = new SqlParameter("@Onl_PaymentID", request.PaymentID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                    param = new SqlParameter("@Onl_RefID", request.RefID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_RefType", request.RefType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                    param = new SqlParameter("@Onl_PatientID", request.PatientID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_PatientName", request.PatientName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_MobileNo", request.MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_Email", request.EmailID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_DoctorID", request.DoctorID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_TransactionDate", request.TransactionDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_TransactionID", request.TransactionID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                    param = new SqlParameter("@Onl_TransactionAmount", request.TransactionAmount);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_PaymentMode", request.PaymentMode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_StatusCode", request.StatusCode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_StatusMsg", request.StatusMsg);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_PaymentStatus", request.PaymentStatus);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_Remarks", request.Remarks);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_IsActiveflg", request.IsActiveflg);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);


                    param = new SqlParameter("@Onl_CreatedCode", request.CreatedCode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                    //param = new SqlParameter("@Religion", request.Religion);
                    //param.Direction = ParameterDirection.Input;
                    //param.DbType = DbType.String;
                    //Cmd.Parameters.Add(param);

                    //param = new SqlParameter("@PrefferedLanguage", request.PrefferedLanguage);
                    //param.Direction = ParameterDirection.Input;
                    //param.DbType = DbType.String;
                    //Cmd.Parameters.Add(param);

                    //param = new SqlParameter("@annualIncome", request.annualIncome);
                    //param.Direction = ParameterDirection.Input;
                    //param.DbType = DbType.Int16;
                    //Cmd.Parameters.Add(param);

                    //param = new SqlParameter("@bloodGroup", request.bloodGroup);
                    //param.Direction = ParameterDirection.Input;
                    //param.DbType = DbType.String;
                    //Cmd.Parameters.Add(param);

                    param = new SqlParameter("@APPStartDate", request.APPStartDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@APPEndDate", request.APPEndDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@AppointmentId", request.AppointmentId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);


                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        //public DataSet AuthenticateMobNo_Upload_V1(Auth_request request)
        //{
        //    DataSet ds = new DataSet();
        //    SqlParameter param;
        //    try
        //    {
        //        using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.SP_AuthenticateMobNo_Upload_V1))
        //        {
        //            param = new SqlParameter("@OTP_MobileNo", request.MobileNo);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            Cmd.Parameters.Add(param);

        //            param = new SqlParameter("@Otp", request.Otp);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            Cmd.Parameters.Add(param);

        //            ds = db_Master.ExecuteDataSet(Cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}

        public DataSet Get_BirthDay_Info_New(string date)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_R012424.GetStoredProcCommand(MediDBConstants.SP_BirthDay_Info_New))
                {
                    param = new SqlParameter("@date", date);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    ds = db_R012424.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        
        public DataSet SP_OPIPREVENUE(string FromDate, string ToDate, string Pattype, int IVF_flg)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_RMC_PACS_Interface.GetStoredProcCommand(MediDBConstants.SP_OPIPREVENUE))
                {
                    param = new SqlParameter("@FromDate", FromDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Date;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ToDate", ToDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Date;
                    Cmd.Parameters.Add(param);


                    param = new SqlParameter("@Pattype", Pattype);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@IVF_flg", IVF_flg);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    ds = db_RMC_PACS_Interface.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet Kranium_EMRAPILog(string Fdate, string tdate, string Status)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_RMC_EMR.GetStoredProcCommand(MediDBConstants.SP_Kranium_EMRAPILog))
                {
                    param = new SqlParameter("@Fdate", Fdate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@tdate", tdate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                    param = new SqlParameter("@Status", Status);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                    ds = db_RMC_EMR.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        //public DataSet Get_opd_Process(string Todate)
        //{

        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.sp_opd_Process_Get))
        //        {
        //            param = new SqlParameter("@Todate", Todate);
        //            param.Direction = ParameterDirection.Input;
        //            param.DbType = DbType.String;
        //            Cmd.Parameters.Add(param);

        //            ds = db_Institution.ExecuteDataSet(Cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}

        public DataSet Get_opd_Process(string Todate)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.sp_opd_Process_Get))
                {
                    param = new SqlParameter("@Todate", Todate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);      

                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet Get_opd_Process_v1(string Todate, int Type)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.sp_opd_Process_Get_v1))
                {
                    param = new SqlParameter("@Todate", Todate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                    param = new SqlParameter("@Type", Type);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet UpdateQCEMRDashboard_Visit(string Todate, int VisitId)          
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.sp_qcupdate_visit))
                {
                    param = new SqlParameter("@Todate", Todate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                    param = new SqlParameter("@VisitId", VisitId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }



        //public DataSet Get_opd_Process()
        //{
        //    DataSet ds = new DataSet();
        //    try
        //    {
        //        using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.sp_opd_Process_Get))
        //        {
        //            Cmd.CommandTimeout = 30;
        //            ds = db_Institution.ExecuteDataSet(Cmd);
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return ds;
        //}


        public DataSet updatePOSPayment(payment_request request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.POS_Procedure))
                {
                    param = new SqlParameter("@Onl_RefID", request.RefID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_RefType", request.RefType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_PatientID", request.PatientID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_PatientName", request.PatientName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_MobileNo", request.MobileNo);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_Email", request.EmailID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_DoctorID", request.DoctorID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_TransactionDate", request.TransactionDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.DateTime;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_TransactionID", request.TransactionID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_TransactionAmount", request.TransactionAmount);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_PaymentMode", request.PaymentMode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_cardType", request.CardType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_cardNumber", request.CardNumber);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_cardHolderName", request.CardHolderName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_approvalCode", request.ApprovalCode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_payment_method", request.PaymentMethod);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_StatusCode", request.StatusCode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_StatusMsg", request.StatusMsg);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_PaymentStatus", request.PaymentStatus);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_Remarks", request.Remarks);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_IsActiveflg", request.IsActiveflg);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Onl_CreatedCode", request.CreatedCode);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet save_opd_Process_Dtl(requestDtl request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.sp_his_opd_Process_Dtl))
                {
                    param = new SqlParameter("@OPD_Prcess_nbr", request.OPD_Prcess_nbr);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Study_Start", request.Study_Start);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Study_Authorized", request.Study_Authorized);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Sample_Collected", request.Sample_Collected);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Lab_Authorized", request.Lab_Authorized);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Admission_Status", request.Admission_Status);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Billing_status", request.Billing_status);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                    param = new SqlParameter("@Vitals_Completed_time", request.Vitals_Completed_time);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Doctor_Checkin", request.Doctor_Checkin);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Followup_Appointment", request.Followup_Appointment);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Followup_Billed", request.Followup_Billed);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Admission_advised", request.Admission_advised);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                    param = new SqlParameter("@Rad_Investigations_Billed", request.Rad_Investigations_Billed);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Lab_Investigations_Billed", request.Lab_Investigations_Billed);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Proc_Billed", request.Proc_Billed);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Procedure_Advised", request.Procedure_Advised);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet SaveOrUpdateQCVisittracking(req_Visittracking request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.sp_QCvisit))
                {

                    param = new SqlParameter("@Preg_RegistrationId_id", request.VisitId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Vitals_Completed_time", request.Vitals_Completed_time);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Doctor_Checkin", request.Doctor_Checkin);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Procedure_Advised", request.Procedure_Advised);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Admission_advised", request.Admission_Advised);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Admission_Status", request.Admission_Status);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@CreatedId", request.CreatedId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ModifyId", request.ModifyId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                   ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet SaveEMROTDet(req_EMROTDetl request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_RMC_IP.GetStoredProcCommand(MediDBConstants.sp_SaveEMROTDet))
                {

                    param = new SqlParameter("@AdmissionId", request.AdmissionId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@LocationId", request.LocationId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Startdate", request.Startdate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Endate", request.Endate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Starttime", request.Starttime);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Endtime", request.Endtime);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Ottype", request.Ottype);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    ds = db_RMC_IP.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet SaveOrUpdateQCOrderTracking(req_OrderTracking request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.sp_QCorder))
                {



                    param = new SqlParameter("@Preg_RegistrationId_id", request.VisitId);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@InvestigationOrder", request.InvestigationOrder);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Billed", request.Billed);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@InvestigationStart", request.InvestigationStart);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@InvestigationAuthorized", request.InvestigationAuthorized);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@InvestigationType", request.InvestigationType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Createdid", request.Createdid);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@LastModifyid", request.LastModifyid);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }






        public DataSet save_e_certificate(requeste_cert request)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_Image_Upload.GetStoredProcCommand(MediDBConstants.sp_save_e_cert))
                {


                    param = new SqlParameter("@firstName", request.firstName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@lastName", request.lastName);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@satisfaction", request.satisfaction);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@organization", request.organization);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@contentExpectation", request.contentExpectation);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@presentationQuality", request.presentationQuality);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@networking", request.networking);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);


                    param = new SqlParameter("@venueFacilities", request.venueFacilities);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@exercisesQuality", request.exercisesQuality);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@timeManagement", request.timeManagement);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@suggestions", request.suggestions);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@additionalComments", request.additionalComments);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    ds = db_Image_Upload.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet Get_Doctor_TV(string TvTag)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                using (DbCommand Cmd = db_PatientPortal.GetStoredProcCommand(MediDBConstants.sp_doctor_tv))
                {
                    param = new SqlParameter("@TvTag", TvTag);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.String;
                    Cmd.Parameters.Add(param);

                    ds = db_PatientPortal.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetAppointmentSlot_Web(SlotReq_DTO slotReq_DTO)
        {
            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                //DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.GetAppointmentSlot_Procedure)
                using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.GetAppointmentSlot_Procedure_Web))
                {
                    param = new SqlParameter("@APPDate", slotReq_DTO.SlotDate);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.DateTime;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@ConsId", slotReq_DTO.DoctorID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@Slottype", slotReq_DTO.SlotType);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int64;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Institution.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet GetDoctorNameDepWiseDocID(DepartmentwiseDoctorFilter dep)
        {
            SqlParameter param;
            DataSet ds = new DataSet();
            try
            {
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.GetDoctorDetailsDepwiseDocID_SP))
                {
                    param = new SqlParameter("@DepID", dep.DepID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    param = new SqlParameter("@DoctorID", dep.DoctorID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    Cmd.CommandTimeout = 30;
                    ds = db_Master.ExecuteDataSet(Cmd);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet update_appointment(AppointmentBooking appointmentBooking)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                long UHID = 0;
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.UHID_Procedure))
                {
                    param = new SqlParameter("@UHID", appointmentBooking.UHID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    UHID = Convert.ToInt64(db_Master.ExecuteScalar(Cmd));
                }

                if (UHID > 0 && UHID != 0)
                {
                    //using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.Existing_AppointmentProcedure))
                    using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.BookAppointment_ExistingPatient_new))
                    {
                        param = new SqlParameter("@UHID", appointmentBooking.UHID);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Int32;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@DocId", appointmentBooking.DocId);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Int32;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@APPStartDate", appointmentBooking.APPStartDate);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.DateTime;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@APPEndDate", appointmentBooking.APPEndDate);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.DateTime;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@UserId", appointmentBooking.UserId);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.String;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@Appcd", appointmentBooking.Appcd);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Int32;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@PaymentType", appointmentBooking.PaymentType);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Int32;
                        Cmd.Parameters.Add(param);

                        ds = db_Institution.ExecuteDataSet(Cmd);
                    };
                }
                else
                {
                    //using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.New_AppointmentProcedure))
                    using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.BookAppointment_NewPatient_new))
                    {
                        param = new SqlParameter("@PatientName", appointmentBooking.PatientName);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.String;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@Sal", appointmentBooking.Salutation);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.String;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@MobileNo", appointmentBooking.MobileNo);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.String;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@PhoneNo1", appointmentBooking.PhoneNo1);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.String;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@DocId", appointmentBooking.DocId);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Int32;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@APPStartDate", appointmentBooking.APPStartDate);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.DateTime;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@APPEndDate", appointmentBooking.APPStartDate);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.DateTime;
                        Cmd.Parameters.Add(param);

                        string Gval = "";
                        switch (appointmentBooking.Gender)
                        {
                            case "Male":
                                Gval = "M";
                                break;
                            case "Female":
                                Gval = "F";
                                break;
                            case "Third Gender":
                                Gval = "T";
                                break;
                        }
                        param = new SqlParameter("@Gender", Gval);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.String;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@UserId", appointmentBooking.UserId);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.String;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@DOB", appointmentBooking.DOB);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Date;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@Nationality", appointmentBooking.CountryCode);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.String;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@Appcd", appointmentBooking.Appcd);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Int32;
                        Cmd.Parameters.Add(param);

                        ds = db_Institution.ExecuteDataSet(Cmd);
                    };
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }


        public DataSet update_appointment_seq(AppointmentBooking_seq appointmentBooking_seq)
        {
            DataSet ds = new DataSet();
            SqlParameter param;
            try
            {
                long UHID = 0;
                using (DbCommand Cmd = db_Master.GetStoredProcCommand(MediDBConstants.UHID_Procedure))
                {
                    param = new SqlParameter("@UHID", appointmentBooking_seq.UHID);
                    param.Direction = ParameterDirection.Input;
                    param.DbType = DbType.Int32;
                    Cmd.Parameters.Add(param);

                    UHID = Convert.ToInt64(db_Master.ExecuteScalar(Cmd));
                }

                if (UHID > 0 && UHID != 0)
                {
                   
                    using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.BookAppointment_ExistingPatient_new_seq))
                    {
                        param = new SqlParameter("@UHID", appointmentBooking_seq.UHID);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Int32;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@DocId", appointmentBooking_seq.DocId);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Int32;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@APPDate", appointmentBooking_seq.APPDate);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.String;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@APPSeqno", appointmentBooking_seq.APPSeqno);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Int32;
                        Cmd.Parameters.Add(param);

                        

                        //param = new SqlParameter("@APPEndDate", appointmentBooking.APPEndDate);
                        //param.Direction = ParameterDirection.Input;
                        //param.DbType = DbType.DateTime;
                        //Cmd.Parameters.Add(param);

                        param = new SqlParameter("@UserId", appointmentBooking_seq.UserId);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.String;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@Appcd", appointmentBooking_seq.Appcd);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Int32;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@PaymentType", appointmentBooking_seq.PaymentType);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Int32;
                        Cmd.Parameters.Add(param);

                        ds = db_Institution.ExecuteDataSet(Cmd);
                    };
                }
                else
                {
                    
                    using (DbCommand Cmd = db_Institution.GetStoredProcCommand(MediDBConstants.BookAppointment_NewPatient_new_seq))
                    {
                        param = new SqlParameter("@PatientName", appointmentBooking_seq.PatientName);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.String;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@Sal", appointmentBooking_seq.Salutation);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.String;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@MobileNo", appointmentBooking_seq.MobileNo);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.String;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@PhoneNo1", appointmentBooking_seq.PhoneNo1);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.String;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@DocId", appointmentBooking_seq.DocId);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Int32;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@APPSeqno", appointmentBooking_seq.APPSeqno);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Int32;
                        Cmd.Parameters.Add(param);

                        //param = new SqlParameter("@APPEndDate", AppointmentBooking_seq.APPStartDate);
                        //param.Direction = ParameterDirection.Input;
                        //param.DbType = DbType.DateTime;
                        //Cmd.Parameters.Add(param);

                        string Gval = "";
                        switch (appointmentBooking_seq.Gender)
                        {
                            case "Male":
                                Gval = "M";
                                break;
                            case "Female":
                                Gval = "F";
                                break;
                            case "Third Gender":
                                Gval = "T";
                                break;
                        }
                        param = new SqlParameter("@Gender", Gval);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.String;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@UserId", appointmentBooking_seq.UserId);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.String;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@DOB", appointmentBooking_seq.DOB);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Date;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@Nationality", appointmentBooking_seq.CountryCode);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.String;
                        Cmd.Parameters.Add(param);

                        param = new SqlParameter("@Appcd", appointmentBooking_seq.Appcd);
                        param.Direction = ParameterDirection.Input;
                        param.DbType = DbType.Int32;
                        Cmd.Parameters.Add(param);

                        ds = db_Institution.ExecuteDataSet(Cmd);
                    };
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

    }
}