using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace DALayer
{
    public static class MediDBConstants
    {
        #region
        public const string Login = "HIS_SP_RIMCLogin";//arun 05012023
        public const string UserLogin = "User_login";// suji 30/03/2024
        public const string Sp_patLogin = "HIS_SP_patient_tracking_login";// suji 30/03/2024
        public const string Sp_signimage = "Sp_signimage";// suji 30/03/2024
        public const string SaveUserLogin = "SaveUser_login";// suji 30/03/2024                                            
        public const string House_Keeping_List_Save = "sp_HouseKeepingList";//arun
        public const string RestRoom_Check_List_Save = "sp_RestRoomCheckList";//arun
        public const string Portal_Patient_dTL = "HIS_SP_Patient_Portal";//prabha
      //  public const string Portal_Patient_dTL = "sp_web_patient_portal";//29/03/2024
        public const string Get_Patient_Portal_MHC = "HIS_SP_Patient_Portal_MHC";//prabha
        public const string InsertUpdateOTP_Portal = "WebAPI_CheckOTP_Upload";
        public const string AuthenticateMobNo = "WebAPI_AuthenticateMobNo_Upload";
        public const string Get_Patient_Details = "WebAPI_Patient_Details";
        public const string SaveAppointmentSlot = "sp_web_app_Slot_Save";
        public const string Update_RefId = "sp_update_RefId";//prabha 
        public const string TempToUHIDGen_Procedure = "SP_TempToCreateUHID";//prabha 
        public const string Ot_Schedule_screen = "sp_web_otsurgery_dtl";//prabha
        public const string Ot_getdetails = "SP_GET_WEBOT";//prabha
        public const string doctor_directory = "sp_Doctor_Ditrectory";//prabha
        public const string get_License_Dtl = "sp_web_license_duecount";//prabha
        public const string get_AppSolt_Dtl = "sp_AppSlot";//prabha
        public const string otexcel_save = "sp_web_otexcel"; //prabha 29072023
        public const string DocDirImg_save = "sp_Web_DocDirectory_Img"; //prabha 29072023
        public const string DocDirImg_save_VIEW = "sp_Web_DocDirectory_Img_VIEW"; //prabha 29072023 
        public const string SP_DocDirImg_import = "usp_ImportImage_v1"; //sujithra 20012024
        public const string SP_DocDirImg_export = "sp_ExportImage";  //sujithra 20012024
        public const string save_signimage = "save_signimage";  //sujithra 20012024
      
        public const string Ticketing_Count = "sp_web_TicketingCount_DTL"; //prabha 
        public const string DepWiseTicketing_Count = "sp_web_DepWiseTicketingCnt_DTL"; //prabha 
        public const string doctor_directory_EditDtl = "sp_DocDitrectory_editDtl"; //prabha 
        public const string doctor_directory_Img_List = "sp_Web_DocDirectory_Img_List"; //prabha 
        public const string doctor_directory_Img_View_List = "sp_Web_DocDirectory_Img_View_List"; //prabha 
        public const string Insert_NewDoc_Dir = "sp_InsertNewDocDir"; //prabha 29072023
        public const string Update_NewDoc_Dir = "sp_UpdatedDocDir"; //prabha 29072023
        public const string Delete_NewDoc_Dir = "sp_DeletDocDir"; //prabha 29072023
       // public const string Sp_DeleteFilefromDisk = "sp_DeletePatient_Portal"; //sujithra 01/03/2024                                                                   
        public const string Payment_Gateway = "web_PaymentGateWay"; //prabha 29072023
        public const string Get_PaymentGetWay_List = "web_PaymentGateWay_List"; //prabha 29072023
        public const string BB_BloodGroup = "BB_SP_BloodGroup"; //prabha 29072023
        public const string OPD_MasterProc_api = "HIS_SP_MasterPat_Details"; //prabha 280972023
        public const string GetSalutationsData = "HIS_SP_GetSalutationsData ";//prabha 12122023
        public const string Web_Ref_source_Procedure = "HIS_SP_REF_SOURCE";//prabha 12122023
        public const string GetDepartmentProcedure = "HIS_SP_Get_Department";//prabha 12122023
        public const string GetMobileCodeProcedure = "HIS_SP_MobileCode_Data";//prabha 12122023
        public const string GetCountriesData = "HIS_SP_GetCountriesData";//prabha 12122023
        public const string ServiceLoad_Procedure = "HIS_SP_ServiceLoad";//prabha 12122023
        public const string Priority_Procedure = "HIS_SP_Priority";//prabha 12122023
        public const string GetNationalityData = "HIS_SP_GetNationalityData";//prabha 12122023
        public const string web_ExternalDoc_Data = "HIS_SP_ExternalDoc_Dtl";//prabha 12122023
        public const string Master_Blood_Group = "HIS_SP_MasBloodGroup_dtl";//prabha 12122023
        public const string web_Relationship_procedure = "HIS_SP_Relationship";//prabha 12122023
        public const string SP_SurgProcname_Dtl = "web_sp_SurgProcname_Dtl";//Sujithra 30122023
        public const string SP_FinancialCounsellingprint = "Web_FinancialCounsellingprint";//Sujithra 30122023
        public const string Sp_FinCouncil_Detail_Load = "web_Sp_FinCouncil_Detail_Load";//Sujithra 02012023                                                                                           
        public const string web_religion_hdr = "HIS_SP_MasReligion_hdr";//prabha 12122023
        public const string GetStateData = "HIS_SP_GetStateData";//prabha 12122023
        public const string GetOccupationData = "HIS_SP_GetOccupationData";//prabha 12122023
        public const string GetBed_Report = "Web_Bed_Report";//sujithra 26022024
        public const string ChargeMasterLoad_Procedure_v1 = "HIS_SP_ChargeMasterLoad_v1";//prabha 12122023
        public const string GetCityDtl_Statewise = "HIS_SP_GetCityData";//prabha 12122023
        public const string GetMaritalStatusData = "HIS_SP_GetMaritalStatusData";//prabha 12122023
        public const string GetAreaProcedure = "HIS_SP_PinCodeWise_Area";//prabha 12122023
        public const string web_Corprate_Insurance_procedure = "Sp_Web_Corprate_Insurance";//prabha 12122023
        public const string GetDoctorDetailsDepwise_SP = "HIS_SP_GetDoctorDetails_DepWise";//prabha 12122023
        public const string web_language_hdr = "HIS_SP_MasLang_hdr";//prabha 12122023
        public const string GetIDTypeData = "SP_Web_GetIDTypeData";//prabha 12122023
        public const string web_DoctorsData_procedure = "HIS_SP_GetDoctorsData";//prabha 12122023
        public const string ChargeMasterLoad_Procedure = "SP_WEB_ChargeMasterLoad";//prabha 12122023
        public const string OPD_ExsistsMasterProc_api = "HIS_SP_ExsistingPat_details"; //prabha 280972023
        public const string SP_InsertCriticalCare_InfectiousDis = "InsertCriticalCare_InfectiousDis"; //prabha 280972023 
        public const string Get_PaymentGetWay_Listdemo = "web_PaymentGateWay_List_v1"; //prabha 29072023
        public const string AppAvailableSlotTime_Dtl = "HIS_SP_AppAvailableSlotTime_Dtl"; 
        public const string SP_GetCombinedData = "GetCombinedData"; 
        public const string Web_Patient_DtlNew = "HIS_SP_Patient_Dtl_New_v1";//prabha 280972023
        public const string Web_QMS_Details = "web_QMSData_Details";//sujithra 
        public const string Web_QMS_Details_test = "web_QMSData_Details_test";//sujithra 
        public const string WebSAVE_QMS_Details = "WEB_SP_QMSData";//sujithra
        public const string Sp_Image_save = "Insert_Patient_Portal_Details";//sujithra 
        public const string Sp_import = "Insert_Patient_Portal_Path";//sujithra 
        public const string Sp_GetImageDetails = "Get_Image_Details";//sujithra
        public const string WebSAVE_QMS_Details_test = "WEB_SP_QMSData_Test";//sujithra 
      
        //public const string web_Visitcreation_Procedure = "SP_WEB_VISITCREATION_V1";
        public const string web_Visitcreation_Procedure = "HIS_SP_NewOPDVisitCreation";
        public const string op_Invoice_Procedure = "HIS_SP_SERVICE_ORDER_INSERT_NEW";
        public const string Deposit_Dep_Procedure = "HIS_SP_Deposit_Dep";
        public const string SP_web_refincoun_save = "web_sp_refincoun_save"; // sujithra 02/01/2024
        public const string SP_IP_IPBedBlock_Save = "Web_SP_IP_IPBedBlock_Save"; // sujithra 03/01/2024
        public const string SP_IPBedBlock_Clear = "Web_SP_IP_IPBedBlock_Clear";
        public const string WebExisitingPatientAppointment = "HIS_SP_WebExisitingPatientAppointment_Dtl";
        public const string Web_OPBill_Receipt = "HIS_SP_OPBILL_RECEIPT";//prabha 27/11/2021
        public const string VisitWithAppointment = "HIS_SP_WebExisitingPatientAppointment_Visit";
        public const string GetPatientMas_List_web = "HIS_SP_Patient_Details";//sujithra 
        public const string Web_PatientDtlforDepEntry = "HIS_SP_PatientDtlforDepEntry ";//sujithra 
        public const string AppointmentListing_Procedure_V1 = "HIS_SP_AppointmentListing_v1";//sujithra
        public const string AppointmentListing_Procedure = "HIS_SP_AppPatientDtl";//sujithra
        public const string AppointmentListing_Procedure_All = "HIS_SP_AppointmentListing_ALL";//sujithra
        public const string DepositReprint_Procedure = "HIS_SP_DepositReprint";//sujithra
        public const string DepositeReprint_Output = "HIS_SP_DepositeReprint_Output";//sujithra
        public const string SP_QMSStatus_Dtl = "WEB_SP_QMSStatus_Dtl";//sujithra 
        public const string SP_RadiologyAppointmentStatus = "WEB_SP_RadiologyAppointmentStatus";//sujithra  08/03/2024
        public const string SP_RadiologyAppStatus_v1 = "WEB_SP_RadiologyAppointmentStatus_v1";//sujithra  11/03/2024                                                                                           
        public const string Sp_DaywiseQMS_Data_V1 = "web_sp_DaywiseQMS_Data_V1";//sujithra 
        public const string SP_QMS_TVData = "SP_QMS_TVdata";//sujithra  06/03/2023
        public const string Web_SP_QMSStatus_Dtl = "WEB_SP_QMSStatus_Dtl";//sujithra 
        public const string Web_SP_QMSStatus_Dtl_test = "WEB_SP_QMSStatus_Dtl_Test";//sujithra 
        public const string SP_QMSDayWise_Dtl = "web_sp_DaywiseQMS_Data";//sujithra 
        public const string SP_RadiologyAppointment = "RadiologyAppointment_SP";//sujithra 05/03/2024
        public const string SP_RadiologyApp_modality = "RadiologyAppointment_SP_Modality";//sujithra 11/03/2024
        public const string SP_QMSDayWise_Dtl_test = "web_sp_DaywiseQMS_Data_test";//sujithra 1
        public const string SP_DepPatAmt_Details = "HIS_SP_DepPatAmt_Details";   //sujithra
        public const string SP_DepositType_Dtl = "HIS_SP_DepositType_Dtl";//sujithra
        public const string SP_RadLandingScreen_Dtl = "web_sp_RadLandingScreen_Dtl";//sujithra 1
        public const string SP_CardiologyLanding = "Web_SP_CardiologyLanding_Dtl";//sujithra  1  
        public const string SP_NMLanding_Dtl = "Web_SP_NMLanding_Dtl";//sujithra  1
        public const string SP_GetRadRequisitionSlipDetail = "HIS_SP_GetRadRequisitionSlipDetail";//sujithra
        public const string SP_RadPatientSearch = "HIS_SP_RadPatientSearch_Dtl";//sujithra
        public const string SP_NMPatientSearch = "HIS_SP_NMPatientSearch_Dtl";//sujithra
        public const string SP_MediScanPatientSearch = "HIS_SP_MediScanPatientSearch_Dtl";//sujithra
        public const string opLIST_Procedure = "HIS_SP_OPLIST";  //Jeyaganesh 05.07.2021 //alter prabha12/07/2022
        public const string GetVisitProcedure = "HIS_SP_VisitType";//Jeyaganesh 31.07.2021sp_VisitType
        public const string PatientRegOutputPdf = "HIS_SP_Registration_Reprint_Output"; // sujithra
        public const string web_Invoice_Reprint_List_procedure = "HIS_SP_Invoice_Reprint_List";//prabha03/12/2021

        public const string SP_BedRateAndNursingRate_dtl = "Web_SP_BedRateAndNursingRate_dtl"; // sujithra
        public const string sp_BedDetails_Load = "web_sp_BedDetails_Load"; // sujithra
        public const string sp_Get_BedID = "web_sp_Get_BedID"; // sujithra  
        public const string Sp_BedBlockDetails_Load = "Web_Sp_BedBlockDetails_Load"; // sujithra
        public const string SP_CriticalCare_InfectiousDis = "HIS_SP_CriticalCare_InfectiousDis"; // sujithra
        public const string Op_InvoiceReprint_Out_V1 = "HIS_SP_Invoice_Reprint"; 
        public const string SP_FinancialCounselling = "WEB_SP_FinancialCounsellingSave"; // sujithra
        public const string Web_Ref_pat = "HIS_SP_Ref_pat";
        public const string SP_Get_Doctor_Directory_Js = "HIS_SP_Doctor_Directory_Js"; //sujithra 08/01/2023
        public const string Sp_InsertDoctor_Directory_Js = "HIS_Sp_InsertDoctor_Directory_Js"; //sujithra 08/01/2023
        public const string Sp_UPDATEDoctor_Directory_Js = "HIS_Sp_UPDATEDoctor_Directory_Js"; //sujithra 08/01/2023
        public const string SP_TVbackgraound = "HIS_SP_TVbackgraound"; //sujithra 08/01/2023
        public const string Sp_UPDATETVbackgraound = "HIS_Sp_UPDATETVbackgraound"; //sujithra 08/01/2023
        public const string Payment_Procedure = "SP_HIS_OnlinePayment_Confirmation_dtl"; 
        public const string SP_AuthenticateMobNo_Upload_V1 = "WebAPI_AuthenticateMobNo_Upload_V1";
        public const string POS_Procedure = "SP_HIS_POSPayment_Confirmation_dtl";
        public const string SP_BirthDay_Info_New = "Get_Pr_Send_BirthDay_Info_New";
        public const string SP_OPIPREVENUE = "SP_OPIPREVENUE";
        public const string SP_Kranium_EMRAPILog = "Kranium_EMRAPILog";  // sujithra 15/03/2024
        public const string sp_his_opd_Process_Dtl = "save_his_opd_Process_Dtl";  // sujithra 5/4/2024     
        public const string sp_save_e_cert = "save_e_certificate";  // sujithra 23/4/2024     
        public const string sp_opd_Process_Get = "UpdateQCEMRDashboard_Date";  // sujithra 5/4/2024
        public const string sp_opd_Process_Get_v1 = "UpdateQCEMRDashboard_Date";  // sujithra 16/05/2024
        public const string sp_qcupdate_visit = "UpdateQCEMRDashboard_Visit";  // sujithra 03/05/2024
        public const string sp_QCvisit = "SaveOrUpdateQCVisittracking";  // sujithra 2/5/2024
        public const string sp_SaveEMROTDet = "SaveEMROTDet";  // sujithra 27/5/2024    
        public const string sp_QCorder = "SaveOrUpdateQCOrderTracking";  // sujithra 2/5/2024
        public const string Sp_Package_Patient_venue = "Package_Patient_venue";//sujithra 18/05/2024
        public const string Sp_Package_master = "Package_master";//sujithra 22/05/2024
        public const string Sp_Test_master = "Test_master";//sujithra 22/05/2024
        public const string sp_doctor_tv = "Sp_Doctor_TV";//sujithra 14/06/2024
        public const string GetAppointmentSlot_Procedure_Web = "SP_AppointmentAvailableSlot_Dtl_web"; //Added by jeyaganesh 29.09.2021
        public const string GetDoctorDetailsDepwiseDocID_SP = "SP_GetDoctorDetails_DepWiseDocID";//Jeyaganesh 31.08.2021
        public const string UHID_Procedure = "SP_Get_HIS_UHID"; //Added by jeyaganesh 23.07.2021
        public const string BookAppointment_ExistingPatient_new = "SP_Portal_AppointmentwithRegistration";//jeyaganesh 14.02.2022
        public const string BookAppointment_NewPatient = "SP_InsertIntoAppointmentForNewPatient_Dtl";
        public const string BookAppointment_NewPatient_new = "SP_Portal_NewAppointmentWithRegistration";//jeyaganesh 14.02.2022


        public const string BookAppointment_ExistingPatient_new_seq = "SP_Portal_AppointmentwithRegistration_sequence";//sujithra 14.02.2024
        public const string BookAppointment_NewPatient_new_seq = "SP_Portal_NewAppointmentWithRegistration_seq"; //sujithra 14.02.2024


        public static string sha256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Base64Encode(Sb.ToString());
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }


        public const string salucro_url = "https://rela.momentpay.live/ma/payment/api/v1/status";
        //public const string salucro_url = "https://salucro.co.in/api/v2/status"; // ' Added by jeyaganesh 29.01.2022
        public static string secret_key = "qKJQDElYtyVwGH8i9mCcVMiCOgH1puYm"; //
        #endregion
    }
}
