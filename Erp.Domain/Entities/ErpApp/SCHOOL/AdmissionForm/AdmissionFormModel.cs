using Erp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Domain.Entities.ErpApp.SCHOOL.AdmissionForm
{
    public class AdmissionFormModel : AuditableEntity
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentFullName { get; set; }
        public string StudentDateOfBirth { get; set; }

    

        public string Guardian1FullName { get; set; }

        public string Guardian1MobileNumber { get; set; }

        public string GradeName { get; set; }

        public string ShiftTypeName { get; set; }

        public string GenderName { get; set; }

        public string StudentEnrollmentDate_Admin { get; set; }

        public string StudentRoll_Admin { get; set; }

        public string LOCATION { get; set; }
        /* */

        public int branchId { get; set; }
        public string studentFirstName { get; set; }
        public string studentMiddleName { get; set; }
        public string studentLastName { get; set; }
        public string studentDateofBirth { get; set; }
        public string studentBirthCertificateNumber { get; set; }

        public int? genderId { get; set; }
        public int? religionId { get; set; }//1
        public string nationality { get; set; } /*Nationality   StudentNationality*/
        public string passportNo { get; set; } /*passportNo  StudentPassportNumber */
        public string IsInternationalStudent { get; set; }
        public int? countryId { get; set; } /*countryId StudentCountryId*///2
        public int? studentPresentdivisitionId { get; set; }/*StudentPresentdivisitionId*///3
        public int? studentPresentdistrictId { get; set; }//4
        public int? studentPresentthanaId { get; set; }//5
        public string presentpostalCode { get; set; }
        //public string StudentPresentAddress { get; set; }
        public int? studentPermanentdivisitionId { get; set; }//6
        public int? studentPermanentdistrictId { get; set; }//7
        public int? studentPermanentthanaId { get; set; } /*studentPresentthanaId*///8
        public string permanentpostalCode { get; set; }
        //public string StudentPermanentAddress { get; set; }
        public int? studentInfogradeId { get; set; }//9
        public int? ShiftId { get; set; }//10
        public string SmsNumber { get; set; }
        public string IsCehckStudentEnglishProficiency { get; set; }
        //public string FileTypeId { get; set; }
        public string fathersName { get; set; }
        public string fathersNationality { get; set; }
        public string fathersNetIncome { get; set; }
        public int? fathersqualificationId { get; set; }
        public string fathersEducationalInstitute { get; set; }
        public int? fathersoccupationId { get; set; }//11
        public string fathersOrganization { get; set; }
        public string fathersOfficeAddress { get; set; }
        public string fathersMobile { get; set; }
        public string fathersEmail { get; set; }
        public string fathersNid { get; set; }
        public string fathersPassport { get; set; }
        public string fathersEtin { get; set; }
        public int? fatherbloodGroupId { get; set; }
        public int? fatherdivisitionId { get; set; }//12
        public int? fatherPresentdistrictId { get; set; }//13
        public int? fatherPresentthanaId { get; set; }//14
        public string fatherpostalCode { get; set; }
        public string FatherPresentAddress { get; set; }
        public string isFatherWorkingForMasco { get; set; }
        public string fathersIdNo { get; set; }
        public string mothersName { get; set; }
        public string mothersNationality { get; set; }
        public string mothersNetIncome { get; set; }
        public int? mothersqualificationId { get; set; }//15
        public string mothersEducationalInstitute { get; set; }
        //public string mothersOcupation { get; set; }
        public int? mothersoccupationId { get; set; }
        
        public string mothersOrganization { get; set; }
        public string mothersOfficeAddress { get; set; }
        public string mothersMobile { get; set; }
        public string mothersEmail { get; set; }
        public string mothersNid { get; set; }
        public string mothersPassport { get; set; }
        public string mothersEtin { get; set; }
        public int? motherbloodGroupId { get; set; }//16
        public int? motherdivisitionId { get; set; }//17
        public int? motherPresentdistrictId { get; set; }//18
        public int? motherPresentthanaId { get; set; }//19
        public string mothersPostalCode { get; set; }
        public string MotherPresentAddress { get; set; }
        public string isMotherWorkingForMasco { get; set; }
        public string mothersIdNumber { get; set; }
        public string guardians1FullName { get; set; }
        public string guardians1Nationality { get; set; }
        public int? guardians1RelationshipId { get; set; }
        public string guardians1Mobile { get; set; }
        public string guardians1Nid { get; set; }
        public string guardians1Email { get; set; }
        public int? guardians1divisitionId { get; set; }//20
        public int? guardians1PresentdistrictId { get; set; }//21
        public int? guardians1PresentthanaId { get; set; }//22
        public string guardians1PostalCode { get; set; }
        //public string Guardian1PresentAddress { get; set; }
        public string guardians2FullName { get; set; }
        public string guardians2Nationality { get; set; }
        public int? guardians2RelationshipId { get; set; }
        public string guardians2Mobile { get; set; }
        public string guardians2Nid { get; set; }
        public string guardians2Email { get; set; }
        public int? guardians2divisitionId { get; set; }//23
        public int? guardians2PresentdistrictId { get; set; }//24
        public int? guardians2PresentthanaId { get; set; }//25
        public string guardians2PostalCode { get; set; }
        //public string Guardian2PresentAddress { get; set; }
        public string emergencyFullName { get; set; }
        public int? emergencyRelationshipId { get; set; }//28
        public string emergencyContact { get; set; }
        public string emergencyEmail { get; set; }
        public int? emergencydivisitionId { get; set; }//27
        public int? emergencyPresentdistrictId { get; set; }

        public int? emergencyThanaId { get; set; }//26


        //public string EmergencyPostalCode { get; set; }
        //        public string NumberOfSiblings { get; set; }

        public string sibling1FullName { get; set; }
        public string sibling1SchoolName { get; set; }
        public string sibling1gradeId { get; set; }//29
        public string isSibling1ExistingStudentOrGraduate { get; set; }
        public string IsSiblings1Graduate { get; set; }
        public string sibling1yearId { get; set; }
        public string isSibling1StudentOfMSK { get; set; }
        public string sibling1IdNo { get; set; }
        public string sibling2FullName { get; set; }
        public string sibling2SchoolName { get; set; }
        public string sibling2gradeId { get; set; }
        public string isSibling2ExistingStudentOrGraduate { get; set; }
        //public string Siblings2Graduate { get; set; }
        public string sibling2yearId { get; set; }
        public string isSibling2StudentOfMSK { get; set; }
        public string sibling2IdNo { get; set; }
        public string sibling3FullName { get; set; }
        public string sibling3SchoolName { get; set; }
        public string sibling3gradeId { get; set; }
        public string isSibling3ExistingStudentOrGraduate { get; set; }
        //public string Siblings3Graduate { get; set; }
        public string sibling3yearId { get; set; }
        public string isSibling3StudentOfMSK { get; set; }
        public string sibling3IdNo { get; set; }
        public int? healthbloodGroupId { get; set; }
        public string studentHeight { get; set; }
        public string studentWeight { get; set; }
        public string studentIdentificationSpot { get; set; }
        //public string Ear_Problem { get; set; }
        //public string Eye_Problem { get; set; }
        //public string Emotional_Problem { get; set; }
        //public string Migraines_Problem { get; set; }
        //public string Asthma_Problem { get; set; }
        //public string ADD_ADHA_Problem { get; set; }
        public string isFoodAllergy { get; set; }
        public string studentFoodAllergies { get; set; }
        public string IsAnyMedication { get; set; }
        public string studentRegularMedication { get; set; }
        //public string StudentId { get; set; }
        public string studentEnrollmentDate { get; set; }
        public int? adminyearId { get; set; }
        public string isTcReceived { get; set; }
        public string studentTcNo { get; set; }
        public string studentTcDate { get; set; }
        public string studentSchool { get; set; }
        public int? studentgradeId { get; set; }
        public int? sectionId { get; set; }
        public string studentRoll { get; set; }
        public string studentHouse { get; set; }
        public string isTransportFacility { get; set; }

        public virtual IList<PreviousInstituteDataModel> PreviousInstituteData { get; set; }

        public virtual IList<HealthConditionDetailModel> HealthConditionData { get; set; }

        public virtual IList<healthInfoDetailModel> HealthInfoData { get; set; }
        //public List<studentInfoAttachmentDetailDto> studentInfoAttachmentData { get; set; }
        //public IList<CreateAdmissionFormFileTypeModel> AdmissionFormFileTypeList { get; set; }

        public string StudentPresentAddress { get; set; }


      
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }

      

        public string fatherPresentAddress { get; set; }
        public string motherPresentAddress { get; set; }
        public string guardians1PresentAddress { get; set; }
        public string guardians2PresentAddress { get; set; }
        public string emergencyPresentAddress { get; set; }

    }
    //public class CreateAdmissionFormFileTypeModel : IMapFrom<AdmissionFormFileTypeModel>
    //{
    //    public string FilE_TYPE_ID { get; set; }

    //    public int FileObjectId { get; set; }

    //    public string AdmissionFormMasterId { get; set; }
    //    public string studentBasicInfoFileType_filE_TYPE_NAME { get; set; }

    //    public string FilE_NAME { get; set; }
    //    public string studentBasicInfoSpecFile { get; set; }

    //}
    public class PreviousInstituteDataModel : AuditableEntity
    {
        public int Id { get; set; }
        public int admissionFormId { get; set; }
        public string schoolName { get; set; }
        public string grade { get; set; }
        public string location { get; set; }
        public string result { get; set; }
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }
        public string Active_YN { get; set; }

    }
    public class HealthConditionDataModel : AuditableEntity
    {
        public int Id { get; set; }
        public int admissionFormId { get; set; }
        public string sphConditionId { get; set; }
        public string specialHealthCondition { get; set; }
        public string IsHealthCondition { get; set; }

        public string Active_YN { get; set; }

    }
    public class healthInfoDetailModel : AuditableEntity
    {
        public int Id { get; set; }
        public int admissionFormId { get; set; }
        public string diseaseNameId { get; set; }
        public string diseaseName { get; set; }
        public string IsdiseasCondition { get; set; }
        public DateTime? diseasDate { get; set; }
        public string Active_YN { get; set; }

    }
}

        
