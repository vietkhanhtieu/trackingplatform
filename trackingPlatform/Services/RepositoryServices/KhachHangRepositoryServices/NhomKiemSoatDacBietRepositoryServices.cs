
using Microsoft.EntityFrameworkCore;
using trackingPlatform.Models;
using trackingPlatform.Models.Dtos;
using trackingPlatform.Models.KhachHangModels;
using trackingPlatform.Utils.KhachHangUtils;

namespace trackingPlatform.Services.RepositoryServices.KhachHangRepositoryServices
{
    public class NhomKiemSoatDacBietRepositoryServices : BaseRepositoryServices<NhomKiemSoatDacBiet>
    {
        public NhomKiemSoatDacBietRepositoryServices(CnnDbContext cnnDbContext) : base(cnnDbContext) { }

        public async Task<NhomKiemSoatDacBiet> FindByMaNhomKiemSoat(string maNKSDB)
        {
            return (await _context.NhomKiemSoatDacBiets.FirstOrDefaultAsync(NKSDB => NKSDB.MaNksdb == maNKSDB))!;
        }

        
        public async Task<PostDto> AddorUpdateNhomKiemSoats(List<NhomKiemSoatDacBiet> nhomKiemSoatDacBiets)
        {
            PostDto result = new PostDto();
            foreach (NhomKiemSoatDacBiet nhomKiemSoatDacBiet in nhomKiemSoatDacBiets)
            {
                try
                {
                    NhomKiemSoatDacBiet existNKSDB = await FindByMaNhomKiemSoat(nhomKiemSoatDacBiet.MaNksdb);
                    if (existNKSDB != null)
                    {
                        NhomKiemSoatDacBiet NKSDB = NhomKiemSoatDacBietUtils.UpdateNhomKiemSoatDacBiet(existNKSDB, nhomKiemSoatDacBiet);

                        await UpdateAsync(NKSDB);
                        result.NumberOfUpdate++;
                    }
                    else
                    {
                        await AddAsync(nhomKiemSoatDacBiet);
                        result.NumberOfCreate++;
                    }
                }
                catch (Exception ex)
                {
                    result.NumberOfError++;
                    result.EntityErrors.Add(new EntityError
                    {
                        Id = nhomKiemSoatDacBiet.MaNksdb.ToString(),
                        Message = ex.Message
                    }
                    );
                }

            }
            return result;
        }
        private IQueryable<NhomKiemSoatDacBiet> AddTopQuery(IQueryable<NhomKiemSoatDacBiet> query, int top)
        {
            return top > 0 ? query.Take(top) : query;
        }

        private IQueryable<NhomKiemSoatDacBiet> AddSkipQuery(IQueryable<NhomKiemSoatDacBiet> query, int skip)
        {
            return skip > 0 ? query.Skip(skip) : query;
        }
    }
}
