using BlogSystem.Dtos;
using BlogSystem.IBLL;
using BlogSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.IDAL;
using System.Data.Entity;

namespace BlogSystem.BLL
{
    public class CopyrightBll : ICopyrightBll
    {
        private ICopyrightDal _dal;

        public CopyrightBll(ICopyrightDal dal)
        {
            _dal = dal;
        }


        public async Task<int> AddCopyrightAsync(string title, string detail, string telephone, string mobile, string logo, string images, string email, string address, string qqNumber, string qqNumber2, string wechat)
        {
            return await _dal.AddAsync(new Copyright
            {
                Title = title,
                Detail = detail,
                Telephone = telephone,
                Mobile = mobile,
                Logo = logo,
                Images = images,
                Email = email,
                Address = address,
                QQNumber = qqNumber,
                QQNumber2 = qqNumber2,
                Wechat = wechat
            });
        }

        public async Task<int> EditCopyrightAsync(Guid id, string title, string detail, string telephone, string mobile, string logo, string images, string email, string address, string qqNumber, string qqNumber2, string wechat)
        {
            var data = await _dal.QueryAsync(id);

            if (data == null)
            {
                return -2;
            }
            else 
            {
                data.Title = title;
                data.Detail = detail;
                data.Telephone = telephone;
                data.Mobile = mobile;
                data.Logo = logo;
                data.Images = images;
                data.Email = email;
                data.Address = address;
                data.QQNumber = qqNumber;
                data.QQNumber2 = qqNumber2;
                data.Wechat = wechat;
                data.UpdateTime = DateTime.Now;
                return await _dal.EditAsync(data);
            }

        }

        public async Task<CopyrightDto> GetCopyrightAsync(Guid id)
        {
            var data = await _dal.QueryAsync(id);
            if (data == null)
            {
                return new CopyrightDto();
            }
            else 
            {
                return new CopyrightDto 
                {
                    Id = data.Id,
                    Title = data.Title,
                    Detail = data.Detail,
                    Telephone = data.Telephone,
                    Mobile = data.Mobile,
                    Logo = data.Logo,
                    Images = data.Images,
                    Address = data.Address,
                    Email =data.Email,
                    QQNumber = data.QQNumber,
                    QQNumber2 = data.QQNumber2,
                    Wechat = data.Wechat,
                    UpdateTime = data.UpdateTime
                
                };
            }
        }

        public async Task<CopyrightDto> GetCopyrightAsync() 
        {
            var data = await _dal.Query().FirstOrDefaultAsync();
            if (data == null) 
            {
                return new CopyrightDto();
            }
            else
            {
                return new CopyrightDto
                {
                    Id = data.Id,
                    Title = data.Title,
                    Detail = data.Detail,
                    Telephone = data.Telephone,
                    Mobile = data.Mobile,
                    Logo = data.Logo,
                    Images = data.Images,
                    Address = data.Address,
                    Email = data.Email,
                    QQNumber = data.QQNumber,
                    QQNumber2 = data.QQNumber2,
                    Wechat = data.Wechat,
                    UpdateTime = data.UpdateTime

                };
            }
        }
    }
}
