using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SurveyConsole.Models.FACEDB
{
    public partial class FACEDBContext : DbContext
    {
        public FACEDBContext()
        {
        }

        public FACEDBContext(DbContextOptions<FACEDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<DmValidationCollView> DmValidationCollViews { get; set; }
        public virtual DbSet<MasterArea> MasterAreas { get; set; }
        public virtual DbSet<MasterBranch> MasterBranches { get; set; }
        public virtual DbSet<MasterCabangApi> MasterCabangApis { get; set; }
        public virtual DbSet<MasterDomicile> MasterDomiciles { get; set; }
        public virtual DbSet<MasterInsurance> MasterInsurances { get; set; }
        public virtual DbSet<MasterJob> MasterJobs { get; set; }
        public virtual DbSet<MasterLocation> MasterLocations { get; set; }
        public virtual DbSet<MasterOwnership> MasterOwnerships { get; set; }
        public virtual DbSet<MasterPlat> MasterPlats { get; set; }
        public virtual DbSet<MbranchView> MbranchViews { get; set; }
        public virtual DbSet<MmerkView> MmerkViews { get; set; }
        public virtual DbSet<MmodelView> MmodelViews { get; set; }
        public virtual DbSet<MpriceListView> MpriceListViews { get; set; }
        public virtual DbSet<MstUser> MstUsers { get; set; }
        public virtual DbSet<MtypeView> MtypeViews { get; set; }
        public virtual DbSet<RptOfferingletterFacSyariah> RptOfferingletterFacSyariahs { get; set; }
        public virtual DbSet<SiapDm> SiapDms { get; set; }
        public virtual DbSet<SiapDr> SiapDrs { get; set; }
        public virtual DbSet<TapplCStatus> TapplCStatuses { get; set; }
        public virtual DbSet<TapplCStatusLog> TapplCStatusLogs { get; set; }
        public virtual DbSet<TvalidationCollateral> TvalidationCollaterals { get; set; }
        public virtual DbSet<TvalidationCollateralIdnumber> TvalidationCollateralIdnumbers { get; set; }
        public virtual DbSet<TvalidationCollateralPhysical> TvalidationCollateralPhysicals { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.ToTable("Configuration");

                entity.Property(e => e.ConfigurationId)
                    .ValueGeneratedNever()
                    .HasColumnName("ConfigurationID");

                entity.Property(e => e.ConfigurationName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ConfigurationValue)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DmValidationCollView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DM_VALIDATION_COLL_VIEW");

                entity.Property(e => e.ApplId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPL_ID");

                entity.Property(e => e.ApplicationStatus)
                    .HasMaxLength(50)
                    .HasColumnName("application_status");

                entity.Property(e => e.BankAccountName)
                    .HasMaxLength(50)
                    .HasColumnName("bank_account_name");

                entity.Property(e => e.BankAccountNumber)
                    .HasMaxLength(50)
                    .HasColumnName("bank_account_number");

                entity.Property(e => e.BankName)
                    .HasMaxLength(50)
                    .HasColumnName("bank_name");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.CarBrand)
                    .HasMaxLength(50)
                    .HasColumnName("car_brand");

                entity.Property(e => e.CarInsurance)
                    .HasMaxLength(50)
                    .HasColumnName("car_insurance");

                entity.Property(e => e.CarModel)
                    .HasMaxLength(50)
                    .HasColumnName("car_model");

                entity.Property(e => e.CarPhoto)
                    .HasMaxLength(200)
                    .HasColumnName("car_photo");

                entity.Property(e => e.CarRegistrationNumber)
                    .HasMaxLength(50)
                    .HasColumnName("car_registration_number");

                entity.Property(e => e.CarType)
                    .HasMaxLength(50)
                    .HasColumnName("car_type");

                entity.Property(e => e.CarYear)
                    .HasMaxLength(50)
                    .HasColumnName("car_year");

                entity.Property(e => e.CollArrivedBase)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("coll_arrived_base");

                entity.Property(e => e.CollArrivedCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("coll_arrived_code");

                entity.Property(e => e.CollArrivedLat)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("coll_arrived_lat");

                entity.Property(e => e.CollArrivedLng)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("coll_arrived_lng");

                entity.Property(e => e.CollArrivedName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("coll_arrived_name");

                entity.Property(e => e.CollateralAssignto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("collateral_assignto");

                entity.Property(e => e.CompanyAddress).HasMaxLength(200);

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.CompanyPhone).HasMaxLength(50);

                entity.Property(e => e.ContractNo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("contract_no");

                entity.Property(e => e.CreBy)
                    .HasMaxLength(50)
                    .HasColumnName("cre_by");

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasColumnName("cre_date");

                entity.Property(e => e.CreIp)
                    .HasMaxLength(50)
                    .HasColumnName("cre_ip");

                entity.Property(e => e.CurrentFormStep)
                    .HasMaxLength(50)
                    .HasColumnName("current_form_step");

                entity.Property(e => e.DigisignFile)
                    .HasMaxLength(500)
                    .HasColumnName("digisign_file");

                entity.Property(e => e.DomAddress)
                    .HasMaxLength(255)
                    .HasColumnName("dom_address");

                entity.Property(e => e.DomCode)
                    .HasMaxLength(50)
                    .HasColumnName("dom_code");

                entity.Property(e => e.DomDistrict)
                    .HasMaxLength(50)
                    .HasColumnName("dom_district");

                entity.Property(e => e.DomDistrictCode)
                    .HasMaxLength(50)
                    .HasColumnName("dom_district_code");

                entity.Property(e => e.DomLat)
                    .HasMaxLength(50)
                    .HasColumnName("dom_lat");

                entity.Property(e => e.DomLng)
                    .HasMaxLength(50)
                    .HasColumnName("dom_lng");

                entity.Property(e => e.DomOwnership)
                    .HasMaxLength(50)
                    .HasColumnName("dom_ownership");

                entity.Property(e => e.DomPostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("dom_postal_code")
                    .IsFixedLength(true);

                entity.Property(e => e.DomProvince)
                    .HasMaxLength(50)
                    .HasColumnName("dom_province");

                entity.Property(e => e.DomProvinceCode)
                    .HasMaxLength(50)
                    .HasColumnName("dom_province_code");

                entity.Property(e => e.DomRt)
                    .HasMaxLength(10)
                    .HasColumnName("dom_rt");

                entity.Property(e => e.DomRw)
                    .HasMaxLength(10)
                    .HasColumnName("dom_rw");

                entity.Property(e => e.DomSubdistrict1)
                    .HasMaxLength(50)
                    .HasColumnName("dom_subdistrict1");

                entity.Property(e => e.DomSubdistrict1Code)
                    .HasMaxLength(50)
                    .HasColumnName("dom_subdistrict1_code");

                entity.Property(e => e.DomSubdistrict2)
                    .HasMaxLength(50)
                    .HasColumnName("dom_subdistrict2");

                entity.Property(e => e.DomSubdistrict2Code)
                    .HasMaxLength(50)
                    .HasColumnName("dom_subdistrict2_code");

                entity.Property(e => e.EkycEmail)
                    .HasMaxLength(50)
                    .HasColumnName("ekyc_email");

                entity.Property(e => e.EkycRejectReason)
                    .HasMaxLength(50)
                    .HasColumnName("ekyc_reject_reason");

                entity.Property(e => e.EkycStatus)
                    .HasMaxLength(50)
                    .HasColumnName("ekyc_status");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.EntryId).HasColumnName("entry_id");

                entity.Property(e => e.EstimatedDisbursement)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("estimated_disbursement");

                entity.Property(e => e.EstimatedInstallment)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("estimated_installment");

                entity.Property(e => e.Fee)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("fee");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.IdAddress)
                    .HasMaxLength(255)
                    .HasColumnName("id_address");

                entity.Property(e => e.IdDistrict)
                    .HasMaxLength(50)
                    .HasColumnName("id_district");

                entity.Property(e => e.IdDistrictCode)
                    .HasMaxLength(50)
                    .HasColumnName("id_district_code");

                entity.Property(e => e.IdLat)
                    .HasMaxLength(50)
                    .HasColumnName("id_lat");

                entity.Property(e => e.IdLng)
                    .HasMaxLength(50)
                    .HasColumnName("id_lng");

                entity.Property(e => e.IdPostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("id_postal_code");

                entity.Property(e => e.IdProvince)
                    .HasMaxLength(50)
                    .HasColumnName("id_province");

                entity.Property(e => e.IdProvinceCode)
                    .HasMaxLength(50)
                    .HasColumnName("id_province_code");

                entity.Property(e => e.IdRt)
                    .HasMaxLength(50)
                    .HasColumnName("id_rt");

                entity.Property(e => e.IdRw)
                    .HasMaxLength(50)
                    .HasColumnName("id_rw");

                entity.Property(e => e.IdSubdistrict1)
                    .HasMaxLength(50)
                    .HasColumnName("id_subdistrict1");

                entity.Property(e => e.IdSubdistrict1Code)
                    .HasMaxLength(50)
                    .HasColumnName("id_subdistrict1_code");

                entity.Property(e => e.IdSubdistrict2)
                    .HasMaxLength(50)
                    .HasColumnName("id_subdistrict2");

                entity.Property(e => e.IdSubdistrict2Code)
                    .HasMaxLength(50)
                    .HasColumnName("id_subdistrict2_code");

                entity.Property(e => e.IsExpressSurvey)
                    .HasMaxLength(50)
                    .HasColumnName("is_express_survey");

                entity.Property(e => e.JobType).HasMaxLength(50);

                entity.Property(e => e.KtpPhoto)
                    .HasMaxLength(200)
                    .HasColumnName("ktp_photo");

                entity.Property(e => e.MfinState)
                    .HasMaxLength(50)
                    .HasColumnName("mfin_state");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(50)
                    .HasColumnName("mobile_number");

                entity.Property(e => e.ModBy)
                    .HasMaxLength(50)
                    .HasColumnName("mod_by");

                entity.Property(e => e.ModDate)
                    .HasColumnType("datetime")
                    .HasColumnName("mod_date");

                entity.Property(e => e.ModIp)
                    .HasMaxLength(50)
                    .HasColumnName("mod_ip");

                entity.Property(e => e.MonthlyIncome)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("monthly_income");

                entity.Property(e => e.MothersName)
                    .HasMaxLength(100)
                    .HasColumnName("mothers_name");

                entity.Property(e => e.NikNumber)
                    .HasMaxLength(50)
                    .HasColumnName("nik_number");

                entity.Property(e => e.NpwpNumber)
                    .HasMaxLength(50)
                    .HasColumnName("npwp_number");

                entity.Property(e => e.NpwpPhoto)
                    .HasMaxLength(200)
                    .HasColumnName("npwp_photo");

                entity.Property(e => e.PamNumber)
                    .HasMaxLength(50)
                    .HasColumnName("PAM_Number");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("phone_number");

                entity.Property(e => e.PlaceOfBirth)
                    .HasMaxLength(50)
                    .HasColumnName("place_of_birth");

                entity.Property(e => e.PlnNumber)
                    .HasMaxLength(50)
                    .HasColumnName("PLN_Number");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("product_name");

                entity.Property(e => e.ReasonReject)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("reason_reject");

                entity.Property(e => e.ReasonResult)
                    .IsUnicode(false)
                    .HasColumnName("REASON_RESULT");

                entity.Property(e => e.RecommendationResult).HasColumnName("RECOMMENDATION_RESULT");

                entity.Property(e => e.ResiNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RESI_NUMBER");

                entity.Property(e => e.SelfieWithKtpPhoto)
                    .HasMaxLength(200)
                    .HasColumnName("selfie_with_ktp_photo");

                entity.Property(e => e.SiapId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("siap_id");

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .HasColumnName("source");

                entity.Property(e => e.SpouseName).HasMaxLength(100);

                entity.Property(e => e.SpouseNikNumber)
                    .HasMaxLength(50)
                    .HasColumnName("spouseNik_number");

                entity.Property(e => e.StnkPhoto)
                    .HasMaxLength(200)
                    .HasColumnName("stnk_photo");

                entity.Property(e => e.SubmittedAmount)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("submitted_amount");

                entity.Property(e => e.SurveyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("survey_date");

                entity.Property(e => e.Tenor).HasColumnName("tenor");

                entity.Property(e => e.Wop)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("wop");
            });

            modelBuilder.Entity<MasterArea>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Master_Area");

                entity.Property(e => e.AreaId)
                    .HasMaxLength(50)
                    .HasColumnName("AreaID");

                entity.Property(e => e.AreaName).HasMaxLength(50);
            });

            modelBuilder.Entity<MasterBranch>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Master_Branch");

                entity.Property(e => e.AreaId)
                    .HasMaxLength(50)
                    .HasColumnName("AreaID");

                entity.Property(e => e.BranchId)
                    .HasMaxLength(50)
                    .HasColumnName("BranchID");

                entity.Property(e => e.BranchName).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);
            });

            modelBuilder.Entity<MasterCabangApi>(entity =>
            {
                entity.ToTable("Master_Cabang_Api");

                entity.Property(e => e.Data).HasColumnType("text");

                entity.Property(e => e.NamaCabang)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MasterDomicile>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Master_Domicile");

                entity.Property(e => e.DomId).HasColumnName("domID");

                entity.Property(e => e.DomStatus).HasColumnName("domStatus");

                entity.Property(e => e.DomType)
                    .HasMaxLength(50)
                    .HasColumnName("domType");
            });

            modelBuilder.Entity<MasterInsurance>(entity =>
            {
                entity.HasKey(e => e.InsuranceId)
                    .HasName("PK__Master_I__74231BC4566C3D25");

                entity.ToTable("Master_Insurance");

                entity.Property(e => e.InsuranceId)
                    .ValueGeneratedNever()
                    .HasColumnName("InsuranceID");

                entity.Property(e => e.Desc)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InsuranceType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MasterJob>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Master_Job");

                entity.Property(e => e.JobId).HasColumnName("jobID");

                entity.Property(e => e.JobName).HasMaxLength(100);

                entity.Property(e => e.JobStatus).HasColumnName("jobStatus");
            });

            modelBuilder.Entity<MasterLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.ToTable("Master_Location");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.KodeCabang)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Kota)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NamaCabang)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NoFax)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoKantor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UrlLink)
                    .IsUnicode(false)
                    .HasColumnName("URL_Link");
            });

            modelBuilder.Entity<MasterOwnership>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Master_Ownership");

                entity.Property(e => e.OwnerId).HasColumnName("ownerID");

                entity.Property(e => e.OwnerStatus).HasColumnName("ownerStatus");

                entity.Property(e => e.OwnerType)
                    .HasMaxLength(50)
                    .HasColumnName("ownerType");
            });

            modelBuilder.Entity<MasterPlat>(entity =>
            {
                entity.HasKey(e => e.PlatId)
                    .HasName("PK__Master_P__77C40E8B41B7B2CC");

                entity.ToTable("Master_Plat");

                entity.Property(e => e.PlatId)
                    .ValueGeneratedNever()
                    .HasColumnName("PlatID");

                entity.Property(e => e.PlatCode)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PlatName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MbranchView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MBranchView");

                entity.Property(e => e.Apv1)
                    .HasMaxLength(50)
                    .HasColumnName("APV_1")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Apv2)
                    .HasMaxLength(50)
                    .HasColumnName("APV_2")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Apv3)
                    .HasMaxLength(50)
                    .HasColumnName("APV_3")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Apv4)
                    .HasMaxLength(50)
                    .HasColumnName("APV_4")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.AreaCode)
                    .HasMaxLength(15)
                    .HasColumnName("AREA_CODE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CAddress1)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("C_ADDRESS1")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CAddress2)
                    .HasMaxLength(60)
                    .HasColumnName("C_ADDRESS2")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CArea)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("C_AREA")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CCity)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("C_CITY")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CCodate)
                    .HasColumnType("datetime")
                    .HasColumnName("C_CODATE");

                entity.Property(e => e.CCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("C_CODE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CFax)
                    .HasMaxLength(15)
                    .HasColumnName("C_FAX")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CListdate)
                    .HasColumnType("datetime")
                    .HasColumnName("C_LISTDATE");

                entity.Property(e => e.CListing)
                    .HasMaxLength(20)
                    .HasColumnName("C_LISTING")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CName)
                    .IsRequired()
                    .HasMaxLength(35)
                    .HasColumnName("C_NAME")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CNpwp)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("C_NPWP")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CPhone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("C_PHONE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CSign1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("C_SIGN1")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CSign2)
                    .HasMaxLength(30)
                    .HasColumnName("C_SIGN2")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CSign3)
                    .HasMaxLength(30)
                    .HasColumnName("C_SIGN3")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CSiup)
                    .HasMaxLength(20)
                    .HasColumnName("C_SIUP")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CSiupdate)
                    .HasColumnType("datetime")
                    .HasColumnName("C_SIUPDATE");

                entity.Property(e => e.CTitle1)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("C_TITLE1")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CTitle2)
                    .HasMaxLength(30)
                    .HasColumnName("C_TITLE2")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CTitle3)
                    .HasMaxLength(30)
                    .HasColumnName("C_TITLE3")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CType)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("C_TYPE");

                entity.Property(e => e.CabangOrPosko)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("CABANG_OR_POSKO")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CoaCashAdvance)
                    .HasMaxLength(20)
                    .HasColumnName("COA_CASH_ADVANCE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CoaCashInTransit)
                    .HasMaxLength(20)
                    .HasColumnName("COA_CASH_IN_TRANSIT")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CoaHubRak)
                    .HasMaxLength(20)
                    .HasColumnName("COA_HUB_RAK")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CoaKasBesar)
                    .HasMaxLength(20)
                    .HasColumnName("COA_KAS_BESAR")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CoaKasCollection)
                    .HasMaxLength(20)
                    .HasColumnName("COA_KAS_COLLECTION")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CoaKasKecil)
                    .HasMaxLength(20)
                    .HasColumnName("COA_KAS_KECIL")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CoaOperasional)
                    .HasMaxLength(20)
                    .HasColumnName("COA_OPERASIONAL")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CreBy)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("CRE_BY")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CRE_DATE");

                entity.Property(e => e.CreIpAddress)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("CRE_IP_ADDRESS")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Endofmonth)
                    .HasMaxLength(1)
                    .HasColumnName("ENDOFMONTH")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("IS_ACTIVE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.IsHo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("IS_HO")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Ktp1)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("KTP1")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Ktp2)
                    .HasMaxLength(16)
                    .HasColumnName("KTP2")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Ktp3)
                    .HasMaxLength(16)
                    .HasColumnName("KTP3")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.LimitPersen)
                    .HasColumnType("decimal(12, 8)")
                    .HasColumnName("limit_persen");

                entity.Property(e => e.MedHigh)
                    .HasMaxLength(1)
                    .HasColumnName("MED_HIGH")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ModBy)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("MOD_BY")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ModDate)
                    .HasColumnType("datetime")
                    .HasColumnName("MOD_DATE");

                entity.Property(e => e.ModIpAddress)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("MOD_IP_ADDRESS")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.MonthPeriod)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("MONTH_PERIOD");

                entity.Property(e => e.NpwpAddress)
                    .HasMaxLength(500)
                    .HasColumnName("NPWP_ADDRESS")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.NpwpName)
                    .HasMaxLength(200)
                    .HasColumnName("NPWP_NAME")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ParentCCode)
                    .HasMaxLength(6)
                    .HasColumnName("PARENT_C_CODE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.RegionCode)
                    .HasMaxLength(20)
                    .HasColumnName("REGION_CODE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Sandi)
                    .HasMaxLength(6)
                    .HasColumnName("SANDI")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ShortName)
                    .HasMaxLength(50)
                    .HasColumnName("SHORT_NAME")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.SysCompanyid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SYS_COMPANYID");

                entity.Property(e => e.YearPeriod)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("YEAR_PERIOD");
            });

            modelBuilder.Entity<MmerkView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MMerkView");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("COUNTRY_CODE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CreBy)
                    .HasMaxLength(15)
                    .HasColumnName("CRE_BY")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CRE_DATE");

                entity.Property(e => e.CreIpAddress)
                    .HasMaxLength(15)
                    .HasColumnName("CRE_IP_ADDRESS")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("DESCRIPTION")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.MerkCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("MERK_CODE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ModBy)
                    .HasMaxLength(15)
                    .HasColumnName("MOD_BY")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ModDate)
                    .HasColumnType("datetime")
                    .HasColumnName("MOD_DATE");

                entity.Property(e => e.ModIpAddress)
                    .HasMaxLength(15)
                    .HasColumnName("MOD_IP_ADDRESS")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<MmodelView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MModelView");

                entity.Property(e => e.CategoryCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("CATEGORY_CODE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CreBy)
                    .HasMaxLength(15)
                    .HasColumnName("CRE_BY")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CRE_DATE");

                entity.Property(e => e.CreIpAddress)
                    .HasMaxLength(15)
                    .HasColumnName("CRE_IP_ADDRESS")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("DESCRIPTION")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Grade)
                    .HasMaxLength(1)
                    .HasColumnName("GRADE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.MerkCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("MERK_CODE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ModBy)
                    .HasMaxLength(15)
                    .HasColumnName("MOD_BY")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ModDate)
                    .HasColumnType("datetime")
                    .HasColumnName("MOD_DATE");

                entity.Property(e => e.ModIpAddress)
                    .HasMaxLength(15)
                    .HasColumnName("MOD_IP_ADDRESS")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ModelCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("MODEL_CODE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<MpriceListView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MPriceListView");

                entity.Property(e => e.AssYear)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("ASS_YEAR")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Branch)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("BRANCH")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("C_CODE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CategoryCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("CATEGORY_CODE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ChangeExtRate)
                    .HasColumnType("numeric(19, 6)")
                    .HasColumnName("CHANGE_EXT_RATE");

                entity.Property(e => e.ChangeMaxDp)
                    .HasColumnType("numeric(9, 6)")
                    .HasColumnName("CHANGE_MAX_DP");

                entity.Property(e => e.ChangeMaxPurchase)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("CHANGE_MAX_PURCHASE");

                entity.Property(e => e.ChangePrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("CHANGE_PRICE");

                entity.Property(e => e.ChangeRate)
                    .HasColumnType("numeric(9, 6)")
                    .HasColumnName("CHANGE_RATE");

                entity.Property(e => e.ClassCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("CLASS_CODE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Condition)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("CONDITION")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CreBy)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("CRE_BY")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CRE_DATE");

                entity.Property(e => e.CreIpAddress)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("CRE_IP_ADDRESS")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.EffDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EFF_DATE");

                entity.Property(e => e.ExtRate)
                    .HasColumnType("numeric(9, 6)")
                    .HasColumnName("EXT_RATE");

                entity.Property(e => e.Grade)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("GRADE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.MaxDp)
                    .HasColumnType("decimal(9, 6)")
                    .HasColumnName("MAX_DP");

                entity.Property(e => e.MaxPurchase)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("MAX_PURCHASE");

                entity.Property(e => e.MerkCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("MERK_CODE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ModBy)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("MOD_BY")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ModDate)
                    .HasColumnType("datetime")
                    .HasColumnName("MOD_DATE");

                entity.Property(e => e.ModIpAddress)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("MOD_IP_ADDRESS")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ModelCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("MODEL_CODE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.PackageCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("PACKAGE_CODE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.ProductCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("PRODUCT_CODE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Rate)
                    .HasColumnType("numeric(9, 6)")
                    .HasColumnName("RATE");

                entity.Property(e => e.Rentalpay)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("RENTALPAY");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("STATUS")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.SubCategoryCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("SUB_CATEGORY_CODE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Tenor).HasColumnName("TENOR");

                entity.Property(e => e.TypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("TYPE_CODE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<MstUser>(entity =>
            {
                entity.ToTable("MST_USER");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Creby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREDATE");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.IsActive).HasColumnName("IS_ACTIVE");

                entity.Property(e => e.Modby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("datetime")
                    .HasColumnName("MODDATE");

                entity.Property(e => e.Password)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.Entity<MtypeView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MTypeView");

                entity.Property(e => e.CreBy)
                    .HasMaxLength(15)
                    .HasColumnName("CRE_BY")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CRE_DATE");

                entity.Property(e => e.CreIpAddress)
                    .HasMaxLength(15)
                    .HasColumnName("CRE_IP_ADDRESS")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("DESCRIPTION")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ModBy)
                    .HasMaxLength(15)
                    .HasColumnName("MOD_BY")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ModDate)
                    .HasColumnType("datetime")
                    .HasColumnName("MOD_DATE");

                entity.Property(e => e.ModIpAddress)
                    .HasMaxLength(15)
                    .HasColumnName("MOD_IP_ADDRESS")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ModelCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("MODEL_CODE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.TypeCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("TYPE_CODE")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<RptOfferingletterFacSyariah>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RPT_OFFERINGLETTER_FAC_SYARIAH");

                entity.Property(e => e.AlamatK)
                    .HasMaxLength(100)
                    .HasColumnName("ALAMAT_K");

                entity.Property(e => e.BiayaAdm)
                    .HasColumnType("numeric(17, 2)")
                    .HasColumnName("BIAYA_ADM");

                entity.Property(e => e.BiayaProvisi)
                    .HasMaxLength(50)
                    .HasColumnName("BIAYA_PROVISI");

                entity.Property(e => e.Bunga)
                    .HasColumnType("numeric(12, 8)")
                    .HasColumnName("BUNGA");

                entity.Property(e => e.Denda)
                    .HasMaxLength(30)
                    .HasColumnName("DENDA");

                entity.Property(e => e.Jkw)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("JKW");

                entity.Property(e => e.Kota)
                    .HasMaxLength(100)
                    .HasColumnName("KOTA");

                entity.Property(e => e.KotaTgl)
                    .HasMaxLength(100)
                    .HasColumnName("KOTA_TGL");

                entity.Property(e => e.Lsagree)
                    .HasMaxLength(25)
                    .HasColumnName("lsagree");

                entity.Property(e => e.NamaK)
                    .HasMaxLength(40)
                    .HasColumnName("NAMA_K");

                entity.Property(e => e.NoSurat)
                    .HasMaxLength(100)
                    .HasColumnName("NO_SURAT");

                entity.Property(e => e.Otr)
                    .HasMaxLength(50)
                    .HasColumnName("OTR");

                entity.Property(e => e.Pembiayaan)
                    .HasMaxLength(50)
                    .HasColumnName("PEMBIAYAAN");

                entity.Property(e => e.Scheme)
                    .HasMaxLength(15)
                    .HasColumnName("SCHEME");

                entity.Property(e => e.Selaku)
                    .HasMaxLength(20)
                    .HasColumnName("SELAKU");

                entity.Property(e => e.UserId)
                    .HasMaxLength(225)
                    .HasColumnName("user_id");

                entity.Property(e => e.Wakil)
                    .HasMaxLength(25)
                    .HasColumnName("WAKIL");
            });

            modelBuilder.Entity<SiapDm>(entity =>
            {
                entity.HasKey(e => e.EntryId);

                entity.ToTable("SIAP_DM");

                entity.Property(e => e.EntryId).HasColumnName("entry_id");

                entity.Property(e => e.ApplicationStatus)
                    .HasMaxLength(50)
                    .HasColumnName("application_status");

                entity.Property(e => e.BankAccountName)
                    .HasMaxLength(50)
                    .HasColumnName("bank_account_name");

                entity.Property(e => e.BankAccountNumber)
                    .HasMaxLength(50)
                    .HasColumnName("bank_account_number");

                entity.Property(e => e.BankName)
                    .HasMaxLength(50)
                    .HasColumnName("bank_name");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.CarBrand)
                    .HasMaxLength(50)
                    .HasColumnName("car_brand");

                entity.Property(e => e.CarInsurance)
                    .HasMaxLength(50)
                    .HasColumnName("car_insurance");

                entity.Property(e => e.CarModel)
                    .HasMaxLength(50)
                    .HasColumnName("car_model");

                entity.Property(e => e.CarPhoto)
                    .HasMaxLength(200)
                    .HasColumnName("car_photo");

                entity.Property(e => e.CarRegistrationNumber)
                    .HasMaxLength(50)
                    .HasColumnName("car_registration_number");

                entity.Property(e => e.CarType)
                    .HasMaxLength(50)
                    .HasColumnName("car_type");

                entity.Property(e => e.CarYear)
                    .HasMaxLength(50)
                    .HasColumnName("car_year");

                entity.Property(e => e.CollArrivedBase)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("coll_arrived_base");

                entity.Property(e => e.CollArrivedCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("coll_arrived_code");

                entity.Property(e => e.CollArrivedLat)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("coll_arrived_lat");

                entity.Property(e => e.CollArrivedLng)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("coll_arrived_lng");

                entity.Property(e => e.CollArrivedName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("coll_arrived_name");

                entity.Property(e => e.CollateralAssignto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("collateral_assignto");

                entity.Property(e => e.CompanyAddress).HasMaxLength(200);

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.CompanyPhone).HasMaxLength(50);

                entity.Property(e => e.ContractNo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("contract_no");

                entity.Property(e => e.CreBy)
                    .HasMaxLength(50)
                    .HasColumnName("cre_by");

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasColumnName("cre_date");

                entity.Property(e => e.CreIp)
                    .HasMaxLength(50)
                    .HasColumnName("cre_ip");

                entity.Property(e => e.CurrentFormStep)
                    .HasMaxLength(50)
                    .HasColumnName("current_form_step");

                entity.Property(e => e.DigisignFile)
                    .HasMaxLength(500)
                    .HasColumnName("digisign_file");

                entity.Property(e => e.DomAddress)
                    .HasMaxLength(255)
                    .HasColumnName("dom_address");

                entity.Property(e => e.DomCode)
                    .HasMaxLength(50)
                    .HasColumnName("dom_code");

                entity.Property(e => e.DomDistrict)
                    .HasMaxLength(50)
                    .HasColumnName("dom_district");

                entity.Property(e => e.DomDistrictCode)
                    .HasMaxLength(50)
                    .HasColumnName("dom_district_code");

                entity.Property(e => e.DomLat)
                    .HasMaxLength(50)
                    .HasColumnName("dom_lat");

                entity.Property(e => e.DomLng)
                    .HasMaxLength(50)
                    .HasColumnName("dom_lng");

                entity.Property(e => e.DomOwnership)
                    .HasMaxLength(50)
                    .HasColumnName("dom_ownership");

                entity.Property(e => e.DomPostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("dom_postal_code")
                    .IsFixedLength(true);

                entity.Property(e => e.DomProvince)
                    .HasMaxLength(50)
                    .HasColumnName("dom_province");

                entity.Property(e => e.DomProvinceCode)
                    .HasMaxLength(50)
                    .HasColumnName("dom_province_code");

                entity.Property(e => e.DomRt)
                    .HasMaxLength(10)
                    .HasColumnName("dom_rt");

                entity.Property(e => e.DomRw)
                    .HasMaxLength(10)
                    .HasColumnName("dom_rw");

                entity.Property(e => e.DomSubdistrict1)
                    .HasMaxLength(50)
                    .HasColumnName("dom_subdistrict1");

                entity.Property(e => e.DomSubdistrict1Code)
                    .HasMaxLength(50)
                    .HasColumnName("dom_subdistrict1_code");

                entity.Property(e => e.DomSubdistrict2)
                    .HasMaxLength(50)
                    .HasColumnName("dom_subdistrict2");

                entity.Property(e => e.DomSubdistrict2Code)
                    .HasMaxLength(50)
                    .HasColumnName("dom_subdistrict2_code");

                entity.Property(e => e.EkycEmail)
                    .HasMaxLength(50)
                    .HasColumnName("ekyc_email");

                entity.Property(e => e.EkycRejectReason)
                    .HasMaxLength(50)
                    .HasColumnName("ekyc_reject_reason");

                entity.Property(e => e.EkycStatus)
                    .HasMaxLength(50)
                    .HasColumnName("ekyc_status");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.EstimatedDisbursement)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("estimated_disbursement");

                entity.Property(e => e.EstimatedInstallment)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("estimated_installment");

                entity.Property(e => e.Fee)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("fee");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.IdAddress)
                    .HasMaxLength(255)
                    .HasColumnName("id_address");

                entity.Property(e => e.IdDistrict)
                    .HasMaxLength(50)
                    .HasColumnName("id_district");

                entity.Property(e => e.IdDistrictCode)
                    .HasMaxLength(50)
                    .HasColumnName("id_district_code");

                entity.Property(e => e.IdLat)
                    .HasMaxLength(50)
                    .HasColumnName("id_lat");

                entity.Property(e => e.IdLng)
                    .HasMaxLength(50)
                    .HasColumnName("id_lng");

                entity.Property(e => e.IdPostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("id_postal_code");

                entity.Property(e => e.IdProvince)
                    .HasMaxLength(50)
                    .HasColumnName("id_province");

                entity.Property(e => e.IdProvinceCode)
                    .HasMaxLength(50)
                    .HasColumnName("id_province_code");

                entity.Property(e => e.IdRt)
                    .HasMaxLength(50)
                    .HasColumnName("id_rt");

                entity.Property(e => e.IdRw)
                    .HasMaxLength(50)
                    .HasColumnName("id_rw");

                entity.Property(e => e.IdSubdistrict1)
                    .HasMaxLength(50)
                    .HasColumnName("id_subdistrict1");

                entity.Property(e => e.IdSubdistrict1Code)
                    .HasMaxLength(50)
                    .HasColumnName("id_subdistrict1_code");

                entity.Property(e => e.IdSubdistrict2)
                    .HasMaxLength(50)
                    .HasColumnName("id_subdistrict2");

                entity.Property(e => e.IdSubdistrict2Code)
                    .HasMaxLength(50)
                    .HasColumnName("id_subdistrict2_code");

                entity.Property(e => e.IsExpressSurvey)
                    .HasMaxLength(50)
                    .HasColumnName("is_express_survey");

                entity.Property(e => e.JobType).HasMaxLength(50);

                entity.Property(e => e.KtpPhoto)
                    .HasMaxLength(200)
                    .HasColumnName("ktp_photo");

                entity.Property(e => e.MfinState)
                    .HasMaxLength(50)
                    .HasColumnName("mfin_state");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(50)
                    .HasColumnName("mobile_number");

                entity.Property(e => e.ModBy)
                    .HasMaxLength(50)
                    .HasColumnName("mod_by");

                entity.Property(e => e.ModDate)
                    .HasColumnType("datetime")
                    .HasColumnName("mod_date");

                entity.Property(e => e.ModIp)
                    .HasMaxLength(50)
                    .HasColumnName("mod_ip");

                entity.Property(e => e.MonthlyIncome)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("monthly_income");

                entity.Property(e => e.MothersName)
                    .HasMaxLength(100)
                    .HasColumnName("mothers_name");

                entity.Property(e => e.NikNumber)
                    .HasMaxLength(50)
                    .HasColumnName("nik_number");

                entity.Property(e => e.NpwpNumber)
                    .HasMaxLength(50)
                    .HasColumnName("npwp_number");

                entity.Property(e => e.NpwpPhoto)
                    .HasMaxLength(200)
                    .HasColumnName("npwp_photo");

                entity.Property(e => e.PamNumber)
                    .HasMaxLength(50)
                    .HasColumnName("PAM_Number");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("phone_number");

                entity.Property(e => e.PlaceOfBirth)
                    .HasMaxLength(50)
                    .HasColumnName("place_of_birth");

                entity.Property(e => e.PlnNumber)
                    .HasMaxLength(50)
                    .HasColumnName("PLN_Number");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("product_name");

                entity.Property(e => e.ReasonReject)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("reason_reject");

                entity.Property(e => e.SelfieWithKtpPhoto)
                    .HasMaxLength(200)
                    .HasColumnName("selfie_with_ktp_photo");

                entity.Property(e => e.SiapId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("siap_id");

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .HasColumnName("source");

                entity.Property(e => e.SpouseName).HasMaxLength(100);

                entity.Property(e => e.SpouseNikNumber)
                    .HasMaxLength(50)
                    .HasColumnName("spouseNik_number");

                entity.Property(e => e.StnkPhoto)
                    .HasMaxLength(200)
                    .HasColumnName("stnk_photo");

                entity.Property(e => e.SubmittedAmount)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("submitted_amount");

                entity.Property(e => e.SurveyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("survey_date");

                entity.Property(e => e.Tenor).HasColumnName("tenor");

                entity.Property(e => e.Wop)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("wop");
            });

            modelBuilder.Entity<SiapDr>(entity =>
            {
                entity.HasKey(e => e.EntryId);

                entity.ToTable("SIAP_DR");

                entity.Property(e => e.EntryId).HasColumnName("entry_id");

                entity.Property(e => e.ApplicationStatus)
                    .HasMaxLength(50)
                    .HasColumnName("application_status");

                entity.Property(e => e.AstAddress)
                    .HasMaxLength(255)
                    .HasColumnName("ast_address");

                entity.Property(e => e.AstDistrict)
                    .HasMaxLength(50)
                    .HasColumnName("ast_district");

                entity.Property(e => e.AstDistrictCode)
                    .HasMaxLength(50)
                    .HasColumnName("ast_district_code");

                entity.Property(e => e.AstLat)
                    .HasMaxLength(50)
                    .HasColumnName("ast_lat");

                entity.Property(e => e.AstLng)
                    .HasMaxLength(50)
                    .HasColumnName("ast_lng");

                entity.Property(e => e.AstPostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("ast_postal_code");

                entity.Property(e => e.AstProvince)
                    .HasMaxLength(50)
                    .HasColumnName("ast_province");

                entity.Property(e => e.AstProvinceCode)
                    .HasMaxLength(50)
                    .HasColumnName("ast_province_code");

                entity.Property(e => e.AstRt)
                    .HasMaxLength(50)
                    .HasColumnName("ast_rt");

                entity.Property(e => e.AstRw)
                    .HasMaxLength(50)
                    .HasColumnName("ast_rw");

                entity.Property(e => e.AstSubdistrict1)
                    .HasMaxLength(50)
                    .HasColumnName("ast_subdistrict1");

                entity.Property(e => e.AstSubdistrict1Code)
                    .HasMaxLength(50)
                    .HasColumnName("ast_subdistrict1_code");

                entity.Property(e => e.AstSubdistrict2)
                    .HasMaxLength(50)
                    .HasColumnName("ast_subdistrict2");

                entity.Property(e => e.AstSubdistrict2Code)
                    .HasMaxLength(50)
                    .HasColumnName("ast_subdistrict2_code");

                entity.Property(e => e.BankAccountName)
                    .HasMaxLength(50)
                    .HasColumnName("bank_account_name");

                entity.Property(e => e.BankAccountNumber)
                    .HasMaxLength(50)
                    .HasColumnName("bank_account_number");

                entity.Property(e => e.BankName)
                    .HasMaxLength(50)
                    .HasColumnName("bank_name");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.CollateralAssignto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("collateral_assignto");

                entity.Property(e => e.CompanyAddress).HasMaxLength(200);

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.CompanyPhone).HasMaxLength(50);

                entity.Property(e => e.ContractNo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("contract_no");

                entity.Property(e => e.CreBy)
                    .HasMaxLength(50)
                    .HasColumnName("cre_by");

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasColumnName("cre_date");

                entity.Property(e => e.CreIp)
                    .HasMaxLength(50)
                    .HasColumnName("cre_ip");

                entity.Property(e => e.CurrentFormStep)
                    .HasMaxLength(50)
                    .HasColumnName("current_form_step");

                entity.Property(e => e.DigisignFile)
                    .HasMaxLength(500)
                    .HasColumnName("digisign_file");

                entity.Property(e => e.DomAddress)
                    .HasMaxLength(255)
                    .HasColumnName("dom_address");

                entity.Property(e => e.DomDistrict)
                    .HasMaxLength(50)
                    .HasColumnName("dom_district");

                entity.Property(e => e.DomDistrictCode)
                    .HasMaxLength(50)
                    .HasColumnName("dom_district_code");

                entity.Property(e => e.DomLat)
                    .HasMaxLength(50)
                    .HasColumnName("dom_lat");

                entity.Property(e => e.DomLng)
                    .HasMaxLength(50)
                    .HasColumnName("dom_lng");

                entity.Property(e => e.DomOwnership)
                    .HasMaxLength(50)
                    .HasColumnName("dom_ownership");

                entity.Property(e => e.DomPostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("dom_postal_code")
                    .IsFixedLength(true);

                entity.Property(e => e.DomProvince)
                    .HasMaxLength(50)
                    .HasColumnName("dom_province");

                entity.Property(e => e.DomProvinceCode)
                    .HasMaxLength(50)
                    .HasColumnName("dom_province_code");

                entity.Property(e => e.DomRt)
                    .HasMaxLength(10)
                    .HasColumnName("dom_rt");

                entity.Property(e => e.DomRw)
                    .HasMaxLength(10)
                    .HasColumnName("dom_rw");

                entity.Property(e => e.DomSubdistrict1)
                    .HasMaxLength(50)
                    .HasColumnName("dom_subdistrict1");

                entity.Property(e => e.DomSubdistrict1Code)
                    .HasMaxLength(50)
                    .HasColumnName("dom_subdistrict1_code");

                entity.Property(e => e.DomSubdistrict2)
                    .HasMaxLength(50)
                    .HasColumnName("dom_subdistrict2");

                entity.Property(e => e.DomSubdistrict2Code)
                    .HasMaxLength(50)
                    .HasColumnName("dom_subdistrict2_code");

                entity.Property(e => e.EkycEmail)
                    .HasMaxLength(50)
                    .HasColumnName("ekyc_email");

                entity.Property(e => e.EkycRejectReason)
                    .HasMaxLength(50)
                    .HasColumnName("ekyc_reject_reason");

                entity.Property(e => e.EkycStatus)
                    .HasMaxLength(50)
                    .HasColumnName("ekyc_status");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.EstimatedDisbursement)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("estimated_disbursement");

                entity.Property(e => e.EstimatedInstallment)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("estimated_installment");

                entity.Property(e => e.Fee)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("fee");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.HousePhoto)
                    .HasMaxLength(200)
                    .HasColumnName("house_photo");

                entity.Property(e => e.IdAddress)
                    .HasMaxLength(255)
                    .HasColumnName("id_address");

                entity.Property(e => e.IdDistrict)
                    .HasMaxLength(50)
                    .HasColumnName("id_district");

                entity.Property(e => e.IdDistrictCode)
                    .HasMaxLength(50)
                    .HasColumnName("id_district_code");

                entity.Property(e => e.IdLat)
                    .HasMaxLength(50)
                    .HasColumnName("id_lat");

                entity.Property(e => e.IdLng)
                    .HasMaxLength(50)
                    .HasColumnName("id_lng");

                entity.Property(e => e.IdPostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("id_postal_code");

                entity.Property(e => e.IdProvince)
                    .HasMaxLength(50)
                    .HasColumnName("id_province");

                entity.Property(e => e.IdProvinceCode)
                    .HasMaxLength(50)
                    .HasColumnName("id_province_code");

                entity.Property(e => e.IdRt)
                    .HasMaxLength(50)
                    .HasColumnName("id_rt");

                entity.Property(e => e.IdRw)
                    .HasMaxLength(50)
                    .HasColumnName("id_rw");

                entity.Property(e => e.IdSubdistrict1)
                    .HasMaxLength(50)
                    .HasColumnName("id_subdistrict1");

                entity.Property(e => e.IdSubdistrict1Code)
                    .HasMaxLength(50)
                    .HasColumnName("id_subdistrict1_code");

                entity.Property(e => e.IdSubdistrict2)
                    .HasMaxLength(50)
                    .HasColumnName("id_subdistrict2");

                entity.Property(e => e.IdSubdistrict2Code)
                    .HasMaxLength(50)
                    .HasColumnName("id_subdistrict2_code");

                entity.Property(e => e.JobType).HasMaxLength(50);

                entity.Property(e => e.KtpPhoto)
                    .HasMaxLength(200)
                    .HasColumnName("ktp_photo");

                entity.Property(e => e.MfinState)
                    .HasMaxLength(50)
                    .HasColumnName("mfin_state");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(50)
                    .HasColumnName("mobile_number");

                entity.Property(e => e.ModBy)
                    .HasMaxLength(50)
                    .HasColumnName("mod_by");

                entity.Property(e => e.ModDate)
                    .HasColumnType("datetime")
                    .HasColumnName("mod_date");

                entity.Property(e => e.ModIp)
                    .HasMaxLength(50)
                    .HasColumnName("mod_ip");

                entity.Property(e => e.MonthlyIncome)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("monthly_income");

                entity.Property(e => e.MothersName)
                    .HasMaxLength(100)
                    .HasColumnName("mothers_name");

                entity.Property(e => e.NikNumber)
                    .HasMaxLength(50)
                    .HasColumnName("nik_number");

                entity.Property(e => e.NpwpNumber)
                    .HasMaxLength(50)
                    .HasColumnName("npwp_number");

                entity.Property(e => e.NpwpPhoto)
                    .HasMaxLength(200)
                    .HasColumnName("npwp_photo");

                entity.Property(e => e.PamNumber)
                    .HasMaxLength(50)
                    .HasColumnName("PAM_Number");

                entity.Property(e => e.PbbPhoto)
                    .HasMaxLength(200)
                    .HasColumnName("pbb_photo");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("phone_number");

                entity.Property(e => e.PlaceOfBirth)
                    .HasMaxLength(50)
                    .HasColumnName("place_of_birth");

                entity.Property(e => e.PlnNumber)
                    .HasMaxLength(50)
                    .HasColumnName("PLN_Number");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("product_name");

                entity.Property(e => e.SelfieWithKtpPhoto)
                    .HasMaxLength(200)
                    .HasColumnName("selfie_with_ktp_photo");

                entity.Property(e => e.SiapId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("siap_id");

                entity.Property(e => e.Source)
                    .HasMaxLength(50)
                    .HasColumnName("source");

                entity.Property(e => e.SpouseName).HasMaxLength(100);

                entity.Property(e => e.SpouseNikNumber)
                    .HasMaxLength(50)
                    .HasColumnName("spouseNik_number");

                entity.Property(e => e.SubmittedAmount)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("submitted_amount");

                entity.Property(e => e.Tenor).HasColumnName("tenor");

                entity.Property(e => e.Wop)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("wop");
            });

            modelBuilder.Entity<TapplCStatus>(entity =>
            {
                entity.HasKey(e => e.ApplId);

                entity.ToTable("TAPPL_C_STATUS");

                entity.Property(e => e.ApplId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPL_ID");

                entity.Property(e => e.ApplStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPL_STATUS");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.MsixApplicno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MSIX_APPLICNO");

                entity.Property(e => e.MsixLsagree)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MSIX_LSAGREE");

                entity.Property(e => e.PoliceNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POLICE_NO");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_DATE");
            });

            modelBuilder.Entity<TapplCStatusLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TAPPL_C_STATUS_LOG");

                entity.Property(e => e.ApplId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPL_ID");

                entity.Property(e => e.ApplStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPL_STATUS");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREATED_BY");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_DATE");

                entity.Property(e => e.LogId).HasColumnName("LOG_ID");

                entity.Property(e => e.MsixApplicno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MSIX_APPLICNO");

                entity.Property(e => e.MsixLsagree)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MSIX_LSAGREE");

                entity.Property(e => e.PoliceNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POLICE_NO");
            });

            modelBuilder.Entity<TvalidationCollateral>(entity =>
            {
                entity.ToTable("TVALIDATION_COLLATERAL");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.ApplId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPL_ID");

                entity.Property(e => e.Creby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREDATE");

                entity.Property(e => e.CustName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CUST_NAME");

                entity.Property(e => e.Modby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("datetime")
                    .HasColumnName("MODDATE");

                entity.Property(e => e.Nopol)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOPOL");

                entity.Property(e => e.ReasonResult)
                    .IsUnicode(false)
                    .HasColumnName("REASON_RESULT");

                entity.Property(e => e.RecommendationResult).HasColumnName("RECOMMENDATION_RESULT");

                entity.Property(e => e.ResiNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RESI_NUMBER");
            });

            modelBuilder.Entity<TvalidationCollateralIdnumber>(entity =>
            {
                entity.ToTable("TVALIDATION_COLLATERAL_IDNUMBER");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.CheckValue)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CHECK_VALUE");

                entity.Property(e => e.Creby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREDATE");

                entity.Property(e => e.IdcheckIdnumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IDCHECK_IDNUMBER");

                entity.Property(e => e.IdvalidationCollateral)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IDVALIDATION_COLLATERAL");

                entity.Property(e => e.IsValid).HasColumnName("IS_VALID");

                entity.Property(e => e.Modby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("datetime")
                    .HasColumnName("MODDATE");
            });

            modelBuilder.Entity<TvalidationCollateralPhysical>(entity =>
            {
                entity.ToTable("TVALIDATION_COLLATERAL_PHYSICAL");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Creby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CREBY");

                entity.Property(e => e.Credate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREDATE");

                entity.Property(e => e.IdcheckPhysical)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IDCHECK_PHYSICAL");

                entity.Property(e => e.IdvalidationCollateral)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IDVALIDATION_COLLATERAL");

                entity.Property(e => e.IsValid).HasColumnName("IS_VALID");

                entity.Property(e => e.Modby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MODBY");

                entity.Property(e => e.Moddate)
                    .HasColumnType("datetime")
                    .HasColumnName("MODDATE");

                entity.Property(e => e.Reason)
                    .IsUnicode(false)
                    .HasColumnName("REASON");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
