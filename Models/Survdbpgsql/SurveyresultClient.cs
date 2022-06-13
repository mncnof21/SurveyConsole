using System;
using System.Collections.Generic;

#nullable disable

namespace SurveyConsole.Models.Survdbpgsql
{
    public partial class SurveyresultClient
    {
        public SurveyresultClient()
        {
            SurveyresultQuisioners = new HashSet<SurveyresultQuisioner>();
            SurveyresultUploads = new HashSet<SurveyresultUpload>();
        }

        public Guid Id { get; set; }
        public string GelarDepan { get; set; }
        public string Nama { get; set; }
        public string GelarBelakang { get; set; }
        public string NamaKtp { get; set; }
        public string NoKtp { get; set; }
        public DateTime? KtpExpireFrom { get; set; }
        public DateTime? KtpExpireTo { get; set; }
        public string Ao { get; set; }
        public DateTime? Tgllahir { get; set; }
        public string Tempatlahir { get; set; }
        public string Namaibu { get; set; }
        public string Alamat { get; set; }
        public string Rt { get; set; }
        public string Rw { get; set; }
        public string Kodepos { get; set; }
        public string Kelurahan { get; set; }
        public string Kecamatan { get; set; }
        public string Hpno { get; set; }
        public string Telpno { get; set; }
        public string Faxno { get; set; }
        public string Nopol { get; set; }
        public DateTime? Credate { get; set; }
        public string Creby { get; set; }
        public DateTime? Moddate { get; set; }
        public string Modby { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public Guid? Taskid { get; set; }

        public virtual ICollection<SurveyresultQuisioner> SurveyresultQuisioners { get; set; }
        public virtual ICollection<SurveyresultUpload> SurveyresultUploads { get; set; }
    }
}
