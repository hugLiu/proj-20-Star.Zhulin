using Microsoft.EntityFrameworkCore;
using Abp.Application.Services.Dto;
using Star.Zhulin.Albums.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using System;

namespace Star.Zhulin.Albums
{
    public class AlbumService : ZhulinAppServiceBase, IAlbumService
    {
        public readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public IEnumerable<string> GetAlbumInfo()
        {
            return null;
        }

        //public string GetAlbum()
        //{
        //    return _albumRepository.GetTask2(3);
        //}

        public async Task<ListResultDto<AlbumDto>> GetAlbumInfo(AlbumInput input)
        {
            var album = await _albumRepository
                .GetAll()
                .WhereIf(Guid.Empty != input.Id, t => t.Id == input.Id)
                .WhereIf(Guid.Empty != input.Pid, t => t.Pid == input.Pid)
                .WhereIf(!string.IsNullOrEmpty(input.Name), t => t.Name == input.Name)
                .OrderByDescending(t => t.FieldIndex)
                .ToListAsync();

            return new ListResultDto<AlbumDto>
            (
                ObjectMapper.Map<List<AlbumDto>>(album)
            );
            //return new AlbumOutput
            //{
            //    Album = album.MapTo<List<AlbumDto>>()
            //};

        }
        public async Task<ListResultDto<AlbumDto>> GetAll()
        {
            var album = await _albumRepository
                .GetAll()
                .OrderByDescending(t => t.FieldIndex)
                .ToListAsync();

            return new ListResultDto<AlbumDto>
            (
                ObjectMapper.Map<List<AlbumDto>>(album)
            );
        }

        public async Task<ListResultDto<AlbumDto>> GetAlbumParentInfo()
        {
            var album = await _albumRepository
                .GetAll()
                .Where(t => t.Pid == null)
                .OrderByDescending(t => t.FieldIndex)
                .ToListAsync();

            return new ListResultDto<AlbumDto>
            (
                ObjectMapper.Map<List<AlbumDto>>(album)
            );
        }
    }
}
