using Microsoft.AspNetCore.Hosting;
using SurveyConsole.Models.FACEDB;
using SurveyConsole.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyConsole.Repositories
{
    public class SiapRepository
    {
        private FACEDBContext _facedb;

        public SiapRepository(FACEDBContext facedb)
        {
            _facedb = facedb;
        }

        public HttpResponse GetDanaRumahPaginate(int page = 1, int limit = 10, string keyowrd = null)
        {
            var data = _facedb.SiapDrs.Where(a => a.CreDate >= DateTime.Parse("2022-08-17")).AsQueryable();

            int offset = (page * limit) - limit;
            int totalData = data.Count();

            // Filter
            if (!String.IsNullOrEmpty(keyowrd))
            {
                data = data.Where(a => a.SiapId.Contains(keyowrd) || a.CreDate.ToString().Contains(keyowrd) || a.FullName.Contains(keyowrd) || a.DomAddress.Contains(keyowrd) || a.AstAddress.Contains(keyowrd) || a.MfinState.Contains(keyowrd) || a.PhoneNumber.Contains(keyowrd) || a.NikNumber.Contains(keyowrd)).AsQueryable();
                totalData = data.Count();
            }

            // count total page
            int totalPage = (Int32)(Math.Ceiling((decimal)totalData / (decimal)limit) > 0 ? Math.Ceiling((decimal)totalData / (decimal)limit) : 1);

            // Sort
            data = data.OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).AsQueryable();

            // Pagination
            var listData = data.Skip(offset).Take(limit).ToList();

            var result = new HttpResponse();
            result.statuscode = (listData != null && listData.Count() > 0 ? 200 : 404);
            result.message = (result.statuscode == 200 ? "OK" : "Not found!");
            result.currPage = (listData != null && listData.Count() > 0 ? page : 1);
            result.totalPage = totalPage;
            result.totalData = totalData;
            result.data = listData;

            return result;
        }

        public HttpResponse GetDanaMobilPaginate(int page = 1, int limit = 10, string keyowrd = null)
        {
            var data = _facedb.SiapDms.Where(a => a.CreDate >= DateTime.Parse("2022-08-17")).AsQueryable();

            int offset = (page * limit) - limit;
            int totalData = data.Count();

            // Filter
            if (!String.IsNullOrEmpty(keyowrd))
            {
                data = data.Where(a => a.SiapId.Contains(keyowrd) || a.CreDate.ToString().Contains(keyowrd) || a.FullName.Contains(keyowrd) || a.DomAddress.Contains(keyowrd) || a.CarRegistrationNumber.Contains(keyowrd) || a.PhoneNumber.Contains(keyowrd) || a.MfinState.Contains(keyowrd) || a.NikNumber.Contains(keyowrd)).AsQueryable();
                totalData = data.Count();
            }

            // count total page
            int totalPage = (Int32)(Math.Ceiling((decimal)totalData / (decimal)limit) > 0 ? Math.Ceiling((decimal)totalData / (decimal)limit) : 1);

            // Sort
            data = data.OrderByDescending(a => a.CreDate).ThenByDescending(a => a.ModDate).AsQueryable();

            // Pagination
            var listData = data.Skip(offset).Take(limit).ToList();

            var result = new HttpResponse();
            result.statuscode = (listData != null && listData.Count() > 0 ? 200 : 404);
            result.message = (result.statuscode == 200 ? "OK" : "Not found!");
            result.currPage = (listData != null && listData.Count() > 0 ? page : 1);
            result.totalPage = totalPage;
            result.totalData = totalData;
            result.data = listData;

            return result;
        }
    }
}
