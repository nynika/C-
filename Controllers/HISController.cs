﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.StaticFiles;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BALayer.Repository;
using EnitityLayer.BusinessModels;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Drawing;
using QRCoder;
using System.Security.Cryptography;
using System.Drawing.Imaging;
using ImageProcessor;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using Microsoft.AspNetCore.Cors.Infrastructure;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using DALayer;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ImageProcessor.Processors;
using static BALayer.MediBusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using static RIMC_WEBAPI.Controllers.HISController;
using static System.Net.Mime.MediaTypeNames;

using System;
using System.Text;
using System.Buffers.Text;
using System.Net.Http;
using static System.Net.WebRequestMethods;
//using System.Windows.Forms;



namespace RIMC_WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    //[EnableCors("_myAllowSpecificOrigins")]
    public class HISController : Controller
    {
        private readonly IMediBusiness _mediBusiness;
        private readonly IConfiguration _configuration;
        public HISController(IMediBusiness mediBusiness, IConfiguration configuration)
        {
            _mediBusiness = mediBusiness;
            _configuration = configuration;
        }

        #region RIMC_Online

        //14122023
        [HttpPost]
        [ActionName("getHISLogin")]
        public resLogin checkLogin([FromBody] reqLogin request)
        {
            resLogin response = new resLogin();
            response = _mediBusiness.GetLogin(request);

            return response;
        }


        [HttpPost]
        [ActionName("Get_HouseKeepingList_Save")]
        public resHouseKeepingList Get_HouseKeepingList_Save(ReqHouseKeepingList req)
        {
            resHouseKeepingList response = new resHouseKeepingList();
            response = _mediBusiness.Get_HouseKeepingList_Save(req);
            return response;
        }


        [HttpPost]
        [ActionName("Get_RestRoomCheckList_Save")]
        public resHouseKeepingList Get_RestRoomCheckList_Save(ReqRestRoomList req)
        {
            resHouseKeepingList response = new resHouseKeepingList();
            response = _mediBusiness.Get_RestRoomCheckList_Save(req);
            return response;
        }

        //14122023
        [HttpPost]
        [ActionName("Get_Patient_Portal")]
        public resHouseKeepingList Get_Patient_Portal(Patient_Portal req)
        {
            resHouseKeepingList response = new resHouseKeepingList();
            response = _mediBusiness.Get_Patient_Portal(req);
            return response;
        }
        //14122023
        [HttpPost]
        [ActionName("Get_Patient_Portal_MHC")]
        public resHouseKeepingList Get_Patient_Portal_MHC(Patient_Portal req)
        {
            resHouseKeepingList response = new resHouseKeepingList();
            response = _mediBusiness.Get_Patient_Portal_MHC(req);
            return response;
        }


        [HttpPost]
        [ActionName("Insert_AppointmentSlot")]
        public clsWebMinar SaveAppointmentSlot(ClsSaveAppointmentSlot Request)
        {
            clsWebMinar response = new clsWebMinar();
            response = _mediBusiness.SaveAppointmentSlot(Request);
            return response;
        }

        [HttpPost]
        [ActionName("Update_RefId")]
        public updaterefid Update_RefId(reqclass req)
        {
            updaterefid response = new updaterefid();
            response = _mediBusiness.Update_RefId(req);
            return response;
        }

        //[HttpPost]
        //[ActionName("OT_LIST_SAVE")]
        //public resHouseKeepingList OT_LIST_SAVE(OtClass req)
        //{
        //    resHouseKeepingList response = new resHouseKeepingList();
        //    response = _mediBusiness.OT_LIST_SAVE(req);
        //    return response;
        //}
        //[HttpGet]
        //[ActionName("Get_OTList")]
        //public List<OtClass> Get_OTLits()
        //{
        //    List<OtClass> dropdown_DTOs = new List<OtClass>();
        //    dropdown_DTOs = _mediBusiness.Get_OTLits();

        //    return dropdown_DTOs;
        //}

        //[HttpGet]
        //[ActionName("Get_License_dtl")]
        //public List<LicenseModel> Get_License_dtl()
        //{
        //    List<LicenseModel> dropdown_DTOs = new List<LicenseModel>();
        //    dropdown_DTOs = _mediBusiness.Get_License_dtl();

        //    return dropdown_DTOs;
        //}
        //[HttpGet]
        //[ActionName("Get_Appsolt_dtl")]
        //public List<appsolt> Get_Appsolt_dtl()
        //{
        //    List<appsolt> dropdown_DTOs = new List<appsolt>();
        //    dropdown_DTOs = _mediBusiness.Get_Appsolt_dtl();

        //    return dropdown_DTOs;
        //}
        //[HttpPost]
        //[ActionName("OT_Excel")]
        //public clsWebMinar OT_Excel(Otexcel_req obj)
        //{
        //    clsWebMinar response = new clsWebMinar();
        //    response = _mediBusiness.OT_Excel(obj);
        //    return response;
        //}
        //[HttpGet]
        //[ActionName("Get_DoctorDirectory_dtl")]
        //public List<DoctorDirectory> Get_DoctorDirectory_dtl()
        //{
        //    List<DoctorDirectory> dropdown_DTOs = new List<DoctorDirectory>();
        //    dropdown_DTOs = _mediBusiness.Get_DoctorDirectory_dtl();

        //    return dropdown_DTOs;
        //}
        //[HttpGet]
        //[ActionName("Get_TicketingCount_dtl")]
        //public TicketingSystem Get_TicketingCount_dtl(string Fromdate,string Todate)
        //{
        //    TicketingSystem dropdown_DTOs = new TicketingSystem();
        //    dropdown_DTOs = _mediBusiness.Get_TicketingCount_dtl(Fromdate, Todate);

        //    return dropdown_DTOs;
        //}
        //[HttpGet]
        //[ActionName("Get_TicketingDepCount_dtl")]
        //public List<DepWiseTicketingSystem> Get_TicketingDepCount_dtl(string Fromdate, string Todate)
        //{
        //    List<DepWiseTicketingSystem> dropdown_DTOs = new List<DepWiseTicketingSystem>();
        //    dropdown_DTOs = _mediBusiness.Get_TicketingDepCount_dtl(Fromdate, Todate);

        //    return dropdown_DTOs;
        //}
        //[HttpGet]
        //[ActionName("Get_DocDirectory_Editdtl")]
        //public DoctorDirectory Get_DocDirectoru_Editdtl(int SNo)
        //{
        //    DoctorDirectory dropdown_DTOs = new DoctorDirectory();
        //    dropdown_DTOs = _mediBusiness.Get_DocDirectoru_Editdtl(SNo);

        //    return dropdown_DTOs;
        //}
        //[HttpPost]
        //[ActionName("DoctoryDiectory_Img")]
        //public clsWebMinar DoctoryDiectory_Img(DocDirImg_req obj)
        //{
        //    clsWebMinar response = new clsWebMinar();
        //    response = _mediBusiness.DoctoryDiectory_Img(obj);
        //    return response;
        //}
        [HttpPost]
        [ActionName("Doc_Dir_IMG_View")]
        public clsWebMinar Doc_Dir_IMG_View(docDir_imgView req)
        {
            clsWebMinar response = new clsWebMinar();
            response = _mediBusiness.Doc_Dir_IMG_View(req);
            return response;
        }

        [HttpPost]
        [ActionName("usp_ImportImage")]
        public clsWebMinar Doc_Dir_IMG_import(docDir_img_imp req)
        {
            clsWebMinar response = new clsWebMinar();
            response = _mediBusiness.Doc_Dir_IMG_import(req);
            return response;
        }


        [HttpGet]
        [ActionName("usp_ExportImage")]
        public clsWebMinar Doc_Dir_IMG_export(docDir_img_exp req)
        {
            clsWebMinar response = new clsWebMinar();
            response = _mediBusiness.Doc_Dir_IMG_export(req);
            return response;
        }

        //[HttpGet]
        //[ActionName("Get_DocDir_Img_List")]
        //public List<DocDirImg_List> Get_DocDir_Img_List()
        //{
        //    List<DocDirImg_List> dropdown_DTOs = new List<DocDirImg_List>();
        //    dropdown_DTOs = _mediBusiness.Get_DocDir_Img_List();

        //    return dropdown_DTOs;
        //}
        //[HttpGet]
        //[ActionName("Get_DocDir_Img_View_List")]
        //public List<docDir_imgView_List> Get_DocDir_Img_View_List()
        //{
        //    List<docDir_imgView_List> dropdown_DTOs = new List<docDir_imgView_List>();
        //    dropdown_DTOs = _mediBusiness.Get_DocDir_Img_View_List();

        //    return dropdown_DTOs;
        //}
        //[HttpPost]
        //[ActionName("Insert_DocDir_New")]
        //public clsWebMinar Insert_DocDir_New(DoctorDirectory_new req)
        //{
        //    clsWebMinar response = new clsWebMinar();
        //    response = _mediBusiness.Insert_DocDir_New(req);
        //    return response;
        //}
        //[HttpPost]
        //[ActionName("Update_DocDir_Dtl")]
        //public clsWebMinar Update_DocDir_Dtl(DoctorDirectory req)
        //{
        //    clsWebMinar response = new clsWebMinar();
        //    response = _mediBusiness.Update_DocDir_Dtl(req);
        //    return response;
        //}
        //[HttpGet]
        //[ActionName("Delete_DocDir_Dtl")]
        //public clsWebMinar Delete_DocDir_Dtl(int SNo)
        //{
        //    clsWebMinar dropdown_DTOs = new clsWebMinar();
        //    dropdown_DTOs = _mediBusiness.Delete_DocDir_Dtl(SNo);

        //    return dropdown_DTOs;
        //}
        //[HttpPost]
        //[ActionName("Get_PaymentGetWay")]
        //public clsWebMinar Get_PaymentGetWay(PaymentGateWay req)
        //{
        //    clsWebMinar response = new clsWebMinar();
        //    response = _mediBusiness.Get_PaymentGetWay(req);
        //    return response;
        //}

        //[HttpGet]
        //[ActionName("Get_PaymentGetWay_List")]
        //public List<Get_PaymentGetWay_List> Get_PaymentGetWay_List(string frdate, string todate )
        //{
        //    List<Get_PaymentGetWay_List> dropdown_DTOs = new List<Get_PaymentGetWay_List>();
        //    dropdown_DTOs = _mediBusiness.Get_PaymentGetWay_List(frdate, todate);

        //    return dropdown_DTOs;
        //}

        //[HttpGet]
        //[ActionName("Get_PaymentGetWay_Listdemo")]
        //public List<Get_PaymentGetWay_Listdemo> Get_PaymentGetWay_Listdemo(string frdate, string todate)
        //{
        //    List<Get_PaymentGetWay_Listdemo> dropdown_DTOs = new List<Get_PaymentGetWay_Listdemo>();
        //    dropdown_DTOs = _mediBusiness.Get_PaymentGetWay_Listdemo(frdate, todate);

        //    return dropdown_DTOs;
        //}

        [HttpPost]
        [ActionName("BB_BloodGroup")]
        public BB_BloodGroup_res BB_BloodGroup(BB_BloodGroup_req obj)
        {
            BB_BloodGroup_res response = new BB_BloodGroup_res();
            response = _mediBusiness.BB_BloodGroup(obj);
            return response;
        }
        [HttpPost]
        [ActionName("Insert_OPDMaster_Porc")]
        public opd_master_Res Insert_OPDMaster_Porc(OPD_MasterProc_req obj)
        {
            opd_master_Res response = new opd_master_Res();
            response = _mediBusiness.Insert_OPDMaster_Porc(obj);
            return response;
        }

        [HttpPost]
        [ActionName("FinancialCounsellingSave")]
        public clsFinancialResult FinancialCounsellingSave(FinancialCounselling_req obj)
        {
            clsFinancialResult response = new clsFinancialResult();
            response = _mediBusiness.FinancialCounsellingSave(obj);
            return response;
        }

        [HttpPost]
        [ActionName("Insert_ExsistsOPDMaster_Porc")]
        public EXS_opd_master_Res Insert_ExsistsOPDMaster_Porc(OPD_ExsitsMasterProc_req obj)
        {
            EXS_opd_master_Res response = new EXS_opd_master_Res();
            response = _mediBusiness.Insert_ExsistsOPDMaster_Porc(obj);
            return response;
        }
        [HttpGet]
        [ActionName("AppAvailableSlotTimeDtl")]
        public List<clsAppAvailableSlotTimeDtl> AppAvailableSlotTimeDtl(DateTime APPDate, String ConsId, String Slottype)
        {
            List<clsAppAvailableSlotTimeDtl> response = new List<clsAppAvailableSlotTimeDtl>();
            response = _mediBusiness.AppAvailableSlotTimeDtl(APPDate, ConsId, Slottype);
            return response;
        }

        [HttpGet]
        [ActionName("GetCombinedData")]
        public List<clsGetCombinedData> GetCombinedData(string DtlType)
        {
            List<clsGetCombinedData> response = new List<clsGetCombinedData>();
            response = _mediBusiness.GetCombinedData(DtlType);
            return response;
        }

        //[HttpGet]
        //[ActionName("GetCombinedData_v1")]
        //public List<clsCUG> GetCombinedData_v1(string DtlType)
        //{
        //    List<clsCUG> response = new List<clsCUG>();
        //    response = _mediBusiness.GetCombinedData_v1(DtlType);
        //    return response;
        //}

        [HttpGet]
        [ActionName("Salutations")]
        public List<clsDropDown> GetSalutaionsDetails()
        {
            List<clsDropDown> salutations = new List<clsDropDown>();
            salutations = _mediBusiness.GetSalutaionsDetails();
            return salutations;
        }
        [HttpGet]
        [ActionName("get_Ref_Source")]
        public List<clsDropDown> Ref_Source_list()
        {
            List<clsDropDown> response = new List<clsDropDown>();
            response = _mediBusiness.Ref_Source_list();
            return response;
        }

        [HttpGet]
        [ActionName("Departments")]  // change.....29/10/2021
        public List<clsDropDown> GetDepartmentData()
        {
            List<clsDropDown> dropdown_DTOs = new List<clsDropDown>();
            dropdown_DTOs = _mediBusiness.GetDepartment();

            return dropdown_DTOs;
        }

        [HttpGet]
        [ActionName("MobileCode")] // change.....29/10/2021
        public List<clsDropDown> GetMobileCode()
        {
            List<clsDropDown> dropdown_DTOs = new List<clsDropDown>();
            dropdown_DTOs = _mediBusiness.GetMobileCode();

            return dropdown_DTOs;
        }

        [HttpGet]
        [ActionName("Countries")] // change.....29/10/2021
        public List<contryDropDown> GetCountriesDetails()
        {
            List<contryDropDown> countries = new List<contryDropDown>();
            countries = _mediBusiness.GetCountriesDetails();
            return countries;
        }

        [HttpGet]
        [ActionName("Get_Services")] // change.....29/10/2021
        public List<clsDropDown> Get_Services()
        {
            List<clsDropDown> res = new List<clsDropDown>();
            res = _mediBusiness.GetServiceLoad();
            return res;
        }

        [HttpGet]
        [ActionName("Get_Priority")] // change.....29/10/2021
        public List<clsDropDown> Get_Priority()
        {
            List<clsDropDown> res = new List<clsDropDown>();
            res = _mediBusiness.GetPriority();
            return res;
        }

        //[HttpGet]
        //[ActionName("Get_ChargeMaster")]
        //public List<clsDropDown> Get_ChargeMaster(long code)
        //{
        //    List<clsDropDown> res = new List<clsDropDown>();
        //    res = _mediBusiness.GetChargeMaster(code);
        //    return res;
        //}

        [HttpGet]
        [ActionName("Nationality")]
        public List<clsDropDown> GetNationalityDetails()
        {
            List<clsDropDown> countries = new List<clsDropDown>();
            countries = _mediBusiness.GetNationalityDetails();
            return countries;
        }
        [HttpGet]
        [ActionName("get_Web_Relationship")]
        public List<reqRef_Relationship> Ref_Relationship_list()
        {
            List<reqRef_Relationship> response = new List<reqRef_Relationship>();
            response = _mediBusiness.Ref_Relationship_list();
            return response;
        }


        [HttpGet]
        [ActionName("SurgProcname_Dtl")]
        public List<SurgProcname> SurgProcname_Dtl()
        {
            List<SurgProcname> response = new List<SurgProcname>();
            response = _mediBusiness.SurgProcname_Dtl();
            return response;
        }

        [HttpGet]
        [ActionName("FinancialCounsellingprint")]
        public List<clsFinancialCounsellingprint> FinancialCounsellingprint(int Patientid, int CounsellingId)
        {
            List<clsFinancialCounsellingprint> response = new List<clsFinancialCounsellingprint>();
            response = _mediBusiness.FinancialCounsellingprint(Patientid, CounsellingId);
            return response;
        }

        [HttpGet]
        [ActionName("FinCouncil_Detail_Load")]
        public List<FinCouncil_Detail_Load> FinCouncil_Detail_Load(int Patientid)
        {
            List<FinCouncil_Detail_Load> response = new List<FinCouncil_Detail_Load>();
            response = _mediBusiness.FinCouncil_Detail_Load(Patientid);
            return response;
        }

        //prabha 04-Jan-2022
        [HttpGet]
        [ActionName("get_Web_DoctorData")]
        public List<reqRef_DoctorData> Ref_DoctorData_list()
        {
            List<reqRef_DoctorData> response = new List<reqRef_DoctorData>();
            response = _mediBusiness.Ref_DoctorData_list();
            return response;
        }
        [HttpGet]
        [ActionName("MasterBloodGroup")]
        public List<resDropDown> MasterBloodGroup()
        {
            List<resDropDown> ReligionDTOs = new List<resDropDown>();
            ReligionDTOs = _mediBusiness.MasterBloodGroup();

            return ReligionDTOs;
        }
        [HttpGet]
        [ActionName("Get_MasReligion_Data")]
        public List<clsDropDown> Get_MasReligion_Data()
        {
            List<clsDropDown> res = new List<clsDropDown>();
            res = _mediBusiness.Get_MasReligion_Data();
            return res;
        }
        [HttpGet]
        [ActionName("Get_MasLang_Data")]
        public List<clsDropDown> Get_MasLang_Data()
        {
            List<clsDropDown> res = new List<clsDropDown>();
            res = _mediBusiness.Get_MasLang_Data();
            return res;
        }
        [HttpGet]
        [ActionName("Get_ExternalDoc_Data")]
        public List<resDropDown> Get_ExternalDoc_Data()
        {
            List<resDropDown> res = new List<resDropDown>();
            res = _mediBusiness.Get_ExternalDoc_Data();
            return res;
        }
        [HttpGet]
        [ActionName("State")] // change.....29/10/2021
        public List<clsDropDown> GetStateDetails()
        {
            List<clsDropDown> stateDTOs = new List<clsDropDown>();
            stateDTOs = _mediBusiness.GetStateDetails();

            return stateDTOs;
        }
        [HttpGet]
        [ActionName("OccupationData")] // change.....29/10/2021
        public List<clsDropDown> GetOccupationDataDetails()
        {
            List<clsDropDown> OccupationDTOs = new List<clsDropDown>();
            OccupationDTOs = _mediBusiness.GetOccupationDataDetails();

            return OccupationDTOs;
        }

        [HttpGet]
        [ActionName("MaritalStatus")] // change.....29/10/2021
        public List<clsDropDown> GetMaritalStatusDetail()
        {
            List<clsDropDown> countries = new List<clsDropDown>();
            countries = _mediBusiness.GetMaritalStatusDetails();
            return countries;
        }

        [HttpGet]
        [ActionName("IDType")] // change.....29/10/2021
        public List<clsDropDown> GeIDTypeDetails()
        {
            List<clsDropDown> IDTypeDTOs = new List<clsDropDown>();
            IDTypeDTOs = _mediBusiness.GetIDTypeDetails();

            return IDTypeDTOs;
        }
        [HttpGet]
        [ActionName("Statecdwise_CityDtl")] // prabha 09/12/2021
        public List<clsDropDown> GetCityDtlStatewise(int StateCode)
        {
            List<clsDropDown> cityDTOs = new List<clsDropDown>();
            cityDTOs = _mediBusiness.GetCityDtlStatewise(StateCode);

            return cityDTOs;
        }
        [HttpGet]
        [ActionName("Area")] // change.....29/10/2021
        public List<clsDropDown> GetArea(string pincode)
        {
            List<clsDropDown> dropdown_DTOs = new List<clsDropDown>();
            dropdown_DTOs = _mediBusiness.GetArea(pincode);

            return dropdown_DTOs;
        }
        //Sujithra  ---start

        [HttpPost]
        [ActionName("opInvoice")]
        public clsResult opInvoice(clsopInvoice obj)
        {
            clsResult response = new clsResult();
            response = _mediBusiness.opInvoice(obj);
            return response;
        }

        [HttpPost]
        [ActionName("Deposit_Dep")]
        public clsdepResult Deposit_Dep(clsdeposit obj)
        {
            clsdepResult response = new clsdepResult();
            response = _mediBusiness.Deposit_Dep(obj);
            return response;
        }

        [HttpPost]
        [ActionName("web_refincoun_save")]
        public clsrefincoun_save web_refincoun_save(clsrefincoun obj)
        {
            clsrefincoun_save response = new clsrefincoun_save();
            response = _mediBusiness.web_refincoun_save(obj);
            return response;
        }

        [HttpPost]
        [ActionName("IPBedBlock_Save")]
        public clsIPBedBlock_Save IPBedBlock_Save(clsIPBedBlock obj)
        {
            clsIPBedBlock_Save response = new clsIPBedBlock_Save();
            response = _mediBusiness.IPBedBlock_Save(obj);
            return response;
        }

        [HttpPost]
        [ActionName("IPBedBlock_Clear")]
        public clsIPBedBlock_Clear IPBedBlock_Clear(reqIPBedBlock_Clear obj)
        {
            clsIPBedBlock_Clear response = new clsIPBedBlock_Clear();
            response = _mediBusiness.IPBedBlock_Clear(obj);
            return response;
        }


        [HttpPost]
        [ActionName("VisitExistingpatient_new")]
        public Response_DTO VisitExistingPatient_new(reqAppVisit req)
        {
            Response_DTO response = new Response_DTO();
            response = _mediBusiness.VisitExistingPatient(req);
            return response;
        }

        [HttpGet]
        [ActionName("GetInsurance_Corporate")]  // prabha.....30/11/2021
        public List<clsDropDown> GetInsuranceCorporate(string PanelType)
        {
            List<clsDropDown> response = new List<clsDropDown>();
            response = _mediBusiness.GetCorprateInsurancelist(PanelType);

            return response;
        }
        [HttpGet]
        [ActionName("DepartmentWiseDoctor")]  // change.....29/10/2021
        public List<clsDropDown> GetDepartmentWiseDoctor(long DepID = 0, string DoctorName = "")
        {
            List<clsDropDown> response = new List<clsDropDown>();
            response = _mediBusiness.GetDoctorNameDepWise(DepID, DoctorName);

            return response;
        }

        [HttpPost]
        [ActionName("WebExisitingPatientAppointment")]
        public clsWebExisitingPatientAppointment WebExisitingPatientAppointment([FromBody] clsWebExisitingPatientAppointmenthead obj)
        {
            clsWebExisitingPatientAppointment response = new clsWebExisitingPatientAppointment();
            response = _mediBusiness.WebExisitingPatientAppointment(obj);
            return response;
        }

        [HttpGet]
        [ActionName("Get_ChargeMaster_v1")]
        public List<req_chargeload_v1> Get_ChargeMaster_v1(long code)
        {
            List<req_chargeload_v1> res = new List<req_chargeload_v1>();
            res = _mediBusiness.GetChargeMaster_v1(code);
            return res;
        }
        #endregion
        [HttpPost]
        [ActionName("VisitWithAppointment")]
        public clsWebExisitingPatientAppointment VisitWithAppointment([FromBody] VisitWithAppointment_Detail obj)
        {
            clsWebExisitingPatientAppointment response = new clsWebExisitingPatientAppointment();
            response = _mediBusiness.VisitWithAppointment(obj);
            return response;
        }

        [HttpPost]
        [ActionName("Web_OPBill_Receipt")]
        public clsResult Web_OPBill_Receipt([FromBody] OPBillRecepitHead obj)
        {
            clsResult response = new clsResult();
            response = _mediBusiness.Web_OPBill_Receipt(obj);
            return response;
        }

        [HttpGet]
        [ActionName("Get_ExisPat_Detail")]
        public List<clsPatientMas_v1> GetPatientMas_List_v1(int patientid)
        {
            List<clsPatientMas_v1> response = new List<clsPatientMas_v1>();
            response = _mediBusiness.GetPatientMas_List_v1(patientid);
            return response;
        }
        [HttpGet]
        [ActionName("get_web_PatientDtl")]
        public List<reswebPatientDtl> Web_PatientDtl_list(string Type, string search)
        {
            List<reswebPatientDtl> response = new List<reswebPatientDtl>();
            response = _mediBusiness.Web_PatientDtl_list(Type, search);
            return response;
        }

        [HttpGet]
        [ActionName("Get_QMS_Details")]
        public List<QMSDetails> Get_QMS_Details(string FromDate, string ToDate, string Type)
        {
            List<QMSDetails> response = new List<QMSDetails>();
            response = _mediBusiness.Get_QMS_Details(FromDate, ToDate, Type);
            return response;
        }
        [HttpGet]
        [ActionName("getAppList")]
        public List<resAppointmentList> appointmentList_v1(string FromDate, string ToDate)
        {
            List<resAppointmentList> response = new List<resAppointmentList>();
            response = _mediBusiness.Get_appointmentList_v1(FromDate, ToDate);
            return response;
        }

        [HttpGet]
        [ActionName("getAppList_All")]
        public List<resAppointmentListALL> appointmentList_All(string FromDate, string ToDate)
        {
            List<resAppointmentListALL> response = new List<resAppointmentListALL>();
            response = _mediBusiness.appointmentList_All(FromDate, ToDate);
            return response;
        }

        [HttpGet]
        [ActionName("Get_appointmentList")]
        public List<resAppointmentList> appointmentList(string Search)
        {
            List<resAppointmentList> response = new List<resAppointmentList>();
            response = _mediBusiness.Get_appointmentList(Search);
            return response;
        }


        [HttpGet]
        [ActionName("Get_Web_DepositeDtl_Reprint")]
        public List<DepositeDtl_ReprintList> WebDepositeDtlReprint(string FromDate, string ToDate, int Uhid)
        {
            List<DepositeDtl_ReprintList> response = new List<DepositeDtl_ReprintList>();
            response = _mediBusiness.Get_Web_Deposite_Reprint(FromDate, ToDate, Uhid);
            return response;
        }

        [HttpGet]
        [ActionName("Get_Web_PatDepositeDtl")]
        public List<DepositePatientDtl> Get_PatDepositeDtl(int patientid)
        {
            List<DepositePatientDtl> response = new List<DepositePatientDtl>();
            response = _mediBusiness.Get_PatDepositeDtl(patientid);
            return response;
        }
        [HttpGet]
        [ActionName("Get_web_DepositeReprint_Output")]
        public List<DepositeReprint_OutputDtl> Get_DepositeReprintOutput(string ReceiptNo)
        {
            List<DepositeReprint_OutputDtl> response = new List<DepositeReprint_OutputDtl>();
            response = _mediBusiness.Get_DepositeReprintOutput(ReceiptNo);
            return response;
        }
        [HttpGet]
        [ActionName("Get_WEB_SP_QMSStatus_Dtl")]
        public resHouseKeepingList Get_WEB_SP_QMSStatus_Dtl(string PatientName, string MobileNo, int PatType)
        {
            resHouseKeepingList response = new resHouseKeepingList();
            response = _mediBusiness.Get_WEB_SP_QMSStatus_Dtl(PatientName, MobileNo, PatType);
            return response;
        }


        [HttpGet]
        [ActionName("Get_DaywiseQMS_Data_V1")]
        public resDaywiseQMSList Get_DaywiseQMS_Data_V1()
        {
            resDaywiseQMSList response = new resDaywiseQMSList();
            response = _mediBusiness.Get_DaywiseQMS_Data_V1();
            return response;
        }

        [HttpPut]
        [ActionName("UpdateQMSStatus_Dtl")]
        public resHouseKeepingList UpdateQMSStatus_Dtl(Save_QMSDetails obj)
        {
            resHouseKeepingList response = new resHouseKeepingList();
            response = _mediBusiness.UpdateQMSStatus_Dtl(obj);
            return response;
        }

        [HttpPost]
        [ActionName("WebSave_QMS_Details")]
        public resHouseKeepingList WebSave_QMS_Details([FromBody] Save_QMSDetails obj)
        {
            resHouseKeepingList response = new resHouseKeepingList();
            response = _mediBusiness.WebSave_QMS_Details(obj);
            return response;
        }

        [HttpGet]
        [ActionName("Get_WEB_DayWiseQMS_Dtl")]
        public List<DayWise_QMSDetails> Get_WEB_DayWiseQMS_Dtl()
        {
            List<DayWise_QMSDetails> response = new List<DayWise_QMSDetails>();
            response = _mediBusiness.Get_WEB_DayWiseQMS_Dtl();
            return response;
        }

        [HttpGet]
        [ActionName("Get_WEB_DepPatAmt_Details")]
        public List<DepPatAmt_Details> Get_WEB_DepPatAmt_Details(int UHID)
        {
            List<DepPatAmt_Details> response = new List<DepPatAmt_Details>();
            response = _mediBusiness.Get_WEB_DepPatAmt_Details(UHID);
            return response;
        }

        [HttpGet]
        [ActionName("Get_web_DepositType_Dtl")]
        public List<clsDropDown> Get_web_DepositType_Dtl()
        {
            List<clsDropDown> response = new List<clsDropDown>();
            response = _mediBusiness.Get_web_DepositType_Dtl();
            return response;
        }


        [HttpGet]
        [ActionName("Get_web_RadLandingScreen_Dtl")]
        public List<clsRadLandingScreen> Get_web_RadLandingScreen_Dtl(string dtFrom, string dtTo, int blnOrderwise)
        {
            List<clsRadLandingScreen> response = new List<clsRadLandingScreen>();
            response = _mediBusiness.Get_web_RadLandingScreen_Dtl(dtFrom, dtTo, blnOrderwise);
            return response;
        }


        [HttpGet]
        [ActionName("Web_CardiologyLanding")]
        public List<clsCardiologyLanding> Web_CardiologyLanding(string FromDate, string ToDate)
        {
            List<clsCardiologyLanding> response = new List<clsCardiologyLanding>();
            response = _mediBusiness.Web_CardiologyLanding(FromDate, ToDate);
            return response;
        }

        [HttpGet]
        [ActionName("Web_NMLanding_Dtl")]
        public List<clsNMLanding_Dtl> Web_NMLanding_Dtl(string FromDate, string ToDate)
        {
            List<clsNMLanding_Dtl> response = new List<clsNMLanding_Dtl>();
            response = _mediBusiness.Web_NMLanding_Dtl(FromDate, ToDate);
            return response;
        }

        [HttpGet]
        [ActionName("Web_GetRadRequisitionSlipDetail")]
        public List<clsWeb_GetRadRequisitionSlipDetail> Web_GetRadRequisitionSlipDetail(string sPatient, string strRegID, string OrderID, string strSampleNo)
        {
            List<clsWeb_GetRadRequisitionSlipDetail> response = new List<clsWeb_GetRadRequisitionSlipDetail>();
            response = _mediBusiness.Web_GetRadRequisitionSlipDetail(sPatient, strRegID, OrderID, strSampleNo);
            return response;
        }

        [HttpGet]
        [ActionName("web_RadPatientSearch")]
        public List<clsweb_RadPatientSearch> web_RadPatientSearch(string FromDate, string ToDate, string MRN, string PatientName, string ApptTime, string DoctName, string Company, string MobileNo, string DeptName, int radmenu)
        {
            List<clsweb_RadPatientSearch> response = new List<clsweb_RadPatientSearch>();
            response = _mediBusiness.web_RadPatientSearch(FromDate, ToDate, MRN, PatientName, ApptTime, DoctName, Company, MobileNo, DeptName, radmenu);
            return response;
        }
        [HttpGet]
        [ActionName("web_NMPatientSearch")]
        public List<clsweb_NMPatientSearch> web_NMPatientSearch(string FromDate, string ToDate, string MRN, string PatientName, string ApptTime, string DoctName, string Company, string MobileNo, string DeptName, int radmenu)
        {
            List<clsweb_NMPatientSearch> response = new List<clsweb_NMPatientSearch>();
            response = _mediBusiness.web_NMPatientSearch(FromDate, ToDate, MRN, PatientName, ApptTime, DoctName, Company, MobileNo, DeptName, radmenu);
            return response;
        }

        [HttpGet]
        [ActionName("web_MediScanPatientSearch")]
        public List<clsweb_MediScanPatientSearch> web_MediScanPatientSearch(string FromDate, string ToDate, string MRN, string PatientName, string ApptTime, string DoctName, string Company, string MobileNo, string DeptName, int radmenu)
        {
            List<clsweb_MediScanPatientSearch> response = new List<clsweb_MediScanPatientSearch>();
            response = _mediBusiness.web_MediScanPatientSearch(FromDate, ToDate, MRN, PatientName, ApptTime, DoctName, Company, MobileNo, DeptName, radmenu);
            return response;
        }

        [HttpGet]
        [ActionName("opList")]
        public List<resOPList> opList(string Type, string Search)
        {
            List<resOPList> response = new List<resOPList>();
            response = _mediBusiness.Get_opList(Type, Search);
            return response;
        }


        [HttpGet]
        [ActionName("visitType")] // change.....29/10/2021
        public List<clsDropDown> GetvisitType(string type)
        {
            List<clsDropDown> req = new List<clsDropDown>();
            req = _mediBusiness.GetvisitType(type);

            return req;
        }

        [HttpGet]
        [ActionName("getPatientRegistrationPdf")]
        public clsPatientRegistrationPdf GetPatientRegOutPutPdf(int RegId)
        {
            clsPatientRegistrationPdf response = new clsPatientRegistrationPdf();
            response = _mediBusiness.GetPatientRegOutPutPdf(RegId);

            return response;
        }
        [HttpGet]
        [ActionName("GetInvoiceReprint_out_NEW")]

        public InvoiceHead1 OpReprint_V1(int BillNo)
        {
            InvoiceHead1 response = new InvoiceHead1();
            response = _mediBusiness.OpReprint_V1(BillNo);
            return response;
        }
        [HttpGet]
        [ActionName("getTransactionStatus")]
        public salucroresponse SalucroPayment_StatusCheck(string processingid)
        {
            try
            {
                DataTable dtPending;
                salucroresponse sresponse = new salucroresponse();
                salucrorequest request = new salucrorequest();
                clsQryResponse output = new clsQryResponse();
                dtPending = new DataTable();
                DataLayer dataLayer = new DataLayer();
                dtPending = dataLayer.getPendingDetails(processingid).Tables[0];

                request.processing_id = processingid;
                string checksum = MediDBConstants.sha256_hash(processingid + "|" + request.mid + "|" + request.auth_user + "|" + request.auth_key + "|" + MediDBConstants.secret_key);
                request.check_sum_hash = checksum;
                if (dtPending.Rows.Count > 0)
                    request.username = string.IsNullOrEmpty(dtPending.Rows[0]["Onl_CreatedCode"].ToString()) ? request.username : dtPending.Rows[0]["Onl_CreatedCode"].ToString();
                using (System.Net.WebClient client = new System.Net.WebClient())
                {
                    System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                    reqparm.Add("processing_id", request.processing_id);
                    reqparm.Add("mid", request.mid);
                    reqparm.Add("auth_user", request.auth_user);
                    reqparm.Add("auth_key", request.auth_key);
                    reqparm.Add("username", request.username);
                    reqparm.Add("check_sum_hash", request.check_sum_hash);
                    byte[] responsebytes = null;
                    responsebytes = client.UploadValues(MediDBConstants.salucro_url, "POST", reqparm);
                    string responsebody = (new System.Text.UTF8Encoding()).GetString(responsebytes);
                    sresponse = JsonConvert.DeserializeObject<salucroresponse>(responsebody);
                    client.Dispose();
                }
                return sresponse;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]//PRABHA03/12/2
        [ActionName("getInvoice_Reprint_List")]
        public List<reqInvoice_Reprint_List> web_Invoice_Reprint_List_procedure(string FromDate, string ToDate, string type, string Search)
        {
            List<reqInvoice_Reprint_List> response = new List<reqInvoice_Reprint_List>();

            response = _mediBusiness.web_Invoice_Reprint_List_procedure(FromDate, ToDate, type, Search);
            return response;
        }


        [HttpGet]
        [ActionName("get_WebRef_pat")]
        public List<clswebRef_patient> get_WebRef_pat(int appPatID)
        {
            List<clswebRef_patient> response = new List<clswebRef_patient>();
            response = _mediBusiness.get_WebRef_pat(appPatID);
            return response;
        }

        [HttpGet]
        [ActionName("BedRateAndNursingRate_dtl")]
        public List<BedRateAndNursingRate> BedRateAndNursingRate_dtl(int Bedcategoryid)
        {
            List<BedRateAndNursingRate> response = new List<BedRateAndNursingRate>();
            response = _mediBusiness.BedRateAndNursingRate_dtl(Bedcategoryid);
            return response;
        }


        [HttpGet]
        [ActionName("web_sp_BedDetails_Load")]
        public List<BedDetails_Load> web_sp_BedDetails_Load(int CatId)
        {
            List<BedDetails_Load> response = new List<BedDetails_Load>();
            response = _mediBusiness.web_sp_BedDetails_Load(CatId);
            return response;
        }

        [HttpGet]
        [ActionName("AuthenticateMobNo_Upload_V1")]
        public List<Authenticate> AuthenticateMobNo_Upload_V1(string OTP_MobileNo, int Otp)
        {
            List<Authenticate> response = new List<Authenticate>();
            response = _mediBusiness.AuthenticateMobNo_Upload_V1(OTP_MobileNo, Otp);
            return response;
        }


        [HttpGet]
        [ActionName("web_sp_Get_BedID")]
        public List<Get_BedID> web_sp_Get_BedID(int BedId)
        {
            List<Get_BedID> response = new List<Get_BedID>();
            response = _mediBusiness.web_sp_Get_BedID(BedId);
            return response;
        }

        [HttpGet]
        [ActionName("BedBlockDetails_Load")]
        public List<BedBlockDetails> BedBlockDetails_Load()
        {
            List<BedBlockDetails> response = new List<BedBlockDetails>();
            response = _mediBusiness.BedBlockDetails_Load();
            return response;
        }

        [HttpGet]
        [ActionName("Get_CriticalCare_InfectiousDis")]
        public List<CriticalCare> Get_CriticalCare_InfectiousDis()
        {
            List<CriticalCare> response = new List<CriticalCare>();
            response = _mediBusiness.Get_CriticalCare_InfectiousDis();
            return response;
        }

        [HttpPost]
        [ActionName("InsertCriticalCare_InfectiousDis")]
        public InsertCriticalCare_InfectiousDis_Res InsertCriticalCare_InfectiousDis(InsertCriticalCare_req obj)
        {
            InsertCriticalCare_InfectiousDis_Res response = new InsertCriticalCare_InfectiousDis_Res();
            response = _mediBusiness.InsertCriticalCare_InfectiousDis(obj);
            return response;
        }

        //sujithra  ---end


        [HttpGet]
        [ActionName("Get_Doctor_Directory_Js")]
        public List<Doctor_Directory> Get_Doctor_Directory_Js()
        {
            List<Doctor_Directory> response = new List<Doctor_Directory>();
            response = _mediBusiness.Get_Doctor_Directory_Js();
            return response;
        }


        //[HttpPost]
        //[ActionName("AuthenticateMobNo_Upload_V1")]
        //public Response_v1 AuthenticateMobNo_Upload_V1(Authenticate Auth_request)
        //{
        //    Response_v1 response = new Response_v1();
        //    response = _mediBusiness.AuthenticateMobNo_Upload_V1(Auth_request);
        //    return response;
        //}


        [HttpPost]
        [ActionName("InsertDoctor_Directory_Js")]
        public InsertDoctor_Directory_Js_Res InsertDoctor_Directory_Js(InsertDoctor_Directory_Js_req obj)
        {
            InsertDoctor_Directory_Js_Res response = new InsertDoctor_Directory_Js_Res();
            response = _mediBusiness.InsertDoctor_Directory_Js(obj);
            return response;
        }

        [HttpPut]
        [ActionName("UPDATEDoctor_Directory_Js")]
        public UPDATEDoctor_Directory_Js_Res UPDATEDoctor_Directory_Js(UPDATEDoctor_Directory_Js_req obj)
        {
            UPDATEDoctor_Directory_Js_Res response = new UPDATEDoctor_Directory_Js_Res();
            response = _mediBusiness.UPDATEDoctor_Directory_Js(obj);
            return response;
        }

        [HttpGet]
        [ActionName("Get_TVbackgraound")]
        public List<TVbackgraound> Get_TVbackgraound()
        {
            List<TVbackgraound> response = new List<TVbackgraound>();
            response = _mediBusiness.Get_TVbackgraound();
            return response;
        }

        [HttpPut]
        [ActionName("UpdateTVbackgraound")]
        public UpdateTVbackgraound_Res UpdateTVbackgraound(UpdateTVbackgraound_req obj)
        {
            UpdateTVbackgraound_Res response = new UpdateTVbackgraound_Res();
            response = _mediBusiness.UpdateTVbackgraound(obj);
            return response;
        }
        [HttpPost]
        [ActionName("updatePOSPayment")]
        public Response_DTO_v1 updatePOSPayment(payment_request payment_Request)
        {
            Response_DTO_v1 response = new Response_DTO_v1();
            response = _mediBusiness.updatePOSPayment(payment_Request);
            return response;
        }
        [HttpPost]
        [ActionName("updateOnlinePayment")]
        public Response_DTO_v1 updateOnlinePayment(payment_request payment_Request)
        {
            Response_DTO_v1 response = new Response_DTO_v1();
            response = _mediBusiness.updateOnlinePayment(payment_Request);
            return response;
        }

        

        [HttpPost]
        [ActionName("sendotp_Portal")]
        public SendPatientDTO sendotp_Portal([FromBody] SendPatientDTO patient)
        {
            string URL = "";
            Random rm = new Random();
            string RandomNumber = rm.Next(1000, 9999).ToString();

            //if (patient.CountryCode == "101") by jeyaganesh 04.05.2021

            URL = "https://alerts.qikberry.com/api/v2/sms/send?access_token=ae3661d756b5cbaa28548a90e87f565d&message=Your OTP is " + RandomNumber + ", Dr. Rela Institute and Medical Centre." + "&sender=RELAIN&to=" + patient.MobileNo + "&service=T";


            ////if (patient.CountryCode == "+91")
            ////{
            ////    URL = "https://alerts.qikberry.com/api/v2/sms/send?access_token=ae3661d756b5cbaa28548a90e87f565d&message=Your OTP is " + RandomNumber + ", Dr. Rela Institute and Medical Centre." + "&sender=RELAIN&to=" + patient.MobileNo + "&service=T";
            ////}
            ////else
            ////{
            ////    URL = "https://alerts.qikberry.com/api/v2/sms/send?access_token=ae3661d756b5cbaa28548a90e87f565d&message=YourOTPis " + RandomNumber + ", Dr. Rela Institute and Medical Centre." + "&sender=RELAIN&to=" + patient.MobileNo + "&service=G";
            ////}
            //URL = "https://alerts.qikberry.com/api/v2/sms/send?access_token=f61f0a429797f88328690649ed72cfb3&message=YourOTPis " + RandomNumber + "&sender=RELAIN&to=" + patient.MobileNo + "&service=T";

            WebRequest myWebRequest = WebRequest.Create(URL);
            WebResponse myWebResponse = myWebRequest.GetResponse();
            Stream ReceiveStream = myWebResponse.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader readStream = new StreamReader(ReceiveStream, encode);
            string strResponse = readStream.ReadToEnd();

            string strRetmessage = "";
            if (strResponse.Contains("422"))
                strRetmessage = "OTP Not Delivered";
            else
                strRetmessage = "OTP Delivered";

            _mediBusiness.InsertUpdateOTP_portal(RandomNumber, patient.MobileNo);
            patient.Authenticated = strRetmessage;
            return patient;

        }

        [HttpPost]
        [ActionName("verifyotp")]
        public OTP_Resp authenticate([FromBody] reqPatientDTO patientDTO)
        {
            string strRetmessage = "";
            OTP_Resp patientres = new OTP_Resp();

            List<PatientDTO> patdto = new List<PatientDTO>();
            //List<AutheticateDTO> authenticated = new List<AutheticateDTO>();
            List<PatientDTO> patients = new List<PatientDTO>();
            strRetmessage = _mediBusiness.AuthenticateOTP(patientDTO.OTP, patientDTO.MobileNo);

            //List<PatientDTO> appointmentSlots = new List<PatientDTO>();
            //appointmentSlots = _mediBusiness.GetAppointmentSlotDetails(appointmentSlot);
            if (strRetmessage == "1")
                //patientres = _mediBusiness.GetPatientResp_MobNo(patientDTO.OTP, patientDTO.MobileNo);
                patientres.response = "OTP Sucess";


            else
            {
                PatientDTO po = new PatientDTO();
                po.UHID = "";
                po.PatientName = "";
                po.Gender = "";
                po.DOB = "";
                po.MobileNo = "";
                po.Authenticated = "OTP Mismatched";
                patients.Add(po);
                patientres.patientDTO = patients;
                patientres.responsecode = 1;
                patientres.response = "OTP Mismatched";
                patientres.status = "";
            }
            return patientres;
        }


        [HttpGet]
        [ActionName("Get_BirthDay_Info_New")]
        public List<res_BirthDay_Info_New> Get_BirthDay_Info_New(string date)
        {
            List<res_BirthDay_Info_New> response = new List<res_BirthDay_Info_New>();
            response = _mediBusiness.Get_BirthDay_Info_New(date);
            return response;
        }

        
        //[Route("import_temporarily")]
        //[HttpPost]
        //public async Task<List<LicenseModel>> import_temporarily()
        //{

        //    List<LicenseModel> list = new List<LicenseModel>();
        //    var httpContext = HttpContext.Current;
        //    string EmpNo = System.Web.HttpContext.Current.Request.Headers.Get("EmpNo");
        //    if (httpContext.Request.Files.Count > 0)
        //    {
        //        for (int i = 0; i < httpContext.Request.Files.Count; i++)
        //        {
        //            HttpPostedFile httpPostedFile = httpContext.Request.Files[i];
        //            if (httpPostedFile != null)
        //            {
        //                LicenseModel GetAll = new LicenseModel();
        //                var postedFile = httpContext.Request.Files[i].FileName;
        //                var root = HttpContext.Current.Server.MapPath("~/temp/" + EmpNo + "/");
        //                Directory.CreateDirectory(root);
        //                var path = Path.Combine(root, postedFile);
        //                httpPostedFile.SaveAs(path);
        //                GetAll.TempPath_FileName = postedFile;
        //                GetAll.UserName = EmpNo;
        //                GetAll.TempPath = EmpNo + "/" + postedFile;
        //                list.Add(GetAll);
        //            }
        //        }
        //    }
        //    return list;
        //}      

        //[Route("DownloadUploadedFiles")]
        //[HttpPost]
        //public List<LicenseModel> DownloadUploadedFiles(HttpRequestMessage request, LicenseModel lic)
        //{
        //    List<LicenseModel> list = new List<LicenseModel>();
        //    try
        //    {
        //        SqlConnection con = new SqlConnection(CommonClass.getconnection());
        //        con.Open();
        //        DataTable dt = new DataTable();
        //        SqlCommand cmd = new SqlCommand("Select * from LicensePath where LicenseName='" + lic.LicenceName.Trim() + "'", con);
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataSet ds = new DataSet();
        //        da.Fill(ds, "LicensePath");
        //        dt = ds.Tables[0];
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            LicenseModel GetAll = new LicenseModel();
        //            GetAll.LicenceId = dt.Rows[i]["LicenseID"].ToString();
        //            GetAll.Department = dt.Rows[i]["Department"].ToString();
        //            GetAll.LicenceName = dt.Rows[i]["LicenseName"].ToString();
        //            GetAll.LicencePath = dt.Rows[i]["Path"].ToString();
        //            //GetAll.LicenceNo = dt.Rows[i]["LicenseNo"].ToString();
        //            list.Add(GetAll);
        //        }
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        // logerrors("Exception", "Method => SubejctDAL - LoadTechnologyDetails", ex.Message);
        //    }
        //    return list;
        //}

        //[Route("DeleteFilefromDisk")]
        //[HttpPost]
        //public LicenseModel DeleteFilefromDisk(HttpRequestMessage request, LicenseModel lic)
        //{
        //    List<LicenseModel> list = new List<LicenseModel>();
        //    try
        //    {
        //        var root = HttpContext.Current.Server.MapPath("~/LicenseUpload/") + lic.Department + "\\" + lic.LicenceName + "\\" + lic.LicencePath;
        //        if (File.Exists(root))
        //        {
        //            File.Delete(root);
        //            SqlConnection con = new SqlConnection(CommonClass.getconnection());
        //            SqlCommand cmd = new SqlCommand("Delete from LicensePath where Path='" + lic.LicencePath + "'", con);
        //            cmd.CommandType = CommandType.Text;
        //            con.Open();
        //            int iResult = cmd.ExecuteNonQuery();
        //            con.Close();
        //            if (iResult == 1)
        //            {
        //                lic.ReturnMessage = "The requested file is deleted";
        //                lic.ReturnStatus = 1;
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        // logerrors("Exception", "Method => SubejctDAL - LoadTechnologyDetails", ex.Message);
        //    }
        //    return lic;
        //}

    }

}
