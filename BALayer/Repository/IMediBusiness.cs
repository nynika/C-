//using BALayer.BusinessModels;
using EnitityLayer.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BALayer.Repository
{
    public interface IMediBusiness
    {
        resLogin GetLogin(reqLogin request);//arun 24.08.2021

        resUserLogin getUserLogin(reqUserLogin req);//suji 30.03.2024
        resSavelogin SaveUser_login(reqSaveLogin request);//suji 30.03.2024
        respatLogin patLogin(reqpatLogin request);//suji 30.03.2024
        resHouseKeepingList Get_HouseKeepingList_Save(ReqHouseKeepingList request); // arun
        resHouseKeepingList Get_RestRoomCheckList_Save(ReqRestRoomList request); // arun
        resHouseKeepingList Get_Patient_Portal(Patient_Portal request); // prabha
        resHouseKeepingList Get_Patient_Portal_MHC(Patient_Portal request); // prabha           
       
        clsWebMinar SaveAppointmentSlot(ClsSaveAppointmentSlot Request);
        
        updaterefid Update_RefId(reqclass RefID);// prabha
        CovidRegistrationDTO uhidGenerate(long UHID);
        //resHouseKeepingList OT_LIST_SAVE(OtClass req);// prabha
        //List<OtClass> Get_OTLits();// prabha
        //List<LicenseModel> Get_License_dtl();// prabha
        //List<appsolt> Get_Appsolt_dtl();// prabha
        //List<DoctorDirectory> Get_DoctorDirectory_dtl();// prabha
        //TicketingSystem Get_TicketingCount_dtl(string Fromdate, string Todate);// prabha
        //List<DepWiseTicketingSystem> Get_TicketingDepCount_dtl(string Fromdate, string Todate);// prabha
        //DoctorDirectory Get_DocDirectoru_Editdtl(int SNo);// prabha
        //clsWebMinar OT_Excel(Otexcel_req request);
        //clsWebMinar DoctoryDiectory_Img(DocDirImg_req request);
        clsWebMinar Doc_Dir_IMG_View(docDir_imgView request);
        clsWebMinar Doc_Dir_IMG_import(docDir_img_imp request);
        List<signimgreq> signimage();
        resSavelogin save_signimg(signimgreq request);   
        clsWebMinar Doc_Dir_IMG_export(docDir_img_exp request);
       //  clsWebMinar Insert_DocDir_New(DoctorDirectory_new request);
        //clsWebMinar Update_DocDir_Dtl(DoctorDirectory request);
        //clsWebMinar Delete_DocDir_Dtl(int SNo);
        //clsdelPat DeleteFilefromDisk (int UHID, string DocumentPath);
        //clsWebMinar Get_PaymentGetWay(PaymentGateWay req);
        //List<DocDirImg_List> Get_DocDir_Img_List();
        //List<docDir_imgView_List> Get_DocDir_Img_View_List();
        //List<Get_PaymentGetWay_List> Get_PaymentGetWay_List(string frdate,string todate);
        //List<Get_PaymentGetWay_Listdemo> Get_PaymentGetWay_Listdemo(string frdate, string todate);
        BB_BloodGroup_res BB_BloodGroup(BB_BloodGroup_req req);
        opd_master_Res Insert_OPDMaster_Porc(OPD_MasterProc_req req);
        clsFinancialResult FinancialCounsellingSave(FinancialCounselling_req req); 
        EXS_opd_master_Res Insert_ExsistsOPDMaster_Porc(OPD_ExsitsMasterProc_req req);
        InsertCriticalCare_InfectiousDis_Res InsertCriticalCare_InfectiousDis(InsertCriticalCare_req req);
        List<clsAppAvailableSlotTimeDtl> AppAvailableSlotTimeDtl(DateTime APPDate, string ConsId, string Slottype);// Priya
        List<clsGetCombinedData> GetCombinedData(string DtlType);
        //List<clsCUG> GetCombinedData_v1(string DtlType);
        List<clsDropDown> Ref_Source_list();
        List<clsDropDown> GetDepartment();
        List<clsDropDown> GetMobileCode();
        List<contryDropDown> GetCountriesDetails();
        List<clsDropDown> GetSalutaionsDetails();
        List<clsDropDown> GetServiceLoad();
        List<clsDropDown> GetPriority();
        //List<clsDropDown> GetChargeMaster(long code);
        List<clsDropDown> GetNationalityDetails();
        List<resDropDown> MasterBloodGroup();
        List<clsDropDown> Get_MasReligion_Data();
        List<clsDropDown> Get_MasLang_Data();
        List<resDropDown> Get_ExternalDoc_Data();
        List<reqRef_Relationship> Ref_Relationship_list();//prabha 25/10/2021
        List<SurgProcname> SurgProcname_Dtl(); // sujithra 30/12/2023  
        List<clsFinancialCounsellingprint> FinancialCounsellingprint(int Patientid, int CounsellingId); // sujithra 30/12/2023
        List<FinCouncil_Detail_Load> FinCouncil_Detail_Load(int Patientid); // sujithra 02/01/2023

        List<reqRef_DoctorData> Ref_DoctorData_list();//prabha 04-Jan-2022
        List<clsDropDown> GetOccupationDataDetails();
        List<clsbedRes> Web_Bed_Report();
        List<clsDropDown> GetStateDetails();
        List<clsDropDown> GetMaritalStatusDetails();
        List<clsDropDown> GetCityDtlStatewise(int StateCode);
        List<clsDropDown> GetIDTypeDetails();
        List<clsDropDown> GetArea(string pincode);
        List<req_chargeload_v1> GetChargeMaster_v1(long code);
        List<clsDropDown> GetCorprateInsurancelist(string PanelType);
        List<clsDropDown> GetDoctorNameDepWise(long DepID, string DoctorName);
        //sujithra
        clsResult opInvoice(clsopInvoice request);
        clsdepResult Deposit_Dep(clsdeposit request);
        clsrefincoun_save web_refincoun_save(clsrefincoun request);
        clsIPBedBlock_Save IPBedBlock_Save(clsIPBedBlock request);
        clsIPBedBlock_Clear IPBedBlock_Clear(reqIPBedBlock_Clear request);
        Response_DTO VisitExistingPatient(reqAppVisit request);
        clsWebExisitingPatientAppointment WebExisitingPatientAppointment(clsWebExisitingPatientAppointmenthead request);
        clsResult Web_OPBill_Receipt(OPBillRecepitHead request);
        clsWebExisitingPatientAppointment VisitWithAppointment(VisitWithAppointment_Detail request);
        List<clsPatientMas_v1> GetPatientMas_List_v1(int PatientID);
        List<DepositePatientDtl> Get_PatDepositeDtl(int PatientID);
        List<reswebPatientDtl> Web_PatientDtl_list(string Type, string search);
        resHouseKeepingList WebSave_QMS_Details(Save_QMSDetails request);
        resHouseKeepingList SavePatientDetails(reqimg request);
        resHouseKeepingList import(Patient_Portal_PathModel request);
        List<resimgList> GetImageDetails();     
        resHouseKeepingList WebSave_QMS_Details_test(Save_QMSDetails request); 
        List<QMSDetails> Get_QMS_Details(string FromDate, string ToDate,string Type);
        List<QMSDetails_test> Get_QMS_Details_test(string FromDate, string ToDate, string Type);
        List<resAppointmentList> Get_appointmentList_v1(string FromDate, string ToDate);
        List<BedRateAndNursingRate> BedRateAndNursingRate_dtl(int Bedcategoryid);
        List<BedDetails_Load> web_sp_BedDetails_Load(int CatId);
        List<Authenticate> AuthenticateMobNo_Upload_V1(string OTP_MobileNo, int Otp);  //sujithra 16/02/2024
        List<Get_BedID> web_sp_Get_BedID(int BedId);
        List<BedBlockDetails> BedBlockDetails_Load();
        List<CriticalCare> Get_CriticalCare_InfectiousDis();
        List<resAppointmentListALL> appointmentList_All(string FromDate, string ToDate);
        List<resAppointmentList> Get_appointmentList(string Search);
        List<DepositeDtl_ReprintList> Get_Web_Deposite_Reprint(string FromDate, string ToDate,int Uhid);
        List<DepositeReprint_OutputDtl> Get_DepositeReprintOutput(string ReceiptNo);
        resHouseKeepingList Get_WEB_SP_QMSStatus_Dtl(string PatientName, string MobileNo, int PatType);
        resHouseKeepingList RadiologyAppointmentStatus(string DoctorName, int UHID, int APPID, int PatType);
        resHouseKeepingList RadiologyAppointmentStatus_v1(string DoctorName, int UHID, int APPID, string PatType);
        resDaywiseQMSList Get_DaywiseQMS_Data_V1();
        List<resQMSListTV> Get_QMS_TVData();
        resHouseKeepingList UpdateQMSStatus_Dtl(Save_QMSDetails req);
        resHouseKeepingList UpdateQMSStatus_Dtl_test(Save_QMSDetails req);
        List<DayWise_QMSDetails> Get_WEB_DayWiseQMS_Dtl();
        List<RadiologyAppointment> Get_RadiologyAppointment();
        List<RadiologyAppointment> Get_RadiologyAppointment_Modality();
        List<DayWise_QMSDetails_test> Get_WEB_DayWiseQMS_Dtl_test();
        List<DepPatAmt_Details> Get_WEB_DepPatAmt_Details(int UHID);
        List<clsDropDown> Get_web_DepositType_Dtl();
        List<clsRadLandingScreen> Get_web_RadLandingScreen_Dtl(string dtFrom, string dtTo, int blnOrderwise);
        List<clsCardiologyLanding> Web_CardiologyLanding(string FromDate, string ToDate);
        List<clsNMLanding_Dtl> Web_NMLanding_Dtl(string FromDate, string ToDate);
        List<clsWeb_GetRadRequisitionSlipDetail> Web_GetRadRequisitionSlipDetail(string sPatient, string strRegID, string OrderID, string strSampleNo);
        List<clsweb_RadPatientSearch> web_RadPatientSearch(string FromDate, string ToDate, string MRN, string PatientName, string ApptTime, string DoctName, string Company, string MobileNo, string DeptName, int radmenu);    
        List<clsweb_NMPatientSearch> web_NMPatientSearch(string FromDate, string ToDate, string MRN, string PatientName, string ApptTime, string DoctName, string Company, string MobileNo, string DeptName, int radmenu);
        List<clsweb_MediScanPatientSearch> web_MediScanPatientSearch(string FromDate, string ToDate, string MRN, string PatientName, string ApptTime, string DoctName, string Company, string MobileNo, string DeptName, int radmenu);    
        List<resOPList> Get_opList(string Type, string Search);//Jeyaganesh 29.07.2021
        List<clsDropDown> GetvisitType(string type);//Jeyaganesh 31.07.2021
        clsPatientRegistrationPdf GetPatientRegOutPutPdf(int RegId);
        List<reqInvoice_Reprint_List> web_Invoice_Reprint_List_procedure(string FromDate, string ToDate, string type, string Search);
        InvoiceHead1 OpReprint_V1(int BillNo);//PRANHA 04
        List<clswebRef_patient> get_WebRef_pat(int appPatID);

        List<cls_Patient_venue> Package_Patient_venue();
        List<cls_Patient_master> Package_master();
        List<cls_Test_master> Test_master();

        List<Doctor_Directory> Get_Doctor_Directory_Js();  //sujithra 08/01/2023
        
        InsertDoctor_Directory_Js_Res InsertDoctor_Directory_Js(InsertDoctor_Directory_Js_req req); //sujithra 08/01/2023
        UPDATEDoctor_Directory_Js_Res UPDATEDoctor_Directory_Js(UPDATEDoctor_Directory_Js_req req); //sujithra 08/01/2023
        List<TVbackgraound> Get_TVbackgraound();  //sujithra 08/01/2023
        UpdateTVbackgraound_Res UpdateTVbackgraound(UpdateTVbackgraound_req req); //sujithra 08/01/2023
        Response_pay updateOnlinePayment(pay_request pay_Request);

        //Response_v1 AuthenticateMobNo_Upload_V1(Auth_request Auth_request);
        Response_DTO_v1 updatePOSPayment(payment_request payment_Request);
        string AuthenticateOTP(string RandomNumber, string MobileNo);
        OTP_Resp GetPatientResp_MobNo(string RandomNumber, string MobileNo);
        void InsertUpdateOTP_portal( string RandomNumber, string MobileNo);
        List<res_BirthDay_Info_New> Get_BirthDay_Info_New(string date);
        List<res_opiprevenue> SP_OPIPREVENUE(string FromDate, string ToDate, string Pattype, int IVF_flg);
        List<res_EMRAPILog> Kranium_EMRAPILog(string Fdate, string tdate, string Status);
        List<res_opd_Process> Get_opd_Process(string Todate);
        List<res_opd_Process> Get_opd_Process_v1(string Todate, int Type);
        List<res_UpdateQC_Visit> UpdateQCEMRDashboard_Visit(string Todate, int VisitId);
        responseDtl save_opd_Process_Dtl(requestDtl requestDtl);
        responseDtl SaveOrUpdateQCVisittracking(req_Visittracking requestDtl);
        resEMROTDetl SaveEMROTDet(req_EMROTDetl requestDtl);
        responseDtl SaveOrUpdateQCOrderTracking(req_OrderTracking requestDtl);
        responseDtl save_e_certificate(requeste_cert requeste_cert);
        List<res_doctor_tv> Get_Doctor_TV(string TvTag);
        List<res_doctor_tv> Doctor_TV();
        List<SlotRes_DTO> GetAppointmentSlot_Web(SlotReq_DTO slot_DTO);//Jeyaganesh 29.09.2021
        List<clsDoctor> GetDoctorNameDepWiseDocID(DepartmentwiseDoctorFilter dep);//Jeyaganesh 26.04.2021
        appointment_Response createAppointment(AppointmentBooking appointmentBooking);//Jeyaganesh 09.06.2021
        appointment_Response createAppointment_seq(AppointmentBooking_seq appointmentBooking_seq);//sujithra 25.06.2024
        update_Doctor_TV_Res update_Doctor_TV(update_Doctor_TV_req req); //sujithra 08/07/2024    
        delete_Doctor_TV_Res Delete_Doctor_TV(delete_Doctor_TV_req req); //sujithra 08/07/2024    
        List<AppointmentSlotDTO> GetAppointmentSlotDetails(AppointmentSlotDTO appointmentSlot);
        List<AppointmentSlotDTO> GetAppointmentSlotDaysDetails(AppointmentSlotDTO appointmentSlot);
        List<res_mepz> getmepz();

        update_Mepz_tb_res update_Mepz_tb(update_Mepz_tb_req req); //sujithra 08/07/2024  


    }
}
